using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakBlock {
    /// <summary>
    /// メタルブロッククラス
    /// </summary>
    public class MetalBlock : BlockBase {
        /// <summary>
        /// 色
        /// </summary>
        public override Brush Color => Define.BlockColors[this.Endurance];
        /// <summary>
        /// 耐久力
        /// </summary>
        public override int Endurance { get; set; }
        /// <summary>
        /// メタルブロックの加算スコア
        /// </summary>
        public int ScoreAddition => 2 * Define.C_ScoreAddition;
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="vPositionX">X座標</param>
        /// <param name="vPositionY">Y座標</param>
        /// <param name="vWidth">幅</param>
        /// <param name="vHeight">高さ</param>
        /// <param name="vColor">色</param>
        /// <param name="vEndurance">耐久力</param>
        public MetalBlock(int vPositionX, int vPositionY, int vWidth, int vHeight, int vEndurance) : base(vPositionX, vPositionY, vWidth, vHeight) {
            this.Rect = new Rectangle(vPositionX, vPositionY, vWidth, vHeight);
            this.Endurance = vEndurance;
        }
    }
}
