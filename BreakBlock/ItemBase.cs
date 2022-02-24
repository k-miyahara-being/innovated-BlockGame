using System.Drawing;

namespace BreakBlock {
    /// <summary>
    /// アイテムの抽象クラス
    /// </summary>
    public abstract class ItemBase : IItem {
        /// <summary>
        /// アイコン画像
        /// </summary>
        public abstract Image ItemImage { get; }
        /// <summary>
        /// アイコンの位置・サイズ
        /// </summary>
        public Rectangle Rect => new Rectangle(100, 380, 110, 30);

        public abstract Rectangle RunBar(Rectangle vBarRect);
    }
}
