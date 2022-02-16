using System.Drawing;
using System.Windows;
using System.Windows.Forms;

namespace BreakBlock {
    public interface IBall {
        /// <summary>
        /// 座標
        /// </summary>
        Vector Position { get; set; }
        /// <summary>
        /// 移動量
        /// </summary>
        Vector Speed { get; set; }
        /// <summary>
        /// 半径
        /// </summary>
        int Radius { get; set; }

        void Move();
        void Move(Vector vDistance);
        void Reverse(Orientation vOrientation);
        void ChangeDirection(int vAngle);
        void Accelerate();
        HitPointBar? VsBar(Bar vBar);
        HitPointWall? VsWall(int vWidth, int vHeight);
        Orientation? VsBlock(Rectangle vBlock);
    }
}
