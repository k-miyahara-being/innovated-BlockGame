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


        Label label0 = new Label();
        Label label1 = new Label();
        Label label2 = new Label();
        Label textScore = new Label();
        Label labelScore = new Label();
        Label labelfinish = new Label();

        Button buttonContinue = new Button();
       
        public FormBreakBlock()
        {
            InitializeComponent();
        }

        private void FormBreakBlock_Load(object sender, EventArgs e)
        {
            canvas = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            label0.Text = "スタートボタンをクリックしてください";　　//スタート画面のラベル設定
            label0.Location = new Point(23, 15);
            label0.AutoSize = true;
            label0.Font = new Font("MS UI Gothic", 17);
            panel1.Controls.Add(label0);
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            ClickedStart = true;  
            //panel2.Controls.Remove(buttonStart);  //スタートボタンの削除
            buttonStart.Visible = false;
            if (ClickedStart == true)
            {
                panel1.Controls.Remove(label0);          //「スタートボタンをクリックしてください」を削除
                label1.Text = "[Fキー] ⇦　　⇨ [Jキー]";　　//プレイ画面のラベル設定
                label1.Location = new Point(38, 15);
                label1.AutoSize = true;
                label1.Font = new Font("MS UI Gothic", 22);
                panel1.Controls.Add(label1);

                //"score："をプレイ画面に表示
                textScore.Text = "score：";
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
                pictureBox1.Controls.Add(labelScore);

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
            labelScore.Location = new Point(280, 375);
            labelScore.BackColor = Color.Black;
            labelScore.ForeColor = Color.White;
            labelScore.AutoSize = true;
            labelScore.Font = new Font("MS UI Gothic", 25);
            pictureBox1.Controls.Add(labelScore);

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
                Finish(Brushes.Orange, "CLEAR", 120, Color.Yellow);
            }
            else if (ball.finish == 2)　//ゲームオーバー
            {
                Finish(Brushes.Blue, "GAME OVER", 85, Color.LightBlue);
            }
        }

        //ゲーム終了画面
        private void Finish(Brush cl1, string comment, int labelx, Color cl2)
        {
            timer1.Stop();
            using (Graphics g = Graphics.FromImage(canvas))
            {
                g.Clear(BackColor);
                int centerX = canvas.Width / 2 - 100;
                int centerY = canvas.Height / 2 - 100;
                g.FillEllipse(cl1, centerX, centerY, 200, 100);
            }

            panel1.Controls.Remove(label1);   //「[Fキー] ⇦　　⇨ [Jキー]」の削除

            labelfinish.Text = comment;                //終了コメントのラベル設定
            labelfinish.Location = new Point(labelx, 140);
            labelfinish.AutoSize = true;
            labelfinish.Font = new Font("MS UI Gothic", 22);
            labelfinish.BackColor = Color.Transparent;
            labelfinish.ForeColor = cl2;
            pictureBox1.Controls.Add(labelfinish);

            label2.Text = "コンティニューしますか？";  //コンティニューラベル設定
            label2.Location = new Point(50, 15);
            label2.AutoSize = true;
            label2.Font = new Font("MS UI Gothic", 17);
            panel1.Controls.Add(label2);

            buttonContinue.Text = "Continue";          //コンティニューボタン設定
            buttonContinue.Location = new Point(120, 320);
            buttonContinue.AutoSize = true;
            buttonContinue.Font = new Font("MS UI Gothic", 16);
            buttonContinue.BackColor = Color.LightGreen;
            pictureBox1.Controls.Add(buttonContinue);
            buttonContinue.Click += new EventHandler(buttonContinue_Click);


        }


        private void buttonContinue_Click(object sender, EventArgs e)
        {
            pictureBox1.Controls.Remove(buttonContinue);
            panel1.Controls.Remove(label2);
            pictureBox1.Controls.Remove(labelfinish);
            using (Graphics g = Graphics.FromImage(canvas))
            {
                g.Clear(BackColor);
            }
            //panel2.Refresh();
            pictureBox1.Image = canvas;

            FormBreakBlock_Load(sender, e);
            buttonStart.Visible = true;
            PressedSpace = false;
            
        }

        private void InithalizeAll()
        {
            buttonStart.Visible = true;
            ClickedStart = false;
            PressedSpace = false;
            ball.finish = 0;
            ball.score = 0;
        }
      

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            
        }



        //消えたブロックをリストから消去し、画面を更新する
        /*private void button1_Click(object sender, EventArgs e)
        {
            blocks[1].DeleteBlock();
            blocks.RemoveAt(1);
            Draw();
        }
        */



    }
}
