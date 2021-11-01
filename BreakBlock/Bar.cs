using System.Drawing;
using System.Windows.Forms;

namespace BreakBlock {
    /// <summary>
    /// バークラス
    /// </summary>
    class Bar {


        /// <summary>
        /// バーのX座標
        /// </summary>
        public int PositionX { get; set; }
        /// <summary>
        /// バーのY座標
        /// </summary>
        public int PositionY => 350;
        /// <summary>
        /// バーの幅
        /// </summary>
        public int Width => 90;
        /// <summary>
        /// バーの高さ
        /// </summary>
        public int Height => 8;


        /// <summary>
        /// バーの移動
        /// </summary>
        /// <param name="vDirection">動くX方向</param>
        public void MoveBar(int vDirection) {
            // TODO:移動範囲の処理を追加する
            this.PositionX += 20 * vDirection;
        }
    }
}
