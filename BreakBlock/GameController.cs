using System;
using System.Collections.Generic;
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
        public List<IBlock> Blocks { get; set; }
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
        public GameController(int vScreenWidth, int vScreenHeight) {
            FScreenWidth = vScreenWidth;
            FScreenHeight = vScreenHeight;
        }

        /// <summary>
        /// コントローラの初期化
        /// </summary>
        /// <param name="vSetting">ゲーム設定</param>
        public void Initialize(GameSetting vSetting) {
            this.Score = 0;

            this.Blocks = new List<IBlock>();
            int wBlockHeight = (Define.C_BlockDrawingAreaHeight / vSetting.BlockRowNum) * 93 / 100;
            int wBlockWidth = (Define.C_BlockDrawingAreaWidth / vSetting.BlockColumnNum) * 93 / 100;
            int wBlockGap = (Define.C_BlockDrawingAreaWidth / vSetting.BlockColumnNum) / 10;
            //メタルブロックの位置をランダム生成
            var wMetalIndexList = Enumerable.Range(0, vSetting.BlockRowNum * vSetting.BlockColumnNum).OrderBy(x => Guid.NewGuid()).Take(vSetting.MetalBlockNum).ToList();
            int wCount = 0;
            var wRandomForMetalBlock = new Random();
            for (int i = 0; i < vSetting.BlockRowNum; i++) {
                for (int j = 0; j < vSetting.BlockColumnNum; j++) {
                    int wX = Define.C_BlockFirstPositionX + j * (wBlockWidth + wBlockGap);
                    int wY = Define.C_BlockFirstPositionY + i * (wBlockHeight + wBlockGap);
                    IBlock wBlock;
                    if (wMetalIndexList.Exists(x => x == wCount)) {
                        wBlock = new MetalBlock(wX, wY, wBlockWidth, wBlockHeight, wRandomForMetalBlock.Next(1, 4));
                    } else {
                        wBlock = new NormalBlock(wX, wY, wBlockWidth, wBlockHeight);
                    }
                    this.Blocks.Add(wBlock);
                    wCount++;
                }
            }

            var wRandomForBall = new Random();
            var wMatrixAffine = new Matrix();
            var wLaunchSpeed = new Vector(0, Define.C_LaunchVelocity);
            FBalls = new Stack<IBall>();
            for (int i = 0; i < vSetting.BallNum; i++) {
                float wAngle = wRandomForBall.Next(Define.C_LaunchAngleMin, Define.C_LaunchAngleMax);
                if (wRandomForBall.Next() % 2 == 0) wAngle *= -1;
                wMatrixAffine.Rotate(wAngle);
                wLaunchSpeed = Vector.Multiply(wLaunchSpeed, wMatrixAffine);
                FBalls.Push(new Ball(FScreenWidth / 2, Define.C_BarPositionY - vSetting.BallRadius, vSetting.BallRadius, wLaunchSpeed));
            }
            this.Ball = FBalls.Pop();

            this.Bar = new Bar((FScreenWidth - vSetting.BarWidth) / 2, Define.C_BarPositionY, vSetting.BarWidth, vSetting.BarHeight, FScreenWidth);
        }

        /// <summary>
        /// 跳ね返り処理
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

            //ブロックでの跳ね返り
            foreach (IBlock wBlock in this.Blocks) {
                Orientation? wCollision = this.Ball.VsBlock(wBlock.Rect);
                if (wCollision != null) {
                    this.Ball.Reverse(wCollision.Value);
                    this.Ball.Accelerate();
                    if (wBlock.Endurance > 0) {
                        wBlock.Endurance--;
                    }else if(wBlock.Endurance == 0) {
                        this.Blocks.Remove(wBlock);
                        this.Score += wBlock.ScoreAddition;
                    }
                    break;
                }
            }
            if (!this.Blocks.Any()) {
                this.Status = Status.Clear;
                this.Score += this.BallCount * Define.C_ScoreBonus;
            }
        }
    }
}
