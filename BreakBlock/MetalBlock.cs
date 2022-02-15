using System.Drawing;

namespace BreakBlock {
    /// <summary>
    /// メタルブロッククラス
    /// </summary>
    public class MetalBlock : BlockBase {
        /// <summary>
        /// メタルブロックの色
        /// </summary>
        public override Brush Color => Define.BlockColors[this.Endurance];
        /// <summary>
        /// メタルブロックの耐久力
        /// </summary>
        public override int Endurance { get; set; }
        /// <summary>
        /// メタルブロックの加算スコア
        /// </summary>
        public override int ScoreAddition => 2 * base.ScoreAddition;

        public MetalBlock(int vPositionX, int vPositionY, int vWidth, int vHeight, int vEndurance) : base(vPositionX, vPositionY, vWidth, vHeight) {
            this.Endurance = vEndurance;
        }
    }
}
