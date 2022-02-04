using System.Windows;
using System.Windows.Forms;
using BreakBlock;
using NUnit.Framework;

namespace UnitTest {
    [TestFixture]
    class BallTest {

        [Test]
        public void Move_弾が元の位置から移動している() {
            var wBall = new Ball(UnitTestDefine.C_BallPosX, UnitTestDefine.C_BallPosY); 
            Vector wPoistionBeforeMove = wBall.Position;
            wBall.Move();
            Assert.AreNotEqual(wPoistionBeforeMove, wBall.Position);
        }
        //TODO:壁に当たった時の弾の位置を加える
        [TestCase(Orientation.Horizontal)]
        public void Reverse_弾が横の壁に当たった時に弾のxが反転する(Orientation vOrientation) {
            var wBall = new Ball(UnitTestDefine.C_BallPosX, UnitTestDefine.C_BallPosY);
            Ball wBallBeforeReverse = wBall;

            Vector wSpeed = wBallBeforeReverse.Speed;
            wSpeed.X *= -1;
            wBallBeforeReverse.Speed += wSpeed;
            wBall.Reverse(vOrientation);
            Assert.AreEqual(wBallBeforeReverse.Speed, wBall.Speed);
        }
        [TestCase(Orientation.Vertical)]
        public void Reverse_弾が上の壁にあたったときに弾のyが反転する(Orientation vOrientation) {
            var wBall = new Ball(UnitTestDefine.C_BallPosX, UnitTestDefine.C_BallPosY);
            Ball wBallBeforeReverse = wBall;
            Vector wSpeed = wBallBeforeReverse.Speed;
            wSpeed.Y *= -1;
            wBallBeforeReverse.Speed += wSpeed;
            wBall.Reverse(vOrientation);
            Assert.AreEqual(wBallBeforeReverse.Speed, wBall.Speed);
        }
        //TODO:ChangeDirection()のテスト

        [Test]
        public void Accelerate_Speedに加速度が加算されている() {
            var wBall = new Ball(UnitTestDefine.C_BallPosX, UnitTestDefine.C_BallPosY);
            Vector wSpeedBeforeAdd = wBall.Position;
            wBall.Accelerate();
            Assert.AreNotEqual(wSpeedBeforeAdd, wBall.Speed);
        }

    }
}
