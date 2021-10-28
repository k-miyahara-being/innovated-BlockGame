using System.Drawing;
using System.Windows.Forms;


namespace BreakBlock {
    /// <summary>
    /// ブロッククラス
    /// </summary>
    class Block {
        private PictureBox FPictureBox;  
        private Bitmap FCanvas;         
        private int C_Block_width = 50;　
        private int C_Block_height = 20;　

        /// <summary>
        /// ブロックのX座標
        /// </summary>
        public int BlockPositionX { get; set; }
        /// <summary>
        /// ブロックのY座標
        /// </summary>
        public int BlockPositionY { get; set; }
        /// <summary>
        /// ブロックの上辺
        /// </summary>
        public int BlockTop => this.BlockPositionY;
        /// <summary>
        /// ブロックの下辺
        /// </summary>
        public int BlockBottom => this.BlockPositionY + C_Block_height;
        /// <summary>
        /// ブロックの左辺
        /// </summary>
        public int BlockLeft => this.BlockPositionX;
        /// <summary>
        /// ブロックの右辺
        /// </summary>
        public int BlockRight => this.BlockPositionX + C_Block_width;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="vPictureBox"></param>
        /// <param name="vCanvas"></param>
        /// <param name="vX"></param>
        /// <param name="vY"></param>
        public Block(PictureBox vPictureBox, Bitmap vCanvas, int vX, int vY) {
            FPictureBox = vPictureBox;
            FCanvas = vCanvas;
            this.BlockPositionX = vX;
            this.BlockPositionY = vY;
        }

        /// <summary>
        /// ブロックを表示する
        /// </summary>
        public void DrawBlock() {
            using (var wG = Graphics.FromImage(FCanvas)) {
                wG.FillRectangle(Brushes.LightBlue, this.BlockPositionX, this.BlockPositionY, C_Block_width, C_Block_height);
                FPictureBox.Image = FCanvas;
            }
        }

        /// <summary>
        /// ブロックを消す
        /// </summary>
        public void DeleteBlock() {
            using (var wG = Graphics.FromImage(FCanvas)) {
                wG.FillRectangle(Brushes.Black, this.BlockPositionX, this.BlockPositionY, C_Block_width, C_Block_height);
                FPictureBox.Image = FCanvas;
            }
        }
    }



}
