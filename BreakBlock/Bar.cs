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


        public Bar(int vBarPositionX) {
            this.PositionX = vBarPositionX;
        }

        /// <summary>
        /// バーの移動
        /// </summary>
        /// <param name="vDirection">動くX方向</param>
        public void MoveBar(BarDirection vDirection) {
            // TODO:移動範囲の処理を追加する
            this.PositionX += Define.C_BarMoveDIstance * (int)vDirection;
        }
    }
}
