using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media;


namespace BreakBlock {
    public partial class BreakBlockForm : Form {
        private Bitmap FCanvas;
        private Ball FCurrentBall;
        private Stack<Ball> FBalls;
        private List<Rectangle> FBlocks = new List<Rectangle>();
        private GameController FGamecontroller;
        private Bar FBar;
        private Status FStatus;
        private int FRemainingBallNum = 2;
        private Brush[] FColors;
        private int FColorIndex = 0;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public BreakBlockForm() => this.InitializeComponent();

        private void BreakBlockForm_Load(object sender, EventArgs e) => FCanvas = new Bitmap(PictureBox1.Width, PictureBox1.Height);

        private void ButtonStart_Click(object sender, EventArgs e) {
            ControlPlay();

            InitializeBlock();
            InitializeBar();
            FGamecontroller = new GameController();

            FBalls = new Stack<Ball>();
            for (int i = 0; i < Define.C_BallNum; i++) {
                FBalls.Push(new Ball(PictureBox1.Width / 2, Define.C_BarPositionY - Define.C_BallRadius));
            }
            FCurrentBall = FBalls.Pop();
            Draw();
        }

        private void Timer_Tick(object sender, EventArgs e) {
            FCurrentBall.Move();
            FStatus = FGamecontroller.Bound(FCurrentBall, FBlocks, FBalls, FBar, PictureBox1, LabelScore);
            switch (FStatus) {
                case Status.Playing:
                    this.Draw();
                    break;
                case Status.Ready:
                    Timer.Stop();
                    InitializeBar();
                    FCurrentBall = FBalls.Pop();
                    FRemainingBallNum -= 1;
                    remainingBallNum.Text = FRemainingBallNum.ToString();
                    this.Draw();
                    break;
                case Status.GameOver:
                    this.Finish(Define.GameOverColors, () => LabelGameover.Visible = true);
                    break;
                case Status.Clear:
                    this.Finish(Define.ClearColors, () => LabelClear.Visible = true);
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
                    MoveBarAndBall(Define.C_BarMoveDistance);
                    break;
                case Keys.F:
                case Keys.Left:
                case Keys.A:
                    MoveBarAndBall(-1 * Define.C_BarMoveDistance);
                    break;
            }
        }

        private void PictureBox1_MouseMove(object sender, MouseEventArgs e) {
            if (FStatus == Status.Ready || FStatus == Status.Playing) {
                int wMoveDistance = e.X - FBar.Rect.X - Define.C_BarWidth / 2;
                MoveBarAndBall(wMoveDistance);
            }
        }

        private void MoveBarAndBall(int vMoveDistance) {
            switch (FStatus) {
                case Status.Playing:
                    FBar.MoveBar(vMoveDistance);
                    Draw();
                    break;
                case Status.Ready:
                    FCurrentBall.Move(new Vector(FBar.MoveBar(vMoveDistance), 0));
                    Draw();
                    break;
            }
        }

        private void PictureBox1_MouseDown(object sender, MouseEventArgs e) {
            if (FStatus == Status.Ready) {
                FStatus = Status.Playing;
                Timer.Start();
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

        private void Finish(Brush[] vColors, Action vAction) {
            Timer.Stop();
            FColors = vColors;
            AnimationTimer.Start();
            //画面をリフレッシュする前にコントロールが表示されてしまうため100ms待つ
            Thread.Sleep(100);
            ControlFinish(vAction);
        }

        private void DrawFinish(Brush vColor) {
            using (var g = Graphics.FromImage(FCanvas)) {
                g.Clear(this.BackColor);
                g.FillEllipse(vColor, FCanvas.Width / 2 - 100, FCanvas.Height / 2 - 100, 200, 100);
            }
            PictureBox1.Image = FCanvas;
        }

        private void AnimationTimer_Tick(object sender, EventArgs e) {
            DrawFinish(FColors[FColorIndex % 4]);
            FColorIndex++;
        }

        private void ButtonContinue_Click(object vSender, EventArgs vE) {
            AnimationTimer.Stop();
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
            LabelScore.Text = "0";
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
            PictureBox1.Controls.Add(LabelGameover);
            PictureBox1.Controls.Add(LabelClear);
            ResultLabelScore.Text = FGamecontroller.Score.ToString();
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
            FRemainingBallNum = 2;

            ButtonStart.Visible = true;
            ButtonStart.Focus();
        }

    }
}
