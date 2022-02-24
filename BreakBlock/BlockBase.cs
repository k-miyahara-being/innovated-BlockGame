using System.Drawing;

namespace BreakBlock {
    public abstract class BlockBase : IBlock {
        /// <summary>
        /// 四角形
        /// </summary>
        public Rectangle Rect { get; }
        /// <summary>
        /// 色
        /// </summary>
        public abstract Brush Color { get; }
        /// <summary>
        /// 耐久力
        /// </summary>
        public abstract int Endurance { get; set; }
        /// <summary>
        /// 加算スコア
        /// </summary>
        public virtual int ScoreAddition { get; } = 10;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="vPositionX">X座標</param>
        /// <param name="vPositionY">Y座標</param>
        /// <param name="vWidth">幅</param>
        /// <param name="vHeight">高さ</param>
        public BlockBase(int vPositionX, int vPositionY, int vWidth, int vHeight) {
            this.Rect = new Rectangle(vPositionX, vPositionY, vWidth, vHeight);
        }
    }
}
