using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media;


namespace BreakBlock {
    public partial class BreakBlockForm : Form {
        private Bitmap FCanvas;
        private Ball FCurrentBall;
        private Stack<Ball> FBalls;
        private List<Rectangle> FBlocks = new List<Rectangle>();
        private Bar FBar;
        private Status FStatus;
        private int FScore = 0;
        private int FRemainingBallNum = 2;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public BreakBlockForm() => this.InitializeComponent();

        private void BreakBlockForm_Load(object sender, EventArgs e) => FCanvas = new Bitmap(PictureBox1.Width, PictureBox1.Height);

        private void ButtonStart_Click(object sender, EventArgs e) {
            ControlPlay();

            InitializeBlock();
            InitializeBar();

            FBalls = new Stack<Ball>();
            for (int i = 0; i < Define.C_BallNum; i++) {
                FBalls.Push(new Ball(PictureBox1.Width / 2, Define.C_BarPositionY - Define.C_BallRadius));
            }
            FCurrentBall = FBalls.Pop();
            Draw();
        }

        private void Timer_Tick(object sender, EventArgs e) {
            FCurrentBall.Move();
            FStatus = this.Bound();
            switch (FStatus) {
                case Status.Playing:
                    this.Draw();
                    break;
                case Status.Ready:
                    Timer.Stop();
                    InitializeBar();
                    this.Draw();
                    break;
                case Status.GameOver:
                    this.Finish(Brushes.Blue, () => LabelGameover.Visible = true);
                    break;
                case Status.Clear:
                    this.Finish(Brushes.Orange, () => LabelClear.Visible = true);
                    break;
            }
        }

        private void InitializeBlock() {
            for (int i = 0; i < Define.C_BlockRowNum; i++) {
                for (int j = 0; j < Define.C_BlockColumnNum; j++) {
                    int wX = Define.C_BlockFirstPositionX + j * (Define.C_BlockWidth + Define.C_BlockGap);
                    int wY = Define.C_BlockFirstPositionY + i * (Define.C_BlockHeight + Define.C_BlockGap);
                    var wBlock = new Rectangle(wX, wY, Define.C_BlockWidth, Define.C_BlockHeight);
                    FBlocks.Add(wBlock);
                }
            }
        }

        private void InitializeBar() => FBar = new Bar((PictureBox1.Width - Define.C_BarWidth) / 2, Define.C_BarPositionY, Define.C_BarWidth, Define.C_BarHeight, PictureBox1.Width);
        

        private void FormBreakBlock_KeyDown(object sender, KeyEventArgs e) {
            e.Handled = true;
            switch (e.KeyData) {
                case Keys.Space:
                    if (FStatus != Status.Ready) break;
                    FStatus = Status.Playing;
                    Timer.Start();
                    break;
                case Keys.J:
                case Keys.Right:
                case Keys.S:
                    MoveBarAndBall(DirectionX.Right);
                    break;
                case Keys.F:
                case Keys.Left:
                case Keys.A:
                    MoveBarAndBall(DirectionX.Left);
                    break;
            }
            void MoveBarAndBall(DirectionX vDirectionX) {
                switch (FStatus) {
                    case Status.Playing:
                        FBar.MoveBar(vDirectionX);
                        Draw();
                        break;
                    case Status.Ready:
                        FCurrentBall.Move(new Vector(FBar.MoveBar(vDirectionX), 0));
                        Draw();
                        break;
                }
            }
        }

        private void Draw() {
            using (var g = Graphics.FromImage(FCanvas)) {
                //弾をきれいな円に描くプロパティ
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.Clear(this.BackColor);
                //弾をbrushColorで指定された色で描く
                g.FillEllipse(Brushes.Red, (float)(FCurrentBall.Position.X - Define.C_BallRadius), (float)(FCurrentBall.Position.Y - Define.C_BallRadius), Define.C_BallRadius * 2, Define.C_BallRadius * 2);
                g.FillEllipse(Brushes.Red, Define.C_SmallBallX, Define.C_SmallBallY, Define.C_SmallBallRadius * 2, Define.C_SmallBallRadius * 2);
                for (int i = 0; i < FBlocks.Count; i++) {
                    g.FillRectangle(Brushes.LightBlue, FBlocks[i]);
                }
                g.FillRectangle(Brushes.Yellow, FBar.Rect);
            }
            PictureBox1.Image = FCanvas;
        }

