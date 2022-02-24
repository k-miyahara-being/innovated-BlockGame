using System.Drawing;

namespace BreakBlock {
    public class LongBarItem : ItemBase {
        public override Image ItemImage => Image.FromFile("");

        /// <summary>
        /// バーの幅を2倍にする
        /// </summary>
        /// <param name="vBar">バーオブジェクトのRectプロパティ</param>
        /// <returns>Rectの値</returns>
        public override Rectangle RunBar(Rectangle vBarRect) {
            return new Rectangle(vBarRect.X, vBarRect.Y, vBarRect.Width * 2, vBarRect.Height);
        }
    }
}
