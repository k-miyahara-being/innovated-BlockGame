using System.Drawing;

namespace BreakBlock {
    /// <summary>
    /// ブロッククラス
    /// </summary>
    public class NormalBlock : BlockBase {
        /// <summary>
        /// 色
        /// </summary>
        public override Brush Color => Brushes.LightBlue;

        public int Endurance => 0;
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="vPositionX">X座標</param>
        /// <param name="vPositionY">Y座標</param>
        /// <param name="vWidth">幅</param>
        /// <param name="vHeight">高さ</param>
        /// <param name="vColor">色</param>
        public NormalBlock(int vPositionX, int vPositionY, int vWidth, int vHeight) : base(vPositionX, vPositionY, vWidth, vHeight) {
        }
    }
}
