using System.Windows;
using System.Windows.Forms;
using BreakBlock;
using NUnit.Framework;

namespace UnitTest {
    [TestFixture]
    class BallTest {
        [TestCase(Orientation.Horizontal, -1, 1, TestName = "水平方向の時はxが反転すること")]
        [TestCase(Orientation.Vertical, 1, -1, TestName = "垂直方向の時はyが反転すること")]
        public void Speedが反転すること(Orientation vOrientation, int vResultX, int vResultY) {
            var wBall = new Ball(0, 0);
            wBall.Speed = new Vector(1, 1);
            wBall.Reverse(vOrientation);
            Assert.AreEqual(vResultX, wBall.Speed.X);
            Assert.AreEqual(vResultY, wBall.Speed.Y);
        }
    }
}
