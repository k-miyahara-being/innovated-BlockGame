﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakBlock {
    public static class Define {
        public static readonly int C_BallRadius = 8;

        public static readonly int C_BarPositionY = 350;
        public static readonly int C_BarWidth = 90;
        public static readonly int C_BarHeight = 8;
        public static readonly int C_BarMoveDistance = 20;

        public static readonly int C_BlockFirstPositionX = 10;
        public static readonly int C_BlockFirstPositionY = 20;
        public static readonly int C_BlockWidth = 50;
        public static readonly int C_BlockHeight = 20;
        public static readonly int C_BlockGap = 5;
        public static readonly int C_BlockColumnNum = 4;
        public static readonly int C_BlockRowNum = 6;
    }
    public enum BarDirection {
        Left = -1,
        Right = 1
    }
    public enum Line {
        Top,
        Bottom,
        Right,
        Left,
        Exception
    }
    public enum Status {
        Start,
        Ready,
        Playing,
        GameOver,
        Clear
    }
}
