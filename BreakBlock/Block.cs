using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;


namespace BreakBlock
{
    class Block
    {
        private PictureBox pictureBox;  //描画するpictureBox
        private Bitmap canvas;          //描画するキャンバス
        private int positionX;　　　　　//位置(x座標)
        private int positionY;　　　　　//位置(y座標)
        private int Block_width = 70;　 //ブロックの幅
        private int Block_height = 30;　//ブロックの高さ

        //private int top;
        //private int bottom;
        //private int left;
        //private int right;

        public Block(PictureBox pb, Bitmap cv, int x, int y)
        {
            pictureBox = pb;       
            canvas = cv;           
            positionX = x;
            positionY = y;
        }

        //ブロックを表示する
        public void DrawBlock()
        {
            using (Graphics g = Graphics.FromImage(canvas))
            {

                //LightBlueのブロックを描画
                g.FillRectangle(Brushes.LightBlue, positionX, positionY, Block_width, Block_height);
                //Panelコントロールに表示
                pictureBox.Image = canvas;
            }
        }

        public void DeleteBlock()
        {
            using (Graphics g = Graphics.FromImage(canvas))
            {
                //LightBlueのブロックを描画
                g.FillRectangle(Brushes.Black, positionX, positionY, Block_width, Block_height);
                //Panelコントロールに表示
                pictureBox.Image = canvas;
            }
        }

    }



}
