using System.Drawing;

namespace BreakBlock {
    public class LongBarItem : ItemBase {
        public override Image ItemImage => Image.FromFile("");

        public LongBarItem() : base() {
        }

        //TODO 伸ばす処理
        //private int ExtendBar(int vBarWidth) {
        //}
    }
}
