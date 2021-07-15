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

        public FormBreakBlock()
        {
            InitializeComponent();
        }

        private void FormBreakBlock_Load(object sender, EventArgs e)
        {
            canvas = new Bitmap(pictureBox1.Width, pictureBox1.Height);
        }

        //スタートボタンを押したとき
        private void buttonStart_Click(object sender, EventArgs e)
        {
            ClickedStart = true;  
            if (ClickedStart == true)
             {
                ControlPlay();  //ラベル・ボタンの表示

                bar = new Bar(pictureBox1, canvas);
                int barCenter = (pictureBox1.Width - bar.Bar_width) / 2;     //バーの初期位置x座標
                bar.PutBar(barCenter);  //バーを描画する

                InitializeBlock(); //ブロックの初期化

                ball = new Ball(pictureBox1, canvas, Brushes.Red);          //ボールクラスインスタンスの作成
                int ballCenter = pictureBox1.Width / 2;                     //ボールの初期位置x座標
                ball.PutCircle(ballCenter, 342);
            }
        }

        //画面の更新を呼ぶ
        private void timer1_Tick(object sender, EventArgs e)
        {
            Draw();
        }

        //ブロックの初期化
        private void InitializeBlock()
        {
            //ブロックを整列する
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    Block block;
                    int x = 10 + j * 55;
                    int y = 20 + i * 25;
                    block = new Block(pictureBox1, canvas, x, y);
                    block.DrawBlock();
                    blocks.Add(block);    //リストに追加する
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

            if (PressedSpace == true )　　//スペースキーが押されたとき
            {
                if (e.KeyData == Keys.J || e.KeyData == Keys.Right || e.KeyData == Keys.S)　　//Jキーが押されたときバーが右に
                {
                    bar.MoveBar(+1);
                }

                if (e.KeyData == Keys.F || e.KeyData == Keys.Left || e.KeyData == Keys.A)　　//Fキーが押されたときバーが左に
                {
                    bar.MoveBar(-1);
                }
            }
        }

        //画面の更新
        private void Draw()
        {
            ball.Move(blocks);
            bar.MoveBar(0);                           //バーが移動していないとき
            for (int i = 0; i < blocks.Count; i++)
            {
                blocks[i].DrawBlock();
            }
            labelScore.Text = ball.score.ToString();  //スコア(数字)をプレイ画面にリアルタイム表示
            if (!blocks.Any())　　　　                //ブロックのリストが空ならゲームクリア
            {
                ball.finish = 1;
            }
            GameFinish();　　　　　　                 //結果の判定
        }

        //クリアか？ゲームオーバーか？
        private void GameFinish()
        {
            if (ball.finish == 1)　　　 //ゲームクリア
            {
                Finish(Brushes.Orange);
                labelClear.Visible = true;      //「CLEAR」の表示
            }
            else if (ball.finish == 2)　//ゲームオーバー
            {
                Finish(Brushes.Blue);
                labelGameover.Visible = true;　 //「GAME OVER」の表示
            }
            
        }

        //ゲーム終了画面
        private void Finish(Brush cl1)
        {
            timer1.Stop();
            ControlFinish();
            using (Graphics g = Graphics.FromImage(canvas))   //楕円の描画
            {
                g.Clear(BackColor);
                int centerX = canvas.Width / 2 - 100;
                int centerY = canvas.Height / 2 - 100;
                g.FillEllipse(cl1, centerX, centerY, 200, 100);
            }
        }

        //コンティニューボタンを押したとき
        private void buttonContinue_Click(object sender, EventArgs e)
        {
            using (Graphics g = Graphics.FromImage(canvas))
            {
                g.Clear(BackColor);
            }
            pictureBox1.Image = canvas;
            InithalizeAll();
        }

        //プレイ画面のコントロールの設定
        private void ControlPlay()
        {
            buttonStart.Visible = false;  //スタートボタンを非表示
            textScore.Visible = true;       //[score：]を表示
            labelScore.Visible = true;      //スコアの数字を表示
        }

        //終了画面のコントロールの設定
        private void ControlFinish()
        {
            textScore.Visible = false;　　　　　//プレイ画面の「Score：」を非表示
            labelScore.Visible = false;　　　　 //プレイ画面のスコアを非表示
            PressedSpace = false;

            ResultLabelScore.Text = ball.score.ToString();
            ResultTextScore.Visible = true;　 　//終了画面の「Score：」を表示
            ResultLabelScore.Visible = true;　　//終了画面のスコアを表示
            buttonContinue.Visible = true;　　　//コンティニューボタンの表示
            buttonContinue.Focus();　　　　　　 //コンティニューボタンにフォーカスする
        }

        //コンティニュー時の初期化
        private void InithalizeAll()
        {
            labelClear.Visible = false;　　　　　//「CLEAR」の文字を非表示
            labelGameover.Visible = false;　　　 //「GAME OVER」の文字を非表示
            buttonContinue.Visible = false;　　  //コンティニューボタンを非表示

            ClickedStart = false;　　　　　　　　//スタートボタンを押していない状態に戻す
            PressedSpace = false;　　　　　　　　//スペースボタンを押していない状態に戻す
            ball.finish = 0; 　　　　　　　　　　//ゲーム終了状態をリセット
            ball.score = 0;　　　　　　　　　　　//スコアをリセット
            blocks.Clear();　　　　　　　　　　　//ブロックのリストを空にする

            ResultTextScore.Visible = false;　　 //「Score：」を非表示
            ResultLabelScore.Visible = false;　　//スコアを非表示
            labelScore.Text = "0";　　　　　　　 //スコアの初期値

            buttonStart.Visible = true;　　　　　//スタートボタンの表示
            buttonStart.Focus();　　　　　　　　 //スタートボタンにフォーカスする
        }
    }
}
