using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BreakBlock {
    public partial class BreakBlockForm : Form {
        private Bitmap FCanvas;
        private Ball FBall;
        private List<Rectangle> FBlocks = new List<Rectangle>();
        private Bar FBar;

        private bool FIsStartClicked = false;
        private bool FIsSpacePressed = false;
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public BreakBlockForm() => this.InitializeComponent();

        private void BreakBlockForm_Load(object sender, EventArgs e) => FCanvas = new Bitmap(PictureBox1.Width, PictureBox1.Height);

        private void ButtonStart_Click(object sender, EventArgs e) {
            FIsStartClicked = true;
            ControlPlay();

            int wBarPositionX = (PictureBox1.Width - Define.C_BarWidth) / 2;
            FBar = new Bar(wBarPositionX);

            InitializeBlock();

            FBall = new Ball(PictureBox1.Width / 2, Define.C_BarPositionY - Define.C_BallRadius);
            Draw();

        }

        private void Timer_Tick(object sender, EventArgs e) {
            // TODO:ボールが動く処理＋当たり判定
            FBall.Move();
            this.Draw();
        }

        private void InitializeBlock() {
            for (int i = 0; i < Define.C_BlockColumnNum; i++) {
                for (int j = 0; j < Define.C_BlockRowNum; j++) {
                    int wX = Define.C_BlockFirstPositionX + j * (Define.C_BlockWidth + Define.C_BlockGap);
                    int wY = Define.C_BlockFirstPositionY + i * (Define.C_BlockHeight + Define.C_BlockGap);
                    var wBlock = new Rectangle(wX, wY, Define.C_BlockWidth, Define.C_BlockHeight);
                    FBlocks.Add(wBlock);
                }
            }
        }

        private void FormBreakBlock_KeyDown(object sender, KeyEventArgs e) {
            e.Handled = true;
            switch (e.KeyData) {
                case Keys.Space:
                    if (!FIsStartClicked) break;
                    FIsSpacePressed = true;
                    Timer.Start();
                    break;
                case Keys.J:
                case Keys.Right:
                case Keys.S:
                    if (!FIsSpacePressed) break;
                    FBar.MoveBar(BarDirection.Right);
                    break;
                case Keys.F:
                case Keys.Left:
                case Keys.A:
                    if (!FIsSpacePressed) break;
                    FBar.MoveBar(BarDirection.Left);
                    break;
            }
        }

        private void Draw() {
            using (var g = Graphics.FromImage(FCanvas)) {
                g.Clear(this.BackColor);
                //弾をbrushColorで指定された色で描く
                g.FillEllipse(Brushes.Red, (float)(FBall.Position.X - Define.C_BallRadius), (float)(FBall.Position.Y - Define.C_BallRadius), Define.C_BallRadius * 2, Define.C_BallRadius * 2);

                for (int i = 0; i < FBlocks.Count; i++) {
                    g.FillRectangle(Brushes.LightBlue, FBlocks[i]);
                }
                g.FillRectangle(Brushes.Yellow, FBar.PositionX, Define.C_BarPositionY, Define.C_BarWidth, Define.C_BarHeight);
            }
            PictureBox1.Image = FCanvas;
        }

        private void ClearOrGameover() {

        }

        private void Finish(Brush vColor) {
            Timer.Stop();
            ControlFinish();
            using (var g = Graphics.FromImage(FCanvas)) {
                g.Clear(this.BackColor);
                g.FillEllipse(vColor, FCanvas.Width / 2 - 100, FCanvas.Height / 2 - 100, 200, 100);
            }
        }

        private void ButtonContinue_Click(object vSender, EventArgs vE) {
            using (var wG = Graphics.FromImage(FCanvas)) {
                wG.Clear(this.BackColor);
            }
            PictureBox1.Image = FCanvas;
            InithalizeAll();
        }

        private void ControlPlay() {
            ButtonStart.Visible = false;
            TextScore.Visible = true;
            LabelScore.Visible = true;
        }

        private void ControlFinish() {
            TextScore.Visible = false;
            LabelScore.Visible = false;
            FIsSpacePressed = false;

            ResultLabelScore.Text = null;
            ResultTextScore.Visible = true;
            ResultLabelScore.Visible = true;
            ButtonContinue.Visible = true;
            ButtonContinue.Focus();
        }

        private void InithalizeAll() {
            LabelClear.Visible = false;
            LabelGameover.Visible = false;
            ButtonContinue.Visible = false;

            FIsStartClicked = false;
            FIsSpacePressed = false;
            FBlocks.Clear();

            ResultTextScore.Visible = false;
            ResultLabelScore.Visible = false;
            LabelScore.Text = "0";

            ButtonStart.Visible = true;
            ButtonStart.Focus();
        }
    }
}
