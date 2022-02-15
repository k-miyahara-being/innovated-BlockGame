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
        /// ノーマルブロックの耐久性(メタルブロックと差別化するため-1に設定している)
        /// </summary>
        public override int Endurance { get; set; } = 0;
        /// <summary>
        /// ノーマルブロックの加算スコア
        /// </summary>
        public override int ScoreAddition => Define.C_ScoreAddition;
        public NormalBlock(int vPositionX, int vPositionY, int vWidth, int vHeight) : base(vPositionX, vPositionY, vWidth, vHeight) {
        }
    }
}
