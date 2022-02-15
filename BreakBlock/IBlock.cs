using System.Drawing;

namespace BreakBlock {
    /// <summary>
    /// ブロックインターフェース
    /// </summary>
    public interface IBlock {
        Rectangle Rect { get; }
        Brush Color { get; }
        int Endurance { get; set; }
    }
}
