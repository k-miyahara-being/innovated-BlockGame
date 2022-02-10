using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media;

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
        public IBall Ball { get; set; }
        /// <summary>
        /// 弾の数
        /// </summary>
        public int BallCount => FBalls.Count; 
        /// <summary>
        /// ブロックのリスト
        /// </summary>
        public List<Rectangle> Blocks { get; set; }
        /// <summary>
        /// バー
        /// </summary>
        public Bar Bar { get; set; }

        private Stack<IBall> FBalls;
        private readonly int FScreenWidth;
        private readonly int FScreenHeight;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public GameController(int vScreenWidth, int vScreenHeight, int vInitialBallNum, int vInitialBlockRowNum, int vInitialBlockColumnNum, int vBarWidth, int vBarHeight) {
            FScreenWidth = vScreenWidth;
            FScreenHeight = vScreenHeight;
            this.Initialize(vInitialBallNum, vInitialBlockRowNum, vInitialBlockColumnNum, vBarWidth, vBarHeight);
        }
        /// <summary>
        /// コントローラの初期化
        /// </summary>
        public void Initialize(int vInitialBallNum, int vInitialBlockRowNum, int vInitialBlockColumnNum, int vBarWidth, int vBarHeight) {
            this.Score = 0;

            this.Blocks = new List<Rectangle>();
            int wBlockHeight = (Define.C_BlockDrawingAreaHeight / vInitialBlockRowNum) * 93 / 100;
            int wBlockWidth = (Define.C_BlockDrawingAreaWidth / vInitialBlockColumnNum) * 93 / 100;
            int wBlockGap = (Define.C_BlockDrawingAreaWidth / vInitialBlockColumnNum) / 10;
            for (int i = 0; i < vInitialBlockRowNum; i++) {
                for (int j = 0; j < vInitialBlockColumnNum; j++) {
                    int wX = Define.C_BlockFirstPositionX + j * (wBlockWidth + wBlockGap);
                    int wY = Define.C_BlockFirstPositionY + i * (wBlockHeight + wBlockGap);
                    var wBlock = new Rectangle(wX, wY, wBlockWidth, wBlockHeight);
                    this.Blocks.Add(wBlock);
                }
            }

            var wRandom = new Random();
            var wMatrixAffine = new Matrix();
            var wLaunchVelocity = new Vector(0, Define.C_LaunchVelocity);
            int wBallRadius = wBlockHeight * 40 / 100;
            FBalls = new Stack<IBall>();
            for (int i = 0; i < vInitialBallNum; i++) {
                float wAngle = wRandom.Next(Define.C_LaunchAngleMin, Define.C_LaunchAngleMax);
                if (wRandom.Next() % 2 == 0) {
                    wAngle *= -1;
                } else {
                    wAngle *= 1;
                }
                wMatrixAffine.Rotate(wAngle);
                wLaunchVelocity = Vector.Multiply(wLaunchVelocity, wMatrixAffine);
                FBalls.Push(new Ball(FScreenWidth / 2, Define.C_BarPositionY - wBallRadius, wBallRadius, wLaunchVelocity));
            }
            this.Ball = FBalls.Pop();

            this.Bar = new Bar((FScreenWidth - vBarWidth) / 2, Define.C_BarPositionY, vBarWidth, vBarHeight, FScreenWidth);
        }

        /// <summary>
        /// 弾の当たり判定
        /// </summary>
        public void Bound() {
            //壁での跳ね返り
            switch (this.Ball.VsWall(FScreenWidth, FScreenHeight)) {
                case null:
                    break;
                case HitPointWall.Left:
                case HitPointWall.Right:
                    this.Ball.Reverse(Orientation.Horizontal);
                    return;
                case HitPointWall.Top:
                    this.Ball.Reverse(Orientation.Vertical);
                    return;
                case HitPointWall.Bottom:
                    this.Score -= Define.C_ScoreSubtraction;
                    if (this.BallCount == 0) {
                        this.Status = Status.GameOver;
                        return;
                    }
                    this.Status = Status.Ready;
                    this.Ball = FBalls.Pop();
                    return;
            }

            //バーでの跳ね返り
            var wRandomAngle = new Random();
            switch (this.Ball.VsBar(this.Bar)) {
                case null:
                    break;
                case HitPointBar.First:
                    this.Ball.ChangeDirection(wRandomAngle.Next(-70, -59));
                    return;
                case HitPointBar.Second:
                    this.Ball.ChangeDirection(wRandomAngle.Next(-35, -29));
                    return;
                case HitPointBar.Third:
                    this.Ball.ChangeDirection(wRandomAngle.Next(-10, 11));
                    return;
                case HitPointBar.Fourth:
                    this.Ball.ChangeDirection(wRandomAngle.Next(30, 36));
                    return;
                case HitPointBar.Fifth:
                    this.Ball.ChangeDirection(wRandomAngle.Next(60, 71));
                    return;
            }

            //ブロックに当たった際の跳ね返り・加速とブロックを消す処理
            for (int i = 0; i < this.Blocks.Count; i++) {
                Orientation? wCollision = this.Ball.VsBlock(this.Blocks[i]);
                if (wCollision != null) {
                    this.Ball.Reverse(wCollision.Value);
                    this.Ball.Accelerate();
                    this.Blocks.RemoveAt(i);
                    this.Score += Define.C_ScoreAddition;
                    break;
                }
            }
            if (!this.Blocks.Any()) {
                this.Status = Status.Clear;
                this.Score += this.BallCount * Define.C_ScoreBonus;
                return;
            }
        }
    }
}
