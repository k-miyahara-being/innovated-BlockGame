using System.Drawing;

namespace BreakBlock {
    /// <summary>
    /// ブロックインターフェース
    /// </summary>
    public interface IBlock {
        /// <summary>
        /// 四角形
        /// </summary>
        Rectangle Rect { get; }
        /// <summary>
        /// 色
        /// </summary>
        Brush Color { get; }
        /// <summary>
        /// 耐久力
        /// </summary>
        int Endurance { get; set; }
        /// <summary>
        /// 加算スコア
        /// </summary>
        int ScoreAddition { get; }
    }
}
