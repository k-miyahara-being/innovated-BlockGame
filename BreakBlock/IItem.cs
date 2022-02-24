using System.Drawing;

namespace BreakBlock {
    public interface IItem {
        Image ItemImage { get; }
        Rectangle Rect { get; }
    }
}
