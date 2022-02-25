using System.Drawing;

namespace BreakBlock {
    public class LongBarItem : ItemBase {
        /// <summary>
        /// バー拡大アイコン
        /// </summary>
        public override Image ItemImage => Image.FromFile("../../Img/ItemImage.jpg");
        /// <summary>
        /// バーの幅を1.5倍にする
        /// </summary>
        /// <param name="vBar">バーオブジェクトのRectプロパティ</param>
        /// <returns>Rectの値</returns>
        public override Rectangle? RunBar(Rectangle vBarRect) {
            return new Rectangle(vBarRect.X, vBarRect.Y, vBarRect.Width * 3 / 2, vBarRect.Height);
        }
    }
}
