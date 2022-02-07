using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using BreakBlock;
using System.Reflection;
using System.Windows;
using System.Windows.Forms;
using System.Drawing;

namespace UnitTest {
    [TestFixture]
    class GameControllerTest {
        //TODO:Bound()のテスト

        [Test]
        public void 弾と直線が当たるとfalseが返ること() {
            var wGameController = new GameController(100, 100);
            Type wType = wGameController.GetType();

            MethodInfo wMethodInfo = wType.GetMethod("IsBallCollidedLine", BindingFlags.NonPublic | BindingFlags.Instance);
            bool wBoolean = (bool)wMethodInfo.Invoke(wGameController, new object[] { new Vector(1, 1), new Vector(2, 2), new Vector(3, 3), 4 });
            Assert.IsFalse(wBoolean);
        }
        [Test]
        public void 弾と直線が当たるとTrueが返ること() {
            var wGameController = new GameController(100, 100);
            Type wType = wGameController.GetType();

            MethodInfo wMethodInfo = wType.GetMethod("IsBallCollidedLine", BindingFlags.NonPublic | BindingFlags.Instance);
            bool wBoolean = (bool)wMethodInfo.Invoke(wGameController, new object[] { new Vector(1, 1), new Vector(4, 1), new Vector(3, 3), 5 });
            Assert.IsTrue(wBoolean);
        }
        //TODO:BarVsBall()メソッドのテスト
        
        //TODO:BlockVsCircle()メソッドのテスト
    }
}
