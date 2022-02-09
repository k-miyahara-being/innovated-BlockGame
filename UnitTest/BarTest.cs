using BreakBlock;
using NUnit.Framework;

namespace UnitTest {
    [TestFixture]
    class BarTest {
        [TestCase(20, 20, 145, TestName = "右に20移動する")]
        [TestCase(-20, -20, 105, TestName = "左に20移動する")]
        [TestCase(200, 156, 281, TestName = "右端の281より大きくならない")]
        [TestCase(-200, -155, -30, TestName = "左端の-30より小さくならない")]
        public void バーのX座標が移動かつその移動量を返す(int vDistance, int vResultDistance, int vResultX) {
            var wRect = new Bar(125, 350, 90, 8, 341);
            int wDistance = wRect.MoveBar(vDistance);
            Assert.AreEqual(vResultDistance, wDistance);
            Assert.AreEqual(vResultX, wRect.Rect.X);
        }
    }
}
