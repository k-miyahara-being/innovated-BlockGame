using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.Serialization.Json;
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
        public BreakBlockForm() {
            this.InitializeComponent();
            FGameController = new GameController(PictureBox1.Width, PictureBox1.Height);
            FCanvas = new Bitmap(PictureBox1.Width, PictureBox1.Height);
            //デフォルトで難易度Normalを選択
            DifficultyBox.SelectedIndex = 1;
        }

        private GameSetting GetSettings() {
            using (var wStream = new FileStream($@"../../{DifficultyBox.Text}Settings.json", FileMode.Open, FileAccess.Read)) {
                var wSerializer = new DataContractJsonSerializer(typeof(GameSetting));
                return wSerializer.ReadObject(wStream) as GameSetting;
            }
        }

        private void ButtonStart_Click(object sender, EventArgs e) {
            FGameController.Initialize(this.GetSettings());
            #region プレイ画面へ遷移
            FGameController.Status = Status.Ready;
            ButtonStart.Visible = false;
            DifficultyBox.Visible = false;
            TextScore.Visible = true;
            LabelScore.Text = FGameController.Score.ToString();
            LabelScore.Visible = true;
            remainingBallNum.Text = FGameController.BallCount.ToString();
            remainingBallNum.Visible = true;
            label.Visible = true;
            #endregion
            Draw();
        }

        private void Timer_Tick(object sender, EventArgs e) {
            FGameController.Ball.Move();
            FGameController.Bound();
            LabelScore.Text = FGameController.Score.ToString();
            switch (FGameController.Status) {
                case Status.Playing:
                    this.Draw();
                    break;
                case Status.Ready:
                    Timer.Stop();
                    FGameController.Bar = new Bar((PictureBox1.Width - FGameController.Bar.Rect.Width) / 2, Define.C_BarPositionY, FGameController.Bar.Rect.Width, FGameController.Bar.Rect.Height, PictureBox1.Width);
                    remainingBallNum.Text = FGameController.BallCount.ToString();
                    this.Draw();
                    break;
                case Status.GameOver:
                    this.ShowFinishView(Define.GameOverColors, () => LabelGameover.Visible = true);
                    break;
                case Status.Clear:
                    this.ShowFinishView(Define.ClearColors, () => LabelClear.Visible = true);
                    break;
            }
        }
        #region キー操作
        private void FormBreakBlock_KeyDown(object sender, KeyEventArgs e) {
            e.Handled = true;
            switch (e.KeyData) {
                case Keys.F4:
                    if (FGameController.Status != Status.Start) break;
                    DifficultyBox.DroppedDown = true;
                    break;
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
        #endregion

        private void PictureBox1_MouseMove(object sender, MouseEventArgs e) {
            if (FGameController.Status == Status.Ready || FGameController.Status == Status.Playing) {
                int wMoveDistance = e.X - FGameController.Bar.Rect.X - FGameController.Bar.Rect.Width / 2;
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
            if (FGameController.Status != Status.Ready) return;
            FGameController.Status = Status.Playing;
            Timer.Start();
        }

        private void Draw() {
            using (var g = Graphics.FromImage(FCanvas)) {
                //弾をきれいな円に描くプロパティ
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.Clear(this.BackColor);
                //弾をbrushColorで指定された色で描く
                g.FillEllipse(Brushes.Red, (float)(FGameController.Ball.Position.X - FGameController.Ball.Radius), (float)(FGameController.Ball.Position.Y - FGameController.Ball.Radius), FGameController.Ball.Radius * 2, FGameController.Ball.Radius * 2);
                g.FillEllipse(Brushes.Red, Define.C_SmallBallX, Define.C_SmallBallY, Define.C_SmallBallRadius * 2, Define.C_SmallBallRadius * 2);
                for (int i = 0; i < FGameController.Blocks.Count; i++) {
                    g.FillRectangle(Brushes.LightBlue, FGameController.Blocks[i].Rect);
                }
                g.FillRectangle(Brushes.Yellow, FGameController.Bar.Rect);
            }
            PictureBox1.Image = FCanvas;
        }

        private void ShowFinishView(Brush[] vColors, Action vAction) {
            Timer.Stop();
            FColors = vColors;
            AnimationTimer.Start();
            //画面をリフレッシュする前にコントロールが表示されてしまうため100ms待つ
            Thread.Sleep(100);
            #region 終了画面へ遷移
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
            LabelScoreBonus.Text = $"+{FGameController.BallCount * Define.C_ScoreBonus} )";
            LabelScoreBonus.Visible = true;
            TextScoreBonus.Visible = true;
            ButtonContinue.Visible = true;
            ButtonContinue.Focus();
            #endregion
        }

        private void AnimationTimer_Tick(object sender, EventArgs e) {
            #region 終了画面の描画
            using (var g = Graphics.FromImage(FCanvas)) {
                g.Clear(this.BackColor);
                g.FillEllipse(FColors[FColorIndex % 4], FCanvas.Width / 2 - 100, FCanvas.Height / 2 - 100, 200, 100);
            }
            PictureBox1.Image = FCanvas;
            #endregion
            FColorIndex++;
        }

        private void ButtonContinue_Click(object sender, EventArgs e) {
            AnimationTimer.Stop();
            using (var g = Graphics.FromImage(FCanvas)) {
                g.Clear(this.BackColor);
            }
            PictureBox1.Image = FCanvas;
            #region 画面の初期化
            FGameController.Initialize(this.GetSettings());
            LabelClear.Visible = false;
            LabelGameover.Visible = false;
            ButtonContinue.Visible = false;

            ResultTextScore.Visible = false;
            ResultLabelScore.Visible = false;
            LabelScoreBonus.Visible = false;
            TextScoreBonus.Visible = false;

            ButtonStart.Visible = true;
            ButtonStart.Focus();
            DifficultyBox.Visible = true;
            # endregion 画面の初期化
        }
    }
}
