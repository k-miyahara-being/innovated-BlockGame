using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows;

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
            if (FIsStartClicked == true) {
                ControlPlay();

                FBar = new Bar();
                FBar.PositionX = (PictureBox1.Width - FBar.Width) / 2;

                InitializeBlock();

                FBall = new Ball(PictureBox1.Width / 2, 342);
                Draw();

            }
        }

        private void Timer_Tick(object sender, EventArgs e) {
            // TODO:ボールが動く処理＋当たり判定
            FBall.Move();
            this.Draw();
        }

        private void InitializeBlock() {
            for (int i = 0; i < 4; i++) {
                for (int j = 0; j < 6; j++) {
                    int wX = 10 + j * 55;
                    int wY = 20 + i * 25;
                    var wBlock = new Rectangle(wX, wY, 50, 20);
                    FBlocks.Add(wBlock);
                }
            }
        }

        private void FormBreakBlock_KeyDown(object sender, KeyEventArgs e) {
            if (FIsStartClicked == true) {
                if (e.KeyData == Keys.Space) {
                    FIsSpacePressed = true;
                    Timer.Start();
                }
            }
            e.Handled = true;

            if (FIsSpacePressed == true) {
                if (e.KeyData == Keys.J || e.KeyData == Keys.Right || e.KeyData == Keys.S) {
                    FBar.MoveBar(+1);
                }

                if (e.KeyData == Keys.F || e.KeyData == Keys.Left || e.KeyData == Keys.A) {
                    FBar.MoveBar(-1);
                }
            }
        }

        private void Draw() {
            using (Graphics g = Graphics.FromImage(FCanvas)) {
                g.Clear(this.BackColor);
                //弾をbrushColorで指定された色で描く
                g.FillEllipse(Brushes.Red, (float)(FBall.Position.X - FBall.Radius), (float)(FBall.Position.Y - FBall.Radius), FBall.Radius * 2, FBall.Radius * 2);
                
                for (int i = 0; i < FBlocks.Count; i++) {
                    g.FillRectangle(Brushes.LightBlue, FBlocks[i]);
                }
                g.FillRectangle(Brushes.Yellow, FBar.PositionX, FBar.PositionY, FBar.Width, FBar.Height);
            }
            PictureBox1.Image = FCanvas;
        }

        private void ClearOrGameover() {
            
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
