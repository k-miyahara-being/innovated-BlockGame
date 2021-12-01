using System.Drawing;

namespace BreakBlock {
    /// <summary>
    /// バークラス
    /// </summary>
    class Bar {
        private int FBoxWidth;
        /// <summary>
        /// バーの実体
        /// </summary>
        public Rectangle Rect { get; set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="vPositionX">バーのX座標</param>
        /// <param name="vPositionY">バーのY座標</param>
        /// <param name="vWidth">バーの幅</param>
        /// <param name="vHeight">バーの高さ</param>
        public Bar(int vPositionX, int vPositionY, int vWidth, int vHeight, int vBoxWidth) {
            this.Rect = new Rectangle(vPositionX, vPositionY, vWidth, vHeight);
            FBoxWidth = vBoxWidth;
        }

        /// <summary>
        /// バーの移動
        /// </summary>
        /// <param name="vDirection">動くX方向</param>
        public void MoveBar(BarDirection vDirection) {
            Rectangle wRect = this.Rect;
            wRect.X += Define.C_BarMoveDistance * (int)vDirection;
            //バーの幅の半分までは壁に入ることができる
            if (wRect.X + wRect.Width / 2 < 0) {
                wRect.X = -1 * wRect.Width / 2;
            }
            else if(wRect.X + wRect.Width /2 > FBoxWidth) {
                wRect.X = FBoxWidth - wRect.Width / 2;
            }
            this.Rect = wRect;
        }
    }
}
