using System.Drawing;

namespace BreakBlock {
    public class AdditionBallItem : ItemBase {
        public override Image ItemImage => Image.FromFile("");


        public AdditionBallItem() : base() {

        }

        public override Rectangle RunBar(Rectangle vBar) {
            throw new System.NotImplementedException();
        }

        //TODO 増やす処理
        //private int AddRemainingBall(int vBallNum) {

        //}
    }
}
