using System;
using System.Collections.Generic;
using System.Drawing;
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
            ControlPlay();

            int wBarPositionX = (PictureBox1.Width - Define.C_BarWidth) / 2;
            FBar = new Bar(wBarPositionX);

            InitializeBlock();

            FBall = new Ball(PictureBox1.Width / 2, Define.C_BarPositionY - Define.C_BallRadius);
            Draw();

        }

        private void Timer_Tick(object sender, EventArgs e) {
            FBall.Move();
            this.Bound();
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
        private void Bound() {
            //構造体のプロパティの値を変更しようとすると、コンパイルエラーになりました
            //そのため、構造体のコピーを作り、そのコピーのプロパティの値を変更しコピー元に再代入しています
            //次のページを参照してください
            //https://docs.microsoft.com/ja-jp/dotnet/csharp/language-reference/compiler-messages/cs1612
            if (FBall.Position.X + Define.C_BallRadius > PictureBox1.Width || FBall.Position.X - Define.C_BallRadius < 0) {
                Vector wSpeed = FBall.Speed;
                wSpeed.X *= -1;
                FBall.Speed = wSpeed;
            }
            if (FBall.Position.Y - Define.C_BallRadius < 0) {
                Vector wSpeed = FBall.Speed;
                wSpeed.Y *= -1;
                FBall.Speed = wSpeed;
            }
            if (LineVsCircle(new Vector(FBar.PositionX, Define.C_BarPositionY),
                             new Vector(FBar.PositionX + Define.C_BarWidth, Define.C_BarPositionY),
                             FBall.Position, Define.C_BallRadius)) {
                Vector wSpeed = FBall.Speed;
                wSpeed.Y *= -1;
                FBall.Speed = wSpeed;
            }
            for (int i = 0; i < FBlocks.Count; i++) {
                Line collision = BlockVsCircle(FBlocks[i], FBall.Position);
                if (collision == Line.Top || collision == Line.Bottom) {
                    Vector wSpeed = FBall.Speed;
                    wSpeed.Y *= -1;
                    FBall.Speed = wSpeed;
                    FBlocks.RemoveAt(i);
                    break;
                } else if (collision == Line.Right || collision == Line.Left) {
                    Vector wSpeed = FBall.Speed;
                    wSpeed.X *= -1;
                    FBall.Speed = wSpeed;
                    FBlocks.RemoveAt(i);
                    break;
                }
            }
        }
        double DotProduct(Vector vA, Vector vB) {
            return vA.X * vB.X + vA.Y * vB.Y; // 内積計算
        }

        bool LineVsCircle(Vector vP1, Vector vP2, Vector vBallCenter, float vBallRadius) {
            Vector wLineDir = (vP2 - vP1);                   // パドルの方向ベクトル
            Vector wN = new Vector(wLineDir.Y, -wLineDir.X); // パドルの法線
            wN.Normalize();

            Vector dir1 = vBallCenter - vP1;
            Vector dir2 = vBallCenter - vP2;

            double wDist = Math.Abs(DotProduct(dir1, wN));
            double wA1 = DotProduct(dir1, wLineDir);
            double wA2 = DotProduct(dir2, wLineDir);

            return (wA1 * wA2 < 0 && wDist < vBallRadius) ? true : false;
        }
        Line BlockVsCircle(Rectangle block, Vector ball) {
            if (LineVsCircle(new Vector(block.Left, block.Top),
                new Vector(block.Right, block.Top), ball, Define.C_BallRadius))
                return Line.Top;

            if (LineVsCircle(new Vector(block.Left, block.Bottom),
                new Vector(block.Right, block.Bottom), ball, Define.C_BallRadius))
                return Line.Bottom;

            if (LineVsCircle(new Vector(block.Right, block.Top),
                new Vector(block.Right, block.Bottom), ball, Define.C_BallRadius))
                return Line.Right;

            if (LineVsCircle(new Vector(block.Left, block.Top),
                new Vector(block.Left, block.Bottom), ball, Define.C_BallRadius))
                return Line.Left;

            return Line.Exception;
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
