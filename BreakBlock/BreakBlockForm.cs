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
            FGameController = new GameController(PictureBox.Width, PictureBox.Height);
            FCanvas = new Bitmap(PictureBox.Width, PictureBox.Height);
            #region コンボボックスのセット
            ComboBoxDifficulty.Items.Add(new DifficultyItem("Easy", GetSetting(@"../../EasySettings.json")));
            ComboBoxDifficulty.Items.Add(new DifficultyItem("Normal", GetSetting(@"../../NormalSettings.json")));
            ComboBoxDifficulty.Items.Add(new DifficultyItem("Hard", GetSetting(@"../../HardSettings.json")));
            //デフォルトで難易度Normalを選択
            ComboBoxDifficulty.SelectedIndex = 1;
            #endregion
        }

        private GameSetting GetSetting(string vPath) {
            using (var wStream = new FileStream(vPath, FileMode.Open, FileAccess.Read)) {
                return (GameSetting)new DataContractJsonSerializer(typeof(GameSetting)).ReadObject(wStream);
            }
        }

        private void ButtonStart_Click(object sender, EventArgs e) {
            if(ComboBoxDifficulty.DroppedDown) return;
            if(!(ComboBoxDifficulty.SelectedItem is DifficultyItem wItem)) return;
            FGameController.Initialize(wItem.Value);
            #region プレイ画面へ遷移
            ButtonStart.Visible = false;
            ComboBoxDifficulty.Visible = false;
            LabelTextScore.Visible = true;
            LabelScore.Visible = true;
            LabelScore.Text = FGameController.Score.ToString();
            LabelBallNum.Visible = true;
            LabelBallNum.Text = FGameController.BallCount.ToString();
            LabelX.Visible = true;
            FGameController.Status = Status.Ready;
            #endregion
            Draw();
        }

        private void Timer_Tick(object sender, EventArgs e) {
            FGameController.Ball.Move();
            FGameController.Bound();
            LabelScore.Text = FGameController.Score.ToString();
            LabelBallNum.Text = FGameController.BallCount.ToString();
            switch (FGameController.Status) {
                case Status.Playing:
                    this.Draw();
                    break;
                case Status.Ready:
                    Timer.Stop();
                    FGameController.Bar = new Bar((PictureBox.Width - FGameController.Bar.Rect.Width) / 2, Define.C_BarPositionY, FGameController.Bar.Rect.Width, FGameController.Bar.Rect.Height, PictureBox.Width);
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
                    ComboBoxDifficulty.DroppedDown = !ComboBoxDifficulty.DroppedDown;
                    break;
                case Keys.Down:
                    if (FGameController.Status != Status.Start) break;
                    if (ComboBoxDifficulty.SelectedIndex + 1 == ComboBoxDifficulty.Items.Count){
                        ComboBoxDifficulty.SelectedIndex = 0;
                        break;
                    }
                    ComboBoxDifficulty.SelectedIndex++;
                    break;
                case Keys.Up:
                    if (FGameController.Status != Status.Start) break;
                    if (ComboBoxDifficulty.SelectedIndex == 0) {
                        ComboBoxDifficulty.SelectedIndex = ComboBoxDifficulty.Items.Count - 1;
                        break;
                    }
                    ComboBoxDifficulty.SelectedIndex--;
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

        #region マウス操作
        private void PictureBox1_MouseMove(object sender, MouseEventArgs e) {
            if (FGameController.Status == Status.Ready || FGameController.Status == Status.Playing) {
                int wMoveDistance = e.X - FGameController.Bar.Rect.X - FGameController.Bar.Rect.Width / 2;
                MoveBarAndBall(wMoveDistance);
            }
        }

        private void PictureBox1_MouseDown(object sender, MouseEventArgs e) {
            if (FGameController.Status != Status.Ready) return;
            FGameController.Status = Status.Playing;
            Timer.Start();
        }
        #endregion

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

        private void Draw() {
            using (var g = Graphics.FromImage(FCanvas)) {
                //弾をきれいな円に描くプロパティ
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.Clear(this.BackColor);
                //弾をbrushColorで指定された色で描く
                g.FillEllipse(Brushes.Red, (float)(FGameController.Ball.Position.X - FGameController.Ball.Radius), (float)(FGameController.Ball.Position.Y - FGameController.Ball.Radius), FGameController.Ball.Radius * 2, FGameController.Ball.Radius * 2);
                g.FillEllipse(Brushes.Red, Define.C_SmallBallX, Define.C_SmallBallY, Define.C_SmallBallRadius * 2, Define.C_SmallBallRadius * 2);
                foreach (IBlock wBlock in FGameController.Blocks) {
                    g.FillRectangle(wBlock.Color, wBlock.Rect);
                }
                g.FillRectangle(Brushes.Yellow, FGameController.Bar.Rect);
                foreach (IItem wItem in FGameController.Items) {
                    ItemPictureBox.Image = wItem?.ItemImage;
                }
            }
            PictureBox.Image = FCanvas;
        }

        private void ShowFinishView(Brush[] vColors, Action vAction) {
            Timer.Stop();
            FColors = vColors;
            AnimationTimer.Start();
            //画面をリフレッシュする前にコントロールが表示されてしまうため100ms待つ
            Thread.Sleep(100);
            #region 終了画面へ遷移
            LabelTextScore.Visible = false;
            LabelScore.Visible = false;
            LabelBallNum.Visible = false;
            LabelX.Visible = false;

            vAction?.Invoke();
            PictureBox.Controls.Add(LabelGameover);
            PictureBox.Controls.Add(LabelClear);
            ButtonContinue.Visible = true;
            ButtonContinue.Focus();
            LabelResultTextScore.Visible = true;
            LabelResultScore.Visible = true;
            LabelResultScore.Text = FGameController.Score.ToString();
            LabelTextScoreBonus.Visible = true;
            LabelScoreBonus.Visible = true;
            LabelScoreBonus.Text = $"+{FGameController.BallCount * Define.C_ScoreBonus} )";
            #endregion
        }

        private void AnimationTimer_Tick(object sender, EventArgs e) {
            #region 終了画面の描画
            using (var g = Graphics.FromImage(FCanvas)) {
                g.Clear(this.BackColor);
                g.FillEllipse(FColors[FColorIndex % 4], FCanvas.Width / 2 - 100, FCanvas.Height / 2 - 100, 200, 100);
            }
            PictureBox.Image = FCanvas;
            #endregion
            FColorIndex++;
        }

        private void ButtonContinue_Click(object sender, EventArgs e) {
            AnimationTimer.Stop();
            using (var g = Graphics.FromImage(FCanvas)) {
                g.Clear(this.BackColor);
            }
            PictureBox.Image = FCanvas;
            #region 画面の初期化
            if (!(ComboBoxDifficulty.SelectedItem is DifficultyItem wItem)) return;
            FGameController.Initialize(wItem.Value);
            ButtonContinue.Visible = false;
            LabelClear.Visible = false;
            LabelGameover.Visible = false;
            LabelResultTextScore.Visible = false;
            LabelResultScore.Visible = false;
            LabelScoreBonus.Visible = false;
            LabelTextScoreBonus.Visible = false;

            ButtonStart.Visible = true;
            ButtonStart.Focus();
            ComboBoxDifficulty.Visible = true;
            FGameController.Status = Status.Start;
            # endregion 画面の初期化
        }
    }
}
