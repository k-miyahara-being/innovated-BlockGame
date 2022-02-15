using System.Drawing;

namespace BreakBlock {
    /// <summary>
    /// ブロックインターフェース
    /// </summary>
    public interface IBlock {
        Rectangle Rect { get; set; }
        Brush Color { get; set; }
    }
}
