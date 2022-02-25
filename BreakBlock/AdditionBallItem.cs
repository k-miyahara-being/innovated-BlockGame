using System.Collections.Generic;
using System.Drawing;

namespace BreakBlock {
    public class AdditionBallItem : ItemBase {
        public override Image ItemImage => Image.FromFile("../../Img/ItemImage.jpg");
        /// <summary>
        /// 残弾数を1つ増やす
        /// </summary>
        /// <param name="vBalls">弾のコレクション</param>
        /// <param name="vBall">増やす弾</param>
        /// <returns>弾のコレクション</returns>
        public override Stack<IBall> RunBall(Stack<IBall> vBalls, Ball vBall) {
            vBalls.Push(vBall);
            return vBalls;
        }
    }
}
