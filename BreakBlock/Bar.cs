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
        private PictureBox pictureBox;   //描画するpictureBox
        private Bitmap canvas;          //描画するキャンバス
        private int positionX;          //横位置(x座標)
        private int previousX;          //以前の横位置(x座標)
        private int directionX;         //移動方向(x座標)(+1 or -1)
        
        public Bar(PictureBox pb, Bitmap cv)
        {

        }

    }
}
