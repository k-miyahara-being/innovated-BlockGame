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
        private List<Block> FBlocks = new List<Block>();
        private Bar FBar;

        private bool FIsStartClicked = false;
        private bool FIsSpacePressed = false;
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public BreakBlockForm() => this.InitializeComponent();

        private void BreakBlockForm_Load(object vSender, EventArgs vE) => FCanvas = new Bitmap(PictureBox1.Width, PictureBox1.Height);

        private void ButtonStart_Click(object vSender, EventArgs vE) {
            FIsStartClicked = true;
            if (FIsStartClicked == true) {
                ControlPlay();

                FBar = new Bar();
                int barCenter = (PictureBox1.Width - FBar.Width) / 2;

                InitializeBlock();

                FBall = new Ball(PictureBox1.Width / 2, 342);
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
                    int x = 10 + j * 55;
                    int y = 20 + i * 25;
                    var wBlock = new Block(x, y);
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
            using (Graphics g = Graphics.FromImage(FCanvas)) {
                g.Clear(this.BackColor);
                //弾をbrushColorで指定された色で描く
                g.FillEllipse(Brushes.Red, (float)(FBall.Position.X - FBall.Radius), (float)(FBall.Position.Y - FBall.Radius), FBall.Radius * 2, FBall.Radius * 2);
                
                for (int i = 0; i < FBlocks.Count; i++) {
                    g.FillRectangle(Brushes.LightBlue, FBlocks[i].BlockPositionX, FBlocks[i].BlockPositionY, FBlocks[i].Block_width,FBlocks[i].Block_height);
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
