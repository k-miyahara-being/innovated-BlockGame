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
        private Bitmap canvas;      //キャンバスの宣言

        //const int width = panel2.Width;
        //int height = panel2.Height;

        //Bitmap canvas = new Bitmap(width, height);

        public FormBreakBlock()
        {
            InitializeComponent();
        }

        private void FormBreakBlock_Load(object sender, EventArgs e)
        {
            //ブロックを表示する
           
            canvas = new Bitmap(panel2.Width, panel2.Height);
            DrawBlock();

            ball = new Ball(pictureBox1, canvas, Brushes.Red);       //ボールクラスインスタンスの作成
            ball.PutCircle(160, 320);                               //ボールの位置
            timer1.Start();                                         //タイマースタート
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ball.Move();
        }

        

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            
        }

        //ブロックを表示する
        private void DrawBlock()
        {
            

            //ブロックを4×3に整列する
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    using (Graphics g = Graphics.FromImage(canvas))
                    {

                        //LightBlueのブロックを描画
                        g.FillRectangle(Brushes.LightBlue, 20 + j * 80, 20 + i * 40, 70, 30);
                        //Panelコントロールに表示
                        panel2.BackgroundImage = canvas;
                        

                    }

                }
            }
                
            
        }

        private void DeleteBlock()
        {
            int width = panel2.Width;
            int height = panel2.Height;

            Bitmap canvas = new Bitmap(width, height);

            using (Graphics g = Graphics.FromImage(canvas))
            {

                 //LightBlueのブロックを描画
                 g.FillRectangle(Brushes.White, 20, 20, 70, 30);
                 //Panelコントロールに表示
                 panel2.BackgroundImage = canvas;
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            DeleteBlock();
        }
    }
}
