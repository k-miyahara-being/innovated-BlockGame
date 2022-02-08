using System.Windows;
using BreakBlock;
using NUnit.Framework;

namespace UnitTest {
    class UtilsTest {
        [Test]
        public void 円と直線が当たるとTrueを返しそれ以外はfalseが返ること() {
            Assert.IsTrue(Utils.IsCircleHitLine(new Vector(0, 5), new Vector(5, 5), new Vector(3, 3), 3));
            Assert.IsFalse(Utils.IsCircleHitLine(new Vector(0, 5), new Vector(5, 5), new Vector(10, 10), 3));
        }
    }
}
