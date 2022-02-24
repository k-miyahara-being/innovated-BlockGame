using System.Collections.Generic;
using System.Drawing;

namespace BreakBlock {
    /// <summary>
    /// アイテムの抽象クラス
    /// </summary>
    public abstract class ItemBase : IItem {
        /// <summary>
        /// アイコン画像
        /// </summary>
        public abstract Image ItemImage { get; }
        /// <summary>
        /// アイコンの位置・サイズ
        /// </summary>
        public Rectangle Rect => new Rectangle(100, 380, 110, 30);

        /// <summary>
        /// バーに対する効果
        /// </summary>
        /// <param name="vBarRect">バーオブジェクトのRectプロパティ</param>
        /// <returns>Rectの値</returns>
        public virtual Rectangle? RunBar(Rectangle vBarRect){
            return vBarRect;
        }
        /// <summary>
        /// 弾に対する効果
        /// </summary>
        /// <param name="vBalls">弾のコレクション</param>
        /// <param name="vBall">増やす弾</param>
        /// <returns>弾のコレクション</returns>
        public virtual Stack<IBall> RunBall(Stack<IBall> vBalls, Ball vBall) {
            return vBalls;
        }
    }
}
