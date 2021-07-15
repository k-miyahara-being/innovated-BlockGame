using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace BreakBlock
{
    class Bar
    {
        private PictureBox pictureBox;  //描画するpictureBox
        private Bitmap canvas;          //描画するキャンバス
        private int previousX;          //以前の位置(x座標)
        private int directionX = +1;    //移動方向(x座標)(+1 or -1)
        private int barpositionY = 350; //位置(y座標)
        public static int barpositionX; //位置(x座標)
        public int Bar_width = 90;　　  //バーの幅
        private int Bar_height = 8;　　//バーの高さ
        
        public Bar(PictureBox pb, Bitmap cv)
        {
            pictureBox = pb;
            canvas = cv;
        }

        //バーの描画
        public void PutBar(int x)
        {
            barpositionX = x;
            using (Graphics g = Graphics.FromImage(canvas))
            {
                g.FillRectangle(Brushes.Yellow, barpositionX, barpositionY, Bar_width, Bar_height);
                //コントロールに表示
                pictureBox.Image = canvas;
            }
        }

        //バーの移動
        public void MoveBar(int direction)
        {
            if (previousX == 0)
            {
                previousX = barpositionX;
            }

            //前の位置のバーを削除
            using (Graphics g = Graphics.FromImage(canvas))
            {
                g.FillRectangle(Brushes.Black, previousX, barpositionY, Bar_width, Bar_height);
                pictureBox.Image = canvas;
            }

            //移動方向が右か左か
            directionX = direction;

            //新しい移動先の計算
            barpositionX = previousX + 30 * directionX;

            //バーの移動範囲
            if(barpositionX <= (Bar_width / 2) * -1)　　//左の壁に半分まで入る
            {
                barpositionX = (Bar_width / 2) * -1;
            }else if(barpositionX >= pictureBox.Width - (Bar_width / 2))　　//右の壁に半分まで入る
            {
                barpositionX = pictureBox.Width - (Bar_width / 2);
            }

            PutBar(barpositionX);

            //新しい位置を以前の値として記憶
            previousX = barpositionX;
        }
    }
}
