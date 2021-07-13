using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BreakBlock
{
    public partial class FormBreakBlock : Form
    {
        private Bitmap canvas;      //キャンバスの宣言
        private Ball ball;          //ボールの宣言
        private List<Block> blocks = new List<Block>();　　//ブロックリストの生成
        private Bar bar;      //バーの宣言

        private bool ClickedStart = false;    //スタートボタンが押されたか？
        private bool PressedSpace = false;  //スペースキーが押されたか？


        //Label labelfinish = new Label();
        /*Label textScore = new Label();
        Label labelScore = new Label();*/
        Label labelfinish = new Label();

        public FormBreakBlock()
        {
            InitializeComponent();
        }

        private void FormBreakBlock_Load(object sender, EventArgs e)
        {
            canvas = new Bitmap(pictureBox1.Width, pictureBox1.Height);
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            ClickedStart = true;  
            if (ClickedStart == true)
             {
                buttonStart.Visible = false;　　//スタートボタンを非表示
                labelStart.Visible = false;     //「スタートボタンをクリックしてください」を非表示
                labelPlay.Visible = true;
                textScore.Visible = true;       //[score：]を表示
                labelScore.Visible = true;      //スコアの数字を表示
                ResultTextScore.Visible = false;
                ResultLabelScore.Visible = false;

                

                //"score："をプレイ画面に表示
                /*textScore.Text = "score：";
                textScore.Location = new Point(210, 380);
                textScore.BackColor = Color.Black;
                textScore.ForeColor = Color.White;
                textScore.AutoSize = true;
                textScore.Font = new Font("MS UI Gothic", 18);
                pictureBox1.Controls.Add(textScore);

                //スコア(数字)をプレイ画面に表示
                labelScore.Text = "0";
                labelScore.Location = new Point(280, 375);
                labelScore.BackColor = Color.Black;
                labelScore.ForeColor = Color.White;
                labelScore.AutoSize = true;
                labelScore.Font = new Font("MS UI Gothic", 25);
                pictureBox1.Controls.Add(labelScore);*/

                bar = new Bar(pictureBox1, canvas);
                int barCenter = (pictureBox1.Width - bar.Bar_width) / 2;     //バーの初期位置x座標
                bar.PutBar(barCenter);  //バーを描画する

                InitializeBlock(); //ブロックの初期化

                ball = new Ball(pictureBox1, canvas, Brushes.Red);      //ボールクラスインスタンスの作成
                int ballCenter = pictureBox1.Width / 2;    //ボールの初期位置x座標
                ball.PutCircle(ballCenter, 340);
            }
        }

        //弾が動く
        private void timer1_Tick(object sender, EventArgs e)
        {
            Draw();
        }

        //ブロックの初期化
        private void InitializeBlock()
        {
            //ブロックを4×3に整列する
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Block block;
                    int x = 20 + j * 80;
                    int y = 20 + i * 40;
                    block = new Block(pictureBox1, canvas, x, y);
                    block.DrawBlock();
                    //リストに追加する
                    blocks.Add(block);
                }
            }
        }

        //キーイベント
        private void FormBreakBlock_KeyDown(object sender, KeyEventArgs e)
        {
            if (ClickedStart == true)
            {
                if (e.KeyData == Keys.Space)  //スペースキーが押された際にボール発射
                {
                    PressedSpace = true;
                    timer1.Start();
                }
            }
            e.Handled = true;
            

            if (PressedSpace == true)　　//スペースキーが押されたとき
            {
                if (e.KeyData == Keys.J)　　//Jキーが押されたときバーが右に
                {
                    bar.MoveBar(+1);
                }

                if (e.KeyData == Keys.F)　　//Fキーが押されたときバーが左に
                {
                    bar.MoveBar(-1);
                }
            }
        }

        //画面の更新
        private void Draw()
        {
            ball.Move(blocks);
            bar.MoveBar(0);
            for (int i = 0; i < blocks.Count; i++)
            {
                blocks[i].DrawBlock();
            }
            //スコア(数字)をプレイ画面に表示
            labelScore.Text = ball.score.ToString();
            pictureBox1.Controls.Add(labelScore);
            ResultLabelScore.Text = ball.score.ToString();

            if (!blocks.Any())
            {
                ball.finish = 1;
            }
            GameFinish();
        }

        //クリアか？ゲームオーバーか？
        private void GameFinish()
        {
            if (ball.finish == 1)　//ゲームクリア
            {
                Finish(Brushes.Orange);
            }
            else if (ball.finish == 2)　//ゲームオーバー
            {
                Finish(Brushes.Blue);
            }
            
        }

        //ゲーム終了画面
        private void Finish(Brush cl1)
        {
            timer1.Stop();

            using (Graphics g = Graphics.FromImage(canvas))   //楕円の描画
            {
                g.Clear(BackColor);
                int centerX = canvas.Width / 2 - 100;
                int centerY = canvas.Height / 2 - 100;
                g.FillEllipse(cl1, centerX, centerY, 200, 100);
            }

            labelPlay.Visible = false;       　 //「[Fキー] ⇦　　⇨ [Jキー]」の表示
            labelContinue.Visible = true;　 　　//「コンティニューしますか？」の表示
            buttonContinue.Visible = true;   //コンティニューボタンの表示
            textScore.Visible = false;
            labelScore.Visible = false;
            ResultTextScore.Visible = true;
            ResultLabelScore.Visible = true;

            if (cl1 == Brushes.Orange)　　　　　
            {
                labelClear.Visible = true;      //「CLEAR」の表示
            }
            else if(cl1 == Brushes.Blue)
            {
                labelGameover.Visible = true;　 //「GAME OVER」の表示
            }
            　　

        }

        private void buttonContinue_Click(object sender, EventArgs e)
        {
            
            using (Graphics g = Graphics.FromImage(canvas))
            {
                g.Clear(BackColor);
            }
            pictureBox1.Image = canvas;

            InithalizeAll();
        }

        private void InithalizeAll()
        {
            labelClear.Visible = false;
            labelGameover.Visible = false;
            labelContinue.Visible = false;
            buttonContinue.Visible = false;

            ClickedStart = false;
            PressedSpace = false;
            ball.finish = 0;
            ball.score = 0;
            blocks.Clear();

            labelStart.Visible = true;
            buttonStart.Visible = true;
            textScore.Visible = false;
            labelScore.Visible = false;
            ResultTextScore.Visible = false;
            ResultLabelScore.Visible = false;
            
        }
      

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            
        }

    }
}
