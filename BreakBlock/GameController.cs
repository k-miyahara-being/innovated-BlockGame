using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows;
using System.Windows.Forms;

namespace BreakBlock {
    /// <summary>
    /// ゲームコントローラクラス
    /// </summary>
    public class GameController {
        /// <summary>
        /// スコア
        /// </summary>
        public int Score { get; set; }
        /// <summary>
        /// ステータス
        /// </summary>
        public Status Status { get; set; }
        /// <summary>
        /// 弾
        /// </summary>
        public Ball Ball { get; set; }
        /// <summary>
        /// ボールのコレクション
        /// </summary>
        private Stack<Ball> Balls { get; set; }
        /// <summary>
        /// ボール数
        /// </summary>
        public int BallCount  => this.Balls.Count; 
        
        /// <summary>
        /// ブロック
        /// </summary>
        //public Block Block { get; set; }
        public List<Rectangle> Blocks { get; set; }
        /// <summary>
        /// バー
        /// </summary>
        public Bar Bar { get; set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="vPictureBoxWidth">ピクチャーボックスの幅</param>
        public GameController(int vPictureBoxWidth) {
            this.Initialize(vPictureBoxWidth);
        }
        /// <summary>
        /// コントローラの初期化
        /// </summary>
        /// <param name="vPictureBoxWidth"></param>
        public void Initialize(int vPictureBoxWidth) {
            this.Score = 0;

            this.Balls = new Stack<Ball>();
            for (int i = 0; i < Define.C_BallNum; i++) {
                this.Balls.Push(new Ball(vPictureBoxWidth / 2, Define.C_BarPositionY - Define.C_BallRadius));
            }
            this.PopBall();

            this.Blocks = new List<Rectangle>();
            for (int i = 0; i < Define.C_BlockRowNum; i++) {
                for (int j = 0; j < Define.C_BlockColumnNum; j++) {
                    int wX = Define.C_BlockFirstPositionX + j * (Define.C_BlockWidth + Define.C_BlockGap);
                    int wY = Define.C_BlockFirstPositionY + i * (Define.C_BlockHeight + Define.C_BlockGap);
                    var wBlock = new Rectangle(wX, wY, Define.C_BlockWidth, Define.C_BlockHeight);
                    this.Blocks.Add(wBlock);
                }
            }

            this.Bar = new Bar((vPictureBoxWidth - Define.C_BarWidth) / 2, Define.C_BarPositionY, Define.C_BarWidth, Define.C_BarHeight, vPictureBoxWidth);
        }
        /// <summary>
        /// 残弾をポップする
        /// </summary>
        private void PopBall() {
            this.Ball = this.Balls.Pop();
        }
        /// <summary>
        /// 弾の当たり判定
        /// </summary>
        /// <param name="vPictureBox1">描画先</param>
        /// <param name="vLabelScore">スコアラベル</param>
        public void Bound(int vPictureBoxWidth, int vPictureBoxHeight) {
            //左右の壁に当たった際の跳ね返り
            if (this.Ball.Position.X + Define.C_BallRadius > vPictureBoxWidth || this.Ball.Position.X - Define.C_BallRadius < 0) {
                this.Ball.Reverse(Orientation.Horizontal);
            }
            //上の壁に当たった際の跳ね返り
            if (this.Ball.Position.Y - Define.C_BallRadius < 0) {
                this.Ball.Reverse(Orientation.Vertical);
            }
            //下の壁に当たってゲームオーバー
            if (this.Ball.Position.Y + Define.C_BallRadius >= vPictureBoxHeight) {
                if (this.Balls.Count == 0) {
                    this.Status = Status.GameOver;
                    return;
                }
                this.Status = Status.Ready;
                this.PopBall();
                return;
            }
            //バーでのランダム跳ね返り
            this.BarVsBall(this.Bar.Rect.X, this.Ball);

            //ブロックに当たった際の跳ね返り・加速とブロックを消す処理
            for (int i = 0; i < this.Blocks.Count; i++) {
                Orientation? wCollision = BlockVsCircle(this.Blocks[i], this.Ball);
                if (wCollision != null) {
                    this.Ball.Reverse(wCollision.Value);
                    this.Ball.Accelerate();
                    this.Blocks.RemoveAt(i);
                    this.Score += Define.C_ScoreAddition;
                    break;
                }
            }
            if (this.Blocks.Any()) {
                this.Status = Status.Playing;
                return;
            } else {
                this.Status = Status.Clear;
                return;
            }
        }

        /// <summary>
        /// 直線と弾の当たり判定
        /// </summary>
        /// <param name="vPoint1">直線の左端の座標</param>
        /// <param name="vPoint2">直線の右端の座標</param>
        /// <param name="vBallCenter">弾の中心座標</param>
        /// <param name="vBallRadius">弾の半径</param>
        /// <returns>弾が直線に当たったらTrue</returns>
        private bool IsBallCollidedLine(Vector vPoint1, Vector vPoint2, Vector vBallCenter, int vBallRadius) {
            // 直線の方向ベクトル
            Vector wLineDir = (vPoint2 - vPoint1);
            // 直線の法線ベクトル
            var wN = new Vector(wLineDir.Y, -wLineDir.X);
            wN.Normalize();

            //直線の左端から弾の中心に向かうベクトル
            Vector wDirection1 = vBallCenter - vPoint1;
            //直線の右端から弾の中心に向かうベクトル
            Vector wDirection2 = vBallCenter - vPoint2;

            //内積を求めるローカルメソッド
            double DotProduct(Vector vA, Vector vB) => vA.X * vB.X + vA.Y * vB.Y;

            //直線と弾の間の距離
            double wDistance = Math.Abs(DotProduct(wDirection1, wN));
            //ベクトルwDirection1とベクトルwLineDirの内積
            double wA1 = DotProduct(wDirection1, wLineDir);
            //ベクトルwDirection2とベクトルwLineDirの内積
            double wA2 = DotProduct(wDirection2, wLineDir);

            return (wA1 * wA2 < 0 && wDistance < vBallRadius) ? true : false;
        }

        /// <summary>
        /// 弾がバーに当たったときの判定
        /// </summary>
        /// <param name="vBarX">バーのX座標</param>
        /// <param name="vBall">弾のインスタンス</param>
        private void BarVsBall(int vBarX, Ball vBall) {
            var wRandomAngle = new Random();
            if (IsBallCollidedLine(new Vector(vBarX, Define.C_BarPositionY),
                new Vector(vBarX + Define.C_BarWidth / 5, Define.C_BarPositionY), vBall.Position, Define.C_BallRadius)) {

                vBall.ChangeDirection(wRandomAngle.Next(-70, -59));
            }
            if (IsBallCollidedLine(new Vector(vBarX + Define.C_BarWidth / 5, Define.C_BarPositionY),
                new Vector(vBarX + Define.C_BarWidth * 2 / 5, Define.C_BarPositionY), vBall.Position, Define.C_BallRadius)) {
                vBall.ChangeDirection(wRandomAngle.Next(-35, -29));
            }
            if (IsBallCollidedLine(new Vector(vBarX + Define.C_BarWidth * 2 / 5, Define.C_BarPositionY),
                new Vector(vBarX + Define.C_BarWidth * 3 / 5, Define.C_BarPositionY), vBall.Position, Define.C_BallRadius)) {
                vBall.ChangeDirection(wRandomAngle.Next(-10, 11));
            }
            if (IsBallCollidedLine(new Vector(vBarX + Define.C_BarWidth * 3 / 5, Define.C_BarPositionY),
                new Vector(vBarX + Define.C_BarWidth * 4 / 5, Define.C_BarPositionY), vBall.Position, Define.C_BallRadius)) {
                vBall.ChangeDirection(wRandomAngle.Next(30, 36));
            }
            if (IsBallCollidedLine(new Vector(vBarX + Define.C_BarWidth * 4 / 5, Define.C_BarPositionY),
                new Vector(vBarX + Define.C_BarWidth, Define.C_BarPositionY), vBall.Position, Define.C_BallRadius)) {
                vBall.ChangeDirection(wRandomAngle.Next(60, 71));
            }
        }

        /// <summary>
        /// 弾とブロックの当たり判定
        /// </summary>
        /// <param name="vBlock">ブロック</param>
        /// <param name="vBall">弾</param>
        /// <returns>ブロックとの当たり判定</returns>
        private Orientation? BlockVsCircle(Rectangle vBlock, Ball vBall) {
            //上辺と下辺での当たり判定
            if ((vBall.Speed.Y > 0 && IsBallCollidedLine(new Vector(vBlock.Left, vBlock.Top), new Vector(vBlock.Right, vBlock.Top), vBall.Position, Define.C_BallRadius)
                || (vBall.Speed.Y < 0 && IsBallCollidedLine(new Vector(vBlock.Left, vBlock.Bottom), new Vector(vBlock.Right, vBlock.Bottom), vBall.Position, Define.C_BallRadius)))) {
                return Orientation.Vertical;
            }
            //右辺と左辺での当たり判定
            if ((vBall.Speed.X < 0 && IsBallCollidedLine(new Vector(vBlock.Right, vBlock.Top), new Vector(vBlock.Right, vBlock.Bottom), vBall.Position, Define.C_BallRadius)
                || (vBall.Speed.X >= 0 && IsBallCollidedLine(new Vector(vBlock.Left, vBlock.Top), new Vector(vBlock.Left, vBlock.Bottom), vBall.Position, Define.C_BallRadius)))) {
                return Orientation.Horizontal;
            }
            return null;
        }
    }
}
