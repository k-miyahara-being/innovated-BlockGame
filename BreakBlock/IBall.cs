using System.Drawing;
using System.Windows;
using System.Windows.Forms;

namespace BreakBlock {
    public interface IBall {
        Vector Position { get; set; }
        Vector Speed { get; set; }
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
