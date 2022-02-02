using System.Collections.Generic;
using System.Drawing;

namespace BreakBlock {
    /// <summary>
    /// ブロッククラス
    /// </summary>
    class Block {
        /// <summary>
        /// ブロックのリスト
        /// </summary>
        public List<Rectangle> Blocks { get; set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="vPositionX">ブロックのX座標</param>
        /// <param name="vPositionY">ブロックのY座標</param>
        /// <param name="vWidth">ブロックの幅</param>
        /// <param name="vHeight">ブロックの高さ</param>
        public Block(int vPositionX, int vPositionY, int vWidth, int vHeight, int vRowNum,int vColumnNum, int vGap) {
            this.Blocks = new List<Rectangle>();
            for (int i = 0; i < vRowNum; i++) {
                for (int j = 0; j < vColumnNum; j++) {
                    int wX = vPositionX + j * (vWidth + vGap);
                    int wY = vPositionY + i * (vHeight + vGap);
                    var wBlock = new Rectangle(wX, wY, vWidth, vHeight);
                    this.Blocks.Add(wBlock);
                }
            }
        }

        /// <summary>
        /// 指定されたブロックを消す
        /// </summary>
        /// <param name="vIndex">消すブロックの位置</param>
        public void RemoveBlock(int vIndex) => this.Blocks.RemoveAt(vIndex);

    }
}
