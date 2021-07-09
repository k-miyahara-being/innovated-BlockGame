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
        private Bar bar;　　　　　　//バーの宣言
        private int barX = 120;     //バーのx座標
        private bool PressedSpace = false;　　//スペースキーが押されたか？

        public FormBreakBlock()
        {
            InitializeComponent();
        }

        private void FormBreakBlock_Load(object sender, EventArgs e)
        {
            canvas = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            bar = new Bar(pictureBox1, canvas);
            bar.PutBar(barX);　　//バーを描画する
            
            InitializeBlock(); //ブロックの初期化
   
            ball = new Ball(pictureBox1, canvas, Brushes.Red);      //ボールクラスインスタンスの作成
            ball.PutCircle(160, 330);                               //ボールの位置

        }

        //弾が動く
        private void timer1_Tick(object sender, EventArgs e)
        {
            ball.Move();
            /*if (x <= 90 && x > 20 && y <= 130)
            {
                ball.directionY = 1;

            }*/
            int x = blocks[0].blockPositionX;
            int y = blocks[0].blockPositionY;
            int ballX = ball.positionX;
            int ballY = ball.positionY;
            int dX = ball.directionX;
            int dY = ball.directionY;
            if (x <= ballX && ballX <= x + 70 && y <= ballY && ballY <= y + 30)　//上辺
            {
                ball.directionY = -1;
            }
            if (x == ballX && y<= ballY && ballY <= y +30) //左辺
            {
                ball.directionX = -1;
            }
            if (x + 70 == ballX && y <= ballY && ballY <= y + 30)　//右辺
            {
                ball.directionX = 1;
            }
            if (x <= ballX && ballX <= x + 70 && y <= ballY && ballY <= y +30) //下辺
            {
                ball.directionY = 1;
            }
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
            if (e.KeyData == Keys.Space)　　//スペースキーが押された際にボール発射
            {
                PressedSpace = true;
                timer1.Start();
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
            for (int i = 0; i < blocks.Count; i++)
            {
                blocks[i].DrawBlock();
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        //消えたブロックをとリストから消去し、画面を更新する
        /*private void button1_Click(object sender, EventArgs e)
        {
            blocks[1].DeleteBlock();
            blocks.RemoveAt(1);
            Draw();
        }
        */

        
       
    }
}
