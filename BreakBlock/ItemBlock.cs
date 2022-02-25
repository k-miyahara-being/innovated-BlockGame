using System.Drawing;

namespace BreakBlock {
    public class ItemBlock : BlockBase {
        /// <summary>
        /// 色
        /// </summary>
        public override Brush Color => Brushes.Gold;
        /// <summary>
        /// ノーマルブロックの耐久性
        /// </summary>
        public override int Endurance { get; set; } = 0;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="vPositionX">X座標</param>
        /// <param name="vPositionY">Y座標</param>
        /// <param name="vWidth">幅</param>
        /// <param name="vHeight">高さ</param>
        public ItemBlock(int vPositionX, int vPositionY, int vWidth, int vHeight, int vSelecter) : base(vPositionX, vPositionY, vWidth, vHeight) {
            switch (vSelecter) {
                case 0:
                    this.Item = new LongBarItem();
                    break;
                case 1:
                    this.Item = new AdditionBallItem();
                    break;
            }
        }
    }
}