        /// <summary>
        /// 跳ね返り処理
        /// </summary>
        private Status Bound() {
            //左右の壁に当たった際の跳ね返り
            if (FCurrentBall.Position.X + Define.C_BallRadius > PictureBox1.Width || FCurrentBall.Position.X - Define.C_BallRadius < 0) {
                FCurrentBall.Reverse(Orientation.Horizontal);
            }
            //上の壁に当たった際の跳ね返り
            if (FCurrentBall.Position.Y - Define.C_BallRadius < 0) {
                FCurrentBall.Reverse(Orientation.Vertical);
            }
            //下の壁に当たってゲームオーバー
            if (FCurrentBall.Position.Y + Define.C_BallRadius >= PictureBox1.Height) {
                if (FBalls.Count == 0) return Status.GameOver;
                
                FCurrentBall = FBalls.Pop();
                FRemainingBallNum -= 1;
                remainingBallNum.Text = FRemainingBallNum.ToString(); 
                return Status.Ready;
            }
            //バーの左部分に当たった際の跳ね返り
            if (LineVsCircle(new Vector(FBar.Rect.X, Define.C_BarPositionY),
                new Vector(FBar.Rect.X + Define.C_BarWidth / 3, Define.C_BarPositionY), FCurrentBall.Position, Define.C_BallRadius)) {
                FCurrentBall.Reverse(Orientation.Vertical);
                if (FCurrentBall.Speed.X > 0) {
                    FCurrentBall.Reverse(Orientation.Horizontal);
                }
            }
            //バーの右部分に当たった際の跳ね返り
            if (LineVsCircle(new Vector(FBar.Rect.X + 2 * Define.C_BarWidth / Define.C_BarSection, Define.C_BarPositionY),
                new Vector(FBar.Rect.X + Define.C_BarWidth, Define.C_BarPositionY), FCurrentBall.Position, Define.C_BallRadius)) {
                FCurrentBall.Reverse(Orientation.Vertical);
                if (FCurrentBall.Speed.X < 0) {
                    FCurrentBall.Reverse(Orientation.Horizontal);
                }
            }
            //バーの真ん中部分に当たった際の跳ね返り
            if (LineVsCircle(new Vector(FBar.Rect.X + Define.C_BarWidth / Define.C_BarSection, Define.C_BarPositionY),
                new Vector(FBar.Rect.X + 2 * Define.C_BarWidth / Define.C_BarSection, Define.C_BarPositionY), FCurrentBall.Position, Define.C_BallRadius)) {
                FCurrentBall.Reverse(Orientation.Vertical);            }

            //バーでのランダム跳ね返り
            this.BarVsBall();

            //ブロックに当たった際の跳ね返り・加速とブロックを消す処理
            for (int i = 0; i < FBlocks.Count; i++) {
                Orientation? collision = BlockVsCircle(FBlocks[i], FCurrentBall);
                if (collision != null) {
                    FCurrentBall.Reverse(collision.Value);
                    FCurrentBall.Accelerate();
                    FBlocks.RemoveAt(i);
                    FScore += Define.C_ScoreAddition;
                    LabelScore.Text = FScore.ToString();
                    break;
                }
            }
            return FBlocks.Any() ? Status.Playing : Status.Clear;
        }

        /// <summary>
        /// 内積の計算
        /// </summary>
        /// <param name="vA">ベクトルの座標</param>
        /// <param name="vB">ベクトルの座標</param>
        /// <returns>内積の計算結果</returns>
        double DotProduct(Vector vA, Vector vB) => vA.X * vB.X + vA.Y * vB.Y;

