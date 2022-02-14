using BreakBlock;
using Moq;
using NUnit.Framework;
using System.Drawing;
using System.Windows.Forms;

namespace UnitTest {
    /*[TestFixture]
    class GameControllerTest {
        [TestCase(3, HitPointWall.Bottom, 1, null, Status.Ready, TestName = "残弾ありで下壁にあたるとReadyになる")]
        [TestCase(1, HitPointWall.Bottom, 1, null, Status.GameOver, TestName = "残弾なしで下壁にあたるとGameOverになる")]
        [TestCase(3, null, 2, Orientation.Vertical, Status.Playing, TestName = "ブロックが複数残っている状態でブロックにあたるとPlayingのままになる")]
        [TestCase(3, null, 1, Orientation.Vertical, Status.Clear, TestName = "ブロックが残り1つの状態でブロックにあたるとClearになる")]
        public void 当たり判定によってStatusが変わる(int vBallCount, HitPointWall? vHitPointWall, int vBlockCount, Orientation? vHitPointBlock, Status vResult) {
            var wMock = new Mock<IBall>();
            wMock.Setup(m => m.VsWall(It.IsAny<int>(), It.IsAny<int>())).Returns(vHitPointWall);
            wMock.Setup(m => m.VsBlock(It.IsAny<Rectangle>())).Returns(vHitPointBlock);

            var wGameController = new GameController(100, 100, vBallCount, 1, vBlockCount, 10, 10);
            wGameController.Status = Status.Playing;
            wGameController.Ball = wMock.Object;
            wGameController.Bound();

            Assert.AreEqual(vResult, wGameController.Status);
        }
    }*/
}
