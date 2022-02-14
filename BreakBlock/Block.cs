using System.Drawing;

namespace BreakBlock {
    /// <summary>
    /// ブロッククラス
    /// </summary>
    public class Block : IBlock {
        /// <summary>
        /// ブロックの実体
        /// </summary>
        public Rectangle Rect { get; set; }
        /// <summary>
        /// 色
        /// </summary>
        public Brush Color { get; set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="vPositionX">X座標</param>
        /// <param name="vPositionY">Y座標</param>
        /// <param name="vWidth">幅</param>
        /// <param name="vHeight">高さ</param>
        /// <param name="vColor">色</param>
        public Block(int vPositionX, int vPositionY, int vWidth, int vHeight, Brush vColor) {
            this.Rect = new Rectangle(vPositionX, vPositionY, vWidth, vHeight);
            this.Color = vColor;
        }
    }
    /// <summary>
    /// メタルブロッククラス
    /// </summary>
    public class MetalBlock : IBlock {
        /// <summary>
        /// ブロックの実体
        /// </summary>
        public Rectangle Rect { get; set; }
        /// <summary>
        /// 色
        /// </summary>
        public Brush Color { get; set; }
        /// <summary>
        /// 耐久力
        /// </summary>
        public int Endurance { get; set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="vPositionX">X座標</param>
        /// <param name="vPositionY">Y座標</param>
        /// <param name="vWidth">幅</param>
        /// <param name="vHeight">高さ</param>
        /// <param name="vColor">色</param>
        /// <param name="vEndurance">耐久力</param>
        public MetalBlock(int vPositionX, int vPositionY, int vWidth, int vHeight, Brush vColor, int vEndurance) {
            this.Rect = new Rectangle(vPositionX, vPositionY, vWidth, vHeight);
            this.Color = vColor;
            this.Endurance = vEndurance;
        }

    }
}
