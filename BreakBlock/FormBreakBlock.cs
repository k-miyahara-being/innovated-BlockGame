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

        public FormBreakBlock()
        {
            InitializeComponent();
        }

        private void FormBreakBlock_Load(object sender, EventArgs e)
        {
            canvas = new Bitmap(350, 412);
            ball = new Ball(pictureBox1, canvas, Brushes.Red);       //ボールクラスインスタンスの作成
            ball.PutCircle(160, 320);                               //ボールの位置
            timer1.Start();                                         //タイマースタート
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ball.Move();
        }

    }
}
