using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace BreakBlock {
    public partial class FormBreakBlock : Form {
        private Bitmap FCanvas;
        private Ball FBall;
        private List<Block> FBlocks = new List<Block>();
        private Bar FBar;

        private bool FIsStartClicked = false;
        private bool FIsSpacePressed = false;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public FormBreakBlock() => this.InitializeComponent();

        private void FormBreakBlock_Load(object vSender, EventArgs vE) => FCanvas = new Bitmap(PictureBox1.Width, PictureBox1.Height);

        private void ButtonStart_Click(object vSender, EventArgs vE) {
            FIsStartClicked = true;
            if (FIsStartClicked == true) {
                ControlPlay();

                FBar = new Bar(PictureBox1, FCanvas);
                int barCenter = (PictureBox1.Width - FBar.BarWidth) / 2;
                FBar.PutBar(barCenter);

                InitializeBlock();

                FBall = new Ball(PictureBox1, FCanvas, Brushes.Red);
                FBall.PutCircle(PictureBox1.Width / 2, 342);
            }
        }

        private void Timer_Tick(object vSender, EventArgs vE) => this.Draw();


        private void InitializeBlock() {
            for (int i = 0; i < 4; i++) {
                for (int j = 0; j < 6; j++) {
                    int x = 10 + j * 55;
                    int y = 20 + i * 25;
                    var wBlock = new Block(PictureBox1, FCanvas, x, y);
                    wBlock.DrawBlock();
                    FBlocks.Add(wBlock);
                }
            }
        }

        private void FormBreakBlock_KeyDown(object vSender, KeyEventArgs vE) {
            if (FIsStartClicked == true) {
                if (vE.KeyData == Keys.Space) {
                    FIsSpacePressed = true;
                    Timer.Start();
                }
            }
            vE.Handled = true;

            if (FIsSpacePressed == true) {
                if (vE.KeyData == Keys.J || vE.KeyData == Keys.Right || vE.KeyData == Keys.S) {
                    FBar.MoveBar(+1);
                }

                if (vE.KeyData == Keys.F || vE.KeyData == Keys.Left || vE.KeyData == Keys.A) {
                    FBar.MoveBar(-1);
                }
            }
        }

        private void Draw() {
            FBall.Move(FBlocks);
            FBar.MoveBar(0);
            for (int i = 0; i < FBlocks.Count; i++) {
                FBlocks[i].DrawBlock();
            }
            LabelScore.Text = FBall.Score.ToString();
            if (!FBlocks.Any()) {
                FBall.Finish = 1;
            }
            if (FBall.Finish != 0) {
                ClearOrGameover();
            }
        }

        private void ClearOrGameover() {
            if (FBall.Finish == 1) {
                Finish(Brushes.Orange);
                LabelClear.Visible = true;
            } else if (FBall.Finish == 2) {
                Finish(Brushes.Blue);
                LabelGameover.Visible = true;
            }
        }

        private void Finish(Brush vColor) {
            Timer.Stop();
            ControlFinish();
            using (var wG = Graphics.FromImage(FCanvas)) {
                wG.Clear(this.BackColor);
                wG.FillEllipse(vColor, FCanvas.Width / 2 - 100, FCanvas.Height / 2 - 100, 200, 100);
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

            ResultLabelScore.Text = FBall.Score.ToString();
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
            FBall.Finish = 0;
            FBall.Score = 0;
            FBlocks.Clear();

            ResultTextScore.Visible = false;
            ResultLabelScore.Visible = false;
            LabelScore.Text = "0";

            ButtonStart.Visible = true;
            ButtonStart.Focus();
        }
    }
}
