using System.Drawing;

namespace BreakBlock {
    /// <summary>
    /// ブロッククラス
    /// </summary>
    public class NormalBlock : BlockBase {
        /// <summary>
        /// ノーマルブロックの色
        /// </summary>
        public override Brush Color => Brushes.LightBlue;
        /// <summary>
        /// ノーマルブロックの耐久性
        /// </summary>
        public override int Endurance { get; set; } = 0;
       
        public NormalBlock(int vPositionX, int vPositionY, int vWidth, int vHeight) : base(vPositionX, vPositionY, vWidth, vHeight) {
        }
    }
}
