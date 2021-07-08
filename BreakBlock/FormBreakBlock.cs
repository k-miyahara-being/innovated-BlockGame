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
        private Ball ball;          //ボールの宣言
        private List<Block> blocks = new List<Block>();
        private Bitmap canvas;      //キャンバスの宣言
        private int bar = 0;



        //const int width = panel2.Width;
        //int height = panel2.Height;

        //Bitmap canvas = new Bitmap(width, height);

        public FormBreakBlock()
        {
            InitializeComponent();
        }

        private void FormBreakBlock_Load(object sender, EventArgs e)
        {
            canvas = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            DrawBar(bar);
            InitializeBlock(); //ブロックの初期化
   
            ball = new Ball(pictureBox1, canvas, Brushes.Red);      //ボールクラスインスタンスの作成
            ball.PutCircle(160, 330);                               //ボールの位置

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ball.Move();
        }

        //スペースキーが押された際にボール発射
        private void FormBreakBlock_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Space)
            {
                timer1.Start();
            }
            e.Handled = true;

            if(e.KeyData == Keys.F)
            {
                bar -= 5;
                DrawBar(bar);
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

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

        //バーの描画
        private void DrawBar(int barX)
        {
            using (Graphics g = Graphics.FromImage(canvas))
            {
                g.FillRectangle(Brushes.Yellow, 120 + barX, 350, 100, 10);
                //コントロールに表示
                pictureBox1.Image = canvas;
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


        /*private void button1_Click(object sender, EventArgs e)
        {
            blocks[1].DeleteBlock();
            blocks.RemoveAt(1);
            Draw();
        }
        */

        

        


    }
}
