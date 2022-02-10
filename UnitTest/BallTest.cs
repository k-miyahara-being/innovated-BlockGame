using System;
using System.Windows;
using System.Windows.Forms;
using System.Drawing;
using BreakBlock;
using NUnit.Framework;

namespace UnitTest {
    [TestFixture]
    class BallTest {
        //Reverse()のテスト
        [Test]
        public void 水平方向の時にSpeedのxが反転すること() {
            var wBall = new Ball(0, 0, 0, new Vector(1, 1));
            wBall.Reverse(Orientation.Horizontal);
            Assert.AreEqual(-1, wBall.Speed.X);
        }
        [Test]
        public void 水平方向の時にSpeedのyが反転すること() {
            var wBall = new Ball(0, 0, 0, new Vector(1, 1));
            wBall.Reverse(Orientation.Vertical);
            Assert.AreEqual(-1, wBall.Speed.Y);
        }

        //VsWall()のテスト
        [TestCase(5, 10, 5, HitPointWall.Left, TestName ="左に当たった時にLeftが返ること")]
        [TestCase(15, 10, 5, HitPointWall.Right, TestName = "右に当たった時にRightが返ること")]
        [TestCase(10, 5, 5, HitPointWall.Top, TestName = "上に当たった時にTopが返ること")]
        [TestCase(10, 15, 5, HitPointWall.Bottom, TestName = "下に当たった時にBottomが返ること")]
        public void 弾が壁に当たった時にその場所が返ること(int vBallPosX, int vBallPosY, int vBallRadius, HitPointWall vExpected) {
            var wBall = new Ball(vBallPosX, vBallPosY, vBallRadius, new Vector(0, 0));
            HitPointWall? wResult = wBall.VsWall(20, 20);
            Assert.AreEqual(vExpected, wResult);
        }

        //VsBar()のテスト
        [TestCase(5, HitPointBar.First, TestName ="Firstが返ること")]
        [TestCase(15, HitPointBar.Second, TestName = "Secondが返ること")]
        [TestCase(25, HitPointBar.Third, TestName = "Thirdが返ること")]
        [TestCase(35, HitPointBar.Fourth, TestName = "Fourthが返ること")]
        [TestCase(45, HitPointBar.Fifth, TestName = "Fifthが返ること")]
        public void barに当たった部分が返ること(int vBallPosX, HitPointBar vExpected) {
            var wBall = new Ball(vBallPosX, 10, 1, new Vector(0, 0));
            HitPointBar? wResult = wBall.VsBar(new Bar(0, 10, 50, 10, 10));
            Assert.AreEqual(vExpected, wResult);
        }
        //VsBlock()のテスト
        [TestCase(20, 5, 6, 0, 1, Orientation.Vertical, TestName ="ブロックの上に当たった時にVerticalが返ること")]
        [TestCase(20, 25, 6, 0, -1, Orientation.Vertical, TestName = "ブロックの下に当たった時にVerticalが返ること")]
        [TestCase(5, 15, 6, 1, 0, Orientation.Horizontal, TestName = "ブロックの左に当たった時にHorizontalが返ること")]
        [TestCase(35, 15, 6, -1, 0, Orientation.Horizontal, TestName = "ブロックの右に当たった時にHorizontalが返ること")]
        public void 弾がブロックに当たった時に弾の方向が返ること(int vBallPosX, int vBallPosY, int vBallRadius, int vBallSpeedX, int vBallSpeedY, Orientation vExpected) {
            var wBall = new Ball(vBallPosX, vBallPosY, vBallRadius, new Vector(0, 0));
            wBall.Speed = new Vector(vBallSpeedX, vBallSpeedY);
            Orientation? wResult = wBall.VsBlock(new Rectangle(10 ,10, 20, 10));
            Assert.AreEqual(vExpected, wResult);
        }
    }
}