        /// <summary>
        /// 直線と弾の当たり判定
        /// </summary>
        /// <param name="vPoint1">直線の左端の座標</param>
        /// <param name="vPoint2">直線の右端の座標</param>
        /// <param name="vBallCenter">弾の中心座標</param>
        /// <param name="vBallRadius">弾の半径</param>
        /// <returns>直線との当たり判定</returns>
        bool LineVsCircle(Vector vPoint1, Vector vPoint2, Vector vBallCenter, float vBallRadius) {
            // 直線の方向ベクトル
            Vector wLineDir = (vPoint2 - vPoint1);
            // 直線の法線ベクトル
            var wN = new Vector(wLineDir.Y, -wLineDir.X);
            wN.Normalize();

            //直線の左端から弾の中心に向かうベクトル
            Vector wDirection1 = vBallCenter - vPoint1;
            //直線の右端から弾の中心に向かうベクトル
            Vector wDirection2 = vBallCenter - vPoint2;

            //直線と弾の間の距離
            double wDistance = Math.Abs(DotProduct(wDirection1, wN));
            //ベクトルwDirection1とベクトルwLineDirの内積
            double wA1 = DotProduct(wDirection1, wLineDir);
            //ベクトルwDirection2とベクトルwLineDirの内積
            double wA2 = DotProduct(wDirection2, wLineDir);

            return (wA1 * wA2 < 0 && wDistance < vBallRadius) ? true : false;
        }
        /// <summary>
        /// バーでの弾の跳ね返り
        /// </summary>
        private void BarVsBall() {
            var wMatrixAffine = new System.Windows.Media.Matrix();
            var wRandomAngle = new Random();
            if (LineVsCircle(new Vector(FBar.Rect.X, Define.C_BarPositionY),
                new Vector(FBar.Rect.X + Define.C_BarWidth / 5, Define.C_BarPositionY), FCurrentBall.Position, Define.C_BallRadius)) {
                wMatrixAffine.Rotate(wRandomAngle.Next(-70, -59));
                FCurrentBall.ChangeDirection(wMatrixAffine);
            }
            if (LineVsCircle(new Vector(FBar.Rect.X + Define.C_BarWidth / 5, Define.C_BarPositionY),
                new Vector(FBar.Rect.X + Define.C_BarWidth * 2 / 5, Define.C_BarPositionY), FCurrentBall.Position, Define.C_BallRadius)) {
                wMatrixAffine.Rotate(wRandomAngle.Next(-35, -29));
                FCurrentBall.ChangeDirection(wMatrixAffine);
            }
            if (LineVsCircle(new Vector(FBar.Rect.X + Define.C_BarWidth * 2 / 5, Define.C_BarPositionY),
                new Vector(FBar.Rect.X + Define.C_BarWidth * 3 / 5, Define.C_BarPositionY), FCurrentBall.Position, Define.C_BallRadius)) {
                wMatrixAffine.Rotate(wRandomAngle.Next(-10, 11));
                FCurrentBall.ChangeDirection(wMatrixAffine);
            }
            if (LineVsCircle(new Vector(FBar.Rect.X + Define.C_BarWidth * 3 / 5, Define.C_BarPositionY),
                new Vector(FBar.Rect.X + Define.C_BarWidth * 4 / 5, Define.C_BarPositionY), FCurrentBall.Position, Define.C_BallRadius)) {
                wMatrixAffine.Rotate(wRandomAngle.Next(30, 36));
                FCurrentBall.ChangeDirection(wMatrixAffine);
            }
            if (LineVsCircle(new Vector(FBar.Rect.X + Define.C_BarWidth * 4 / 5, Define.C_BarPositionY),
                new Vector(FBar.Rect.X + Define.C_BarWidth, Define.C_BarPositionY), FCurrentBall.Position, Define.C_BallRadius)) {
                wMatrixAffine.Rotate(wRandomAngle.Next(60, 71));
                FCurrentBall.ChangeDirection(wMatrixAffine);
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
            if ((vBall.Speed.Y > 0 && LineVsCircle(new Vector(vBlock.Left, vBlock.Top), new Vector(vBlock.Right, vBlock.Top), vBall.Position, Define.C_BallRadius)
                || (vBall.Speed.Y < 0 && LineVsCircle(new Vector(vBlock.Left, vBlock.Bottom), new Vector(vBlock.Right, vBlock.Bottom), vBall.Position, Define.C_BallRadius)))) {
                return Orientation.Vertical;
            }
            //右辺と左辺での当たり判定
            if ((vBall.Speed.X < 0 && LineVsCircle(new Vector(vBlock.Right, vBlock.Top), new Vector(vBlock.Right, vBlock.Bottom), vBall.Position, Define.C_BallRadius)
                || (vBall.Speed.X >= 0 && LineVsCircle(new Vector(vBlock.Left, vBlock.Top), new Vector(vBlock.Left, vBlock.Bottom), vBall.Position, Define.C_BallRadius)))) {
                return Orientation.Horizontal;
            }
            return null;
        }

        private void Finish(Brush vColor, Action vAction) {
            Timer.Stop();
            using (var g = Graphics.FromImage(FCanvas)) {
                g.Clear(this.BackColor);
                g.FillEllipse(vColor, FCanvas.Width / 2 - 100, FCanvas.Height / 2 - 100, 200, 100);
            }
            PictureBox1.Image = FCanvas;
            ControlFinish(vAction);
        }

        private void ButtonContinue_Click(object vSender, EventArgs vE) {
            using (var g = Graphics.FromImage(FCanvas)) {
                g.Clear(this.BackColor);
            }
            PictureBox1.Image = FCanvas;
            InithalizeAll();
        }

        private void ControlPlay() {
            FStatus = Status.Ready;
            ButtonStart.Visible = false;
            TextScore.Visible = true;
            LabelScore.Text = FScore.ToString();
            LabelScore.Visible = true;
            remainingBallNum.Text = FRemainingBallNum.ToString();
            remainingBallNum.Visible = true;
            label.Visible = true;
        }

        private void ControlFinish(Action vAction) {
            TextScore.Visible = false;
            LabelScore.Visible = false;
            remainingBallNum.Visible = false;
            label.Visible = false;

            vAction?.Invoke();
            ResultLabelScore.Text = FScore.ToString();
            ResultTextScore.Visible = true;
            ResultLabelScore.Visible = true;
            ButtonContinue.Visible = true;
            ButtonContinue.Focus();
        }

        private void InithalizeAll() {
            LabelClear.Visible = false;
            LabelGameover.Visible = false;
            ButtonContinue.Visible = false;

            FBlocks.Clear();

            ResultTextScore.Visible = false;
            ResultLabelScore.Visible = false;
            FScore = 0;
            FRemainingBallNum = 2;

            ButtonStart.Visible = true;
            ButtonStart.Focus();
        }
    }
}
