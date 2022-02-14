using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakBlock {
    /// <summary>
    /// ブロックインターフェース
    /// </summary>
    public interface IBlock {
        Rectangle Rect { get; set; }
        Brush Color { get; set; }
    }
}
