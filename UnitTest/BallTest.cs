using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using NUnit.Framework;
using BreakBlock;

namespace UnitTest {
    [TestFixture]
    class BallTest {
        [Test]
        public void Move_弾が元の位置から移動している() {
            int C_BallX = 341;
            int C_BallY = 342;
            var wBall = new Ball(C_BallX, C_BallY);
            Vector wPoistionBeforeMove = wBall.Position;
            wBall.Move();
            Assert.AreNotEqual(wPoistionBeforeMove, wBall.Position);
        }
    }
}
