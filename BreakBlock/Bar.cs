using System.Drawing;

namespace BreakBlock {
    /// <summary>
    /// バークラス
    /// </summary>
    public class Bar {
        /// <summary>
        /// バーの実体
        /// </summary>
        public Rectangle Rect { get; set; }
        /// <summary>
        /// バーの幅
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="vPositionX">バーのX座標</param>
        /// <param name="vPositionY">バーのY座標</param>
        /// <param name="vWidth">バーの幅</param>
        /// <param name="vHeight">バーの高さ</param>
        public Bar(int vPositionX, int vPositionY, int vWidth, int vHeight, int vBoxWidth) {
            this.Rect = new Rectangle(vPositionX, vPositionY, vWidth, vHeight);
            this.Width = vBoxWidth;
        }

        /// <summary>
        /// バーを移動させる
        /// </summary>
        /// <param name="vMoveDistance">移動量(絶対値)</param>
        /// <returns>X方向の移動量</returns>
        public int MoveBar(int vMoveDistance) {
            Rectangle wRect = this.Rect;
            wRect.X += vMoveDistance;
            //バーの幅の3分の1までは壁に入ることができる
            if (wRect.X + Define.C_BarWidth / 3 < 0) {
                wRect.X = -1 * Define.C_BarWidth / 3;
            } else if (wRect.X + 2 * Define.C_BarWidth / 3 > this.Width) {
                wRect.X = this.Width - 2 * Define.C_BarWidth / 3;          
            }
            int wMoveDistance = wRect.X - this.Rect.X;
            this.Rect = wRect;

            return wMoveDistance;
        }
    }
}
