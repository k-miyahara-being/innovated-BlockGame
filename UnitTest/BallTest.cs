using System;
using System.Windows;
using System.Windows.Forms;
using BreakBlock;
using NUnit.Framework;

namespace UnitTest {
    [TestFixture]
    class BallTest {
        //Reverse()のテスト
        [Test]
        public void 水平方向の時にSpeedのxが反転すること() {
            var wBall = new Ball(0, 0, 0, new Vector(1, 1));
            Ball wBallBeforeReverse = wBall;
            wBall.Reverse(Orientation.Horizontal);
            Assert.IsFalse(Math.Sign(wBallBeforeReverse.Speed.X) != Math.Sign(wBall.Speed.X));
        }
        [Test]
        public void 垂直方向の時にSpeedのyが反転すること() {
            var wBall = new Ball(0, 0, 0, new Vector(1, 1));
            Ball wBallBeforeReverse = wBall;
            wBall.Reverse(Orientation.Vertical);
            Assert.IsFalse(Math.Sign(wBallBeforeReverse.Speed.Y) != Math.Sign(wBall.Speed.Y));
        }
        //VsWall()のテスト
        [Test]
        public void 弾が左の壁に当たった時にLeftが返ること() {
            var wBall = new Ball(1, 1, 1, new Vector(1, 1));
            HitPointWall? wResult = wBall.VsWall(10, 10);
            Assert.AreEqual(HitPointWall.Left, wResult);
        }
        [Test]
        public void 弾が右の壁に当たった時にRightが返ること() {
            var wBall = new Ball(6, 5, 5, new Vector(1, 1));
            HitPointWall? wResult = wBall.VsWall(10, 10);
            Assert.AreEqual(HitPointWall.Right, wResult);
        }
        [Test]
        public void 弾が上の壁に当たった時にTopが返ること() {
            var wBall = new Ball(2, 1, 1, new Vector(1, 1));
            HitPointWall? wResult = wBall.VsWall(10, 10);
            Assert.AreEqual(HitPointWall.Top, wResult);
        }
        public void 弾が下の壁に当たった時にBottomが返ること() {
            var wBall = new Ball(5, 5, 5, new Vector(1, 1));
            HitPointWall? wResult = wBall.VsWall(10, 10);
            Assert.AreEqual(HitPointWall.Bottom, wResult);
        }
    }
}
