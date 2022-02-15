using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakBlock {
    public abstract class BlockBase : IBlock {
        public Rectangle Rect { get; set; }
        public abstract Brush Color { get; }
        public abstract int Endurance { get; set; }
        public BlockBase(int vPositionX, int vPositionY, int vWidth, int vHeight) {
            this.Rect = new Rectangle(vPositionX, vPositionY, vWidth, vHeight);
        }
    }
}
