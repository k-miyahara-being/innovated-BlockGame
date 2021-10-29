using System.Drawing;
using System.Windows.Forms;

namespace BreakBlock {
    /// <summary>
    /// バークラス
    /// </summary>
    class Bar {
        
        public int PositionY { get; set; } = 350;
        public int Height { get; set; } = 8; 

        /// <summary>
        /// バーのX座標
        /// </summary>
        public int PositionX { get; set; }
        /// <summary>
        /// バーの幅
        /// </summary>
        public int Width => 90;

        /// <summary>
        /// バーの移動
        /// </summary>
        /// <param name="vDirection">動くX方向</param>
        public void MoveBar(int vDirection) {
            // TODO:移動処理を書く＋移動範囲の処理を書き直す
        }
    }
}
