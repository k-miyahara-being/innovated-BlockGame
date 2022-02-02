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
    class GameController {
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
        /// 弾のコレクション
        /// </summary>
        public Stack<Ball> Balls { get; set; }
        /// <summary>
        /// ブロック
        /// </summary>
        public Block Block { get; set; }
        /// <summary>
        /// バー
        /// </summary>
        public Bar Bar { get; set; }

        public GameController(PictureBox vPictureBox1) {
            this.Score = 0;
            this.Balls = new Stack<Ball>();
            for (int i = 0; i < Define.C_BallNum; i++) {
                this.Balls.Push(new Ball(vPictureBox1.Width / 2, Define.C_BarPositionY - Define.C_BallRadius));
            }
            this.Block = new Block(Define.C_BlockFirstPositionX, Define.C_BlockFirstPositionY, Define.C_BlockWidth, Define.C_BlockHeight, Define.C_BlockRowNum, Define.C_BlockColumnNum, Define.C_BlockGap);
            this.Bar = new Bar((vPictureBox1.Width - Define.C_BarWidth) / 2, Define.C_BarPositionY, Define.C_BarWidth, Define.C_BarHeight, vPictureBox1.Width);
        }

        /// <summary>
        /// 残弾をポップする
        /// </summary>
        public void PopBall() => this.Ball = this.Balls.Pop();

        /// <summary>
        /// 弾の当たり判定
        /// </summary>
        /// <param name="vPictureBox1">描画先</param>
        /// <param name="vLabelScore">スコアラベル</param>
        public void Bound(PictureBox vPictureBox1, Label vLabelScore) {
            //左右の壁に当たった際の跳ね返り
            if (this.Ball.Position.X + Define.C_BallRadius > vPictureBox1.Width || this.Ball.Position.X - Define.C_BallRadius < 0) {
                this.Ball.Reverse(Orientation.Horizontal);
            }
            //上の壁に当たった際の跳ね返り
            if (this.Ball.Position.Y - Define.C_BallRadius < 0) {
                this.Ball.Reverse(Orientation.Vertical);
            }
            //下の壁に当たってゲームオーバー
            if (this.Ball.Position.Y + Define.C_BallRadius >= vPictureBox1.Height) {
                if (this.Balls.Count == 0) {
                    this.Status = Status.GameOver;
                    return;
                }
                this.Status = Status.Ready;
                return;
            }
            //バーの左部分に当たった際の跳ね返り
            if (IsBallCollidedLine(new Vector(this.Bar.Rect.X, Define.C_BarPositionY),
                new Vector(this.Bar.Rect.X + Define.C_BarWidth / 3, Define.C_BarPositionY), this.Ball.Position, Define.C_BallRadius)) {
                this.Ball.Reverse(Orientation.Vertical);
                if (this.Ball.Speed.X > 0) {
                    this.Ball.Reverse(Orientation.Horizontal);
                }
            }
            //バーの右部分に当たった際の跳ね返り
            if (IsBallCollidedLine(new Vector(this.Bar.Rect.X + 2 * Define.C_BarWidth / Define.C_BarSection, Define.C_BarPositionY),
                new Vector(this.Bar.Rect.X + Define.C_BarWidth, Define.C_BarPositionY), this.Ball.Position, Define.C_BallRadius)) {
                this.Ball.Reverse(Orientation.Vertical);
                if (this.Ball.Speed.X < 0) {
                    this.Ball.Reverse(Orientation.Horizontal);
                }
            }
            //バーの真ん中部分に当たった際の跳ね返り
            if (IsBallCollidedLine(new Vector(this.Bar.Rect.X + Define.C_BarWidth / Define.C_BarSection, Define.C_BarPositionY),
                new Vector(this.Bar.Rect.X + 2 * Define.C_BarWidth / Define.C_BarSection, Define.C_BarPositionY), this.Ball.Position, Define.C_BallRadius)) {
                this.Ball.Reverse(Orientation.Vertical);
            }
            //バーでのランダム跳ね返り
            this.BarVsBall(this.Bar, this.Ball);

            //ブロックに当たった際の跳ね返り・加速とブロックを消す処理
            for (int i = 0; i < this.Block.Blocks.Count; i++) {
                Orientation? collision = BlockVsCircle(this.Block.Blocks[i], this.Ball);
                if (collision != null) {
                    this.Ball.Reverse(collision.Value);
                    this.Ball.Accelerate();
                    this.Block.Blocks.RemoveAt(i);
                    this.Score += Define.C_ScoreAddition;
                    vLabelScore.Text = this.Score.ToString();
                    break;
                }
            }
            if (this.Block.Blocks.Any()) {
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
        private bool IsBallCollidedLine(Vector vPoint1, Vector vPoint2, Vector vBallCenter, float vBallRadius) {
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
        /// 
        /// </summary>
        /// <param name="vBar"></param>
        /// <param name="vBall"></param>
        private void BarVsBall(Bar vBar, Ball vBall) {
            var wMatrixAffine = new System.Windows.Media.Matrix();
            var wRandomAngle = new Random();
            if (IsBallCollidedLine(new Vector(vBar.Rect.X, Define.C_BarPositionY),
                new Vector(vBar.Rect.X + Define.C_BarWidth / 5, Define.C_BarPositionY), vBall.Position, Define.C_BallRadius)) {
                wMatrixAffine.Rotate(wRandomAngle.Next(-70, -59));
                vBall.ChangeDirection(wMatrixAffine);
            }
            if (IsBallCollidedLine(new Vector(vBar.Rect.X + Define.C_BarWidth / 5, Define.C_BarPositionY),
                new Vector(vBar.Rect.X + Define.C_BarWidth * 2 / 5, Define.C_BarPositionY), vBall.Position, Define.C_BallRadius)) {
                wMatrixAffine.Rotate(wRandomAngle.Next(-35, -29));
                vBall.ChangeDirection(wMatrixAffine);
            }
            if (IsBallCollidedLine(new Vector(vBar.Rect.X + Define.C_BarWidth * 2 / 5, Define.C_BarPositionY),
                new Vector(vBar.Rect.X + Define.C_BarWidth * 3 / 5, Define.C_BarPositionY), vBall.Position, Define.C_BallRadius)) {
                wMatrixAffine.Rotate(wRandomAngle.Next(-10, 11));
                vBall.ChangeDirection(wMatrixAffine);
            }
            if (IsBallCollidedLine(new Vector(vBar.Rect.X + Define.C_BarWidth * 3 / 5, Define.C_BarPositionY),
                new Vector(vBar.Rect.X + Define.C_BarWidth * 4 / 5, Define.C_BarPositionY), vBall.Position, Define.C_BallRadius)) {
                wMatrixAffine.Rotate(wRandomAngle.Next(30, 36));
                vBall.ChangeDirection(wMatrixAffine);
            }
            if (IsBallCollidedLine(new Vector(vBar.Rect.X + Define.C_BarWidth * 4 / 5, Define.C_BarPositionY),
                new Vector(vBar.Rect.X + Define.C_BarWidth, Define.C_BarPositionY), vBall.Position, Define.C_BallRadius)) {
                wMatrixAffine.Rotate(wRandomAngle.Next(60, 71));
                vBall.ChangeDirection(wMatrixAffine);
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
