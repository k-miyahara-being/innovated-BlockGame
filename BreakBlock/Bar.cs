using System.Drawing;
using System.Windows.Forms;

namespace BreakBlock {
    /// <summary>
    /// バークラス
    /// </summary>
    class Bar {
        private PictureBox FPictureBox;  //描画するpictureBox
        private Bitmap FCanvas;          //描画するキャンバス
        private int FPreviousX;          //以前の位置(x座標)
        private int C_BarpositionY = 350; //位置(y座標)
        private int C_BarHeight = 8;  //バーの高さ

        /// <summary>
        /// バーのX座標
        /// </summary>
        public static int BarPositionX { get; set; }
        /// <summary>
        /// バーの幅
        /// </summary>
        public int BarWidth => 90;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="vPictureBox"></param>
        /// <param name="vCanvas"></param>
        public Bar(PictureBox vPictureBox, Bitmap vCanvas) {
            FPictureBox = vPictureBox;
            FCanvas = vCanvas;
        }

        /// <summary>
        /// バーの描画
        /// </summary>
        /// <param name="vX">バーのX座標</param>
        public void PutBar(int vX) {
            BarPositionX = vX;
            using (var g = Graphics.FromImage(FCanvas)) {
                g.FillRectangle(Brushes.Yellow, BarPositionX, C_BarpositionY, BarWidth, C_BarHeight);
                FPictureBox.Image = FCanvas;
            }
        }

        /// <summary>
        /// バーの移動
        /// </summary>
        /// <param name="vDirection">動くX方向</param>
        public void MoveBar(int vDirection) {
            if (FPreviousX == 0) {
                FPreviousX = BarPositionX;
            }

            //前の位置のバーを削除
            using (Graphics g = Graphics.FromImage(FCanvas)) {
                g.FillRectangle(Brushes.Black, FPreviousX, C_BarpositionY, BarWidth, C_BarHeight);
                FPictureBox.Image = FCanvas;
            }

            //新しい移動先の計算
            BarPositionX = FPreviousX + 30 * vDirection;

            //バーの移動範囲
            if (BarPositionX <= (BarWidth / 2) * -1)　　//左の壁に半分まで入る
            {
                BarPositionX = (BarWidth / 2) * -1;
            } else if (BarPositionX >= FPictureBox.Width - (BarWidth / 2))  //右の壁に半分まで入る
             {
                BarPositionX = FPictureBox.Width - (BarWidth / 2);
            }

            PutBar(BarPositionX);

            //新しい位置を以前の値として記憶
            FPreviousX = BarPositionX;
        }
    }
}
