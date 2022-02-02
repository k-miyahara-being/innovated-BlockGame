using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Windows;
using System.Windows.Forms;

namespace BreakBlock {
    public partial class BreakBlockForm : Form {
        private Bitmap FCanvas;
        private GameController FGameController;
        private Brush[] FColors;
        private int FColorIndex = 0;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public BreakBlockForm() => this.InitializeComponent();

        private void BreakBlockForm_Load(object sender, EventArgs e) {
            FCanvas = new Bitmap(PictureBox1.Width, PictureBox1.Height);
            FGameController = new GameController(PictureBox1);
        }

        private void ButtonStart_Click(object sender, EventArgs e) {
            FGameController.PopBall();
            ControlPlay();
            Draw();
        }

        private void Timer_Tick(object sender, EventArgs e) {
            //FCurrentBall.Move();
            FGameController.Ball.Move();
            FGameController.Bound(PictureBox1, LabelScore);
            switch (FGameController.Status) {
                case Status.Playing:
                    this.Draw();
                    break;
                case Status.Ready:
                    Timer.Stop();
                    FGameController.Bar = new Bar((PictureBox1.Width - Define.C_BarWidth) / 2, Define.C_BarPositionY, Define.C_BarWidth, Define.C_BarHeight, PictureBox1.Width);
                    FGameController.PopBall();
                    remainingBallNum.Text = FGameController.Balls.Count.ToString();
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

        private void FormBreakBlock_KeyDown(object sender, KeyEventArgs e) {
            e.Handled = true;
            switch (e.KeyData) {
                case Keys.Space:
                    if (FGameController.Status != Status.Ready) break;
                    FGameController.Status = Status.Playing;
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
            if (FGameController.Status == Status.Ready || FGameController.Status == Status.Playing) {
                int wMoveDistance = e.X - FGameController.Bar.Rect.X - Define.C_BarWidth / 2;
                MoveBarAndBall(wMoveDistance);
            }
        }

        private void MoveBarAndBall(int vMoveDistance) {
            switch (FGameController.Status) {
                case Status.Playing:
                    FGameController.Bar.MoveBar(vMoveDistance);
                    Draw();
                    break;
                case Status.Ready:
                    FGameController.Ball.Move(new Vector(FGameController.Bar.MoveBar(vMoveDistance), 0));
                    Draw();
                    break;
            }
        }

        private void PictureBox1_MouseDown(object sender, MouseEventArgs e) {
            if (FGameController.Status == Status.Ready) {
                FGameController.Status = Status.Playing;
                Timer.Start();
            }
        }

        private void Draw() {
            using (var g = Graphics.FromImage(FCanvas)) {
                //弾をきれいな円に描くプロパティ
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.Clear(this.BackColor);
                //弾をbrushColorで指定された色で描く
                g.FillEllipse(Brushes.Red, (float)(FGameController.Ball.Position.X - Define.C_BallRadius), (float)(FGameController.Ball.Position.Y - Define.C_BallRadius), Define.C_BallRadius * 2, Define.C_BallRadius * 2);
                g.FillEllipse(Brushes.Red, Define.C_SmallBallX, Define.C_SmallBallY, Define.C_SmallBallRadius * 2, Define.C_SmallBallRadius * 2);
                for (int i = 0; i < FGameController.Block.Blocks.Count; i++) {
                    g.FillRectangle(Brushes.LightBlue, FGameController.Block.Blocks[i]);
                }
                g.FillRectangle(Brushes.Yellow, FGameController.Bar.Rect);
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
            FGameController.Status = Status.Ready;
            ButtonStart.Visible = false;
            TextScore.Visible = true;
            LabelScore.Text = "0";
            LabelScore.Visible = true;
            remainingBallNum.Text = FGameController.Balls.Count.ToString();
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
            ResultLabelScore.Text = FGameController.Score.ToString();
            ResultTextScore.Visible = true;
            ResultLabelScore.Visible = true;
            ButtonContinue.Visible = true;
            ButtonContinue.Focus();
        }

        private void InithalizeAll() {
            FGameController = new GameController(PictureBox1);
            LabelClear.Visible = false;
            LabelGameover.Visible = false;
            ButtonContinue.Visible = false;

            ResultTextScore.Visible = false;
            ResultLabelScore.Visible = false;

            ButtonStart.Visible = true;
            ButtonStart.Focus();
        }

    }
}
