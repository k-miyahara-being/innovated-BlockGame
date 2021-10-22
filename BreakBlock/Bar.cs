using System.Drawing;
using System.Windows.Forms;

namespace BreakBlock {
    class Bar {
        private PictureBox FPictureBox;  //描画するpictureBox
        private Bitmap FCanvas;          //描画するキャンバス
        private int FPreviousX;          //以前の位置(x座標)
        private int FDirectionX = +1;    //移動方向(x座標)(+1 or -1)
        private int C_BarpositionY = 350; //位置(y座標)
        public static int FBarpositionX; //位置(x座標)
        public int C_BarWidth = 90;　　  //バーの幅
        private int C_BarHeight = 8;  //バーの高さ

        public Bar(PictureBox pb, Bitmap cv) {
            FPictureBox = pb;
            FCanvas = cv;
        }

        //バーの描画
        public void PutBar(int x) {
            FBarpositionX = x;
            using (Graphics g = Graphics.FromImage(FCanvas)) {
                g.FillRectangle(Brushes.Yellow, FBarpositionX, C_BarpositionY, C_BarWidth, C_BarHeight);
                //コントロールに表示
                FPictureBox.Image = FCanvas;
            }
        }

        //バーの移動
        public void MoveBar(int direction) {
            if (FPreviousX == 0) {
                FPreviousX = FBarpositionX;
            }

            //前の位置のバーを削除
            using (Graphics g = Graphics.FromImage(FCanvas)) {
                g.FillRectangle(Brushes.Black, FPreviousX, C_BarpositionY, C_BarWidth, C_BarHeight);
                FPictureBox.Image = FCanvas;
            }

            //移動方向が右か左か
            FDirectionX = direction;

            //新しい移動先の計算
            FBarpositionX = FPreviousX + 30 * FDirectionX;

            //バーの移動範囲
            if (FBarpositionX <= (C_BarWidth / 2) * -1)　　//左の壁に半分まで入る
            {
                FBarpositionX = (C_BarWidth / 2) * -1;
            } else if (FBarpositionX >= FPictureBox.Width - (C_BarWidth / 2))  //右の壁に半分まで入る
             {
                FBarpositionX = FPictureBox.Width - (C_BarWidth / 2);
            }

            PutBar(FBarpositionX);

            //新しい位置を以前の値として記憶
            FPreviousX = FBarpositionX;
        }
    }
}
