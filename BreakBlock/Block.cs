using System.Drawing;
using System.Windows.Forms;


namespace BreakBlock {
    /// <summary>
    /// ブロッククラス
    /// </summary>
    class Block {       
        public int Block_width { get; set; } = 50;　
        public int Block_height { get; set; } = 20;　

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
        public int BlockBottom => this.BlockPositionY + Block_height;
        /// <summary>
        /// ブロックの左辺
        /// </summary>
        public int BlockLeft => this.BlockPositionX;
        /// <summary>
        /// ブロックの右辺
        /// </summary>
        public int BlockRight => this.BlockPositionX + Block_width;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="vX"></param>
        /// <param name="vY"></param>
        public Block(int vX, int vY) {
            this.BlockPositionX = vX;
            this.BlockPositionY = vY;
        }
    }



}
