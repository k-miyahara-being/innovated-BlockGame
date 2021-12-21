using System.Drawing;

namespace BreakBlock {
    public static class Define {
        public static readonly int C_BallNum = 3;
        public static readonly int C_BallRadius = 8;
        public static readonly double C_Acceleration = 1.05;
        public static readonly int C_AngleMin = 20;
        public static readonly int C_AngleMax = 71;
        public static readonly int C_InitialVelocity = -5;

        public static readonly int C_SmallBallX = 20;
        public static readonly int C_SmallBallY = 383;
        public static readonly int C_SmallBallRadius = 6;

        public static readonly int C_BarPositionY = 350;
        public static readonly int C_BarWidth = 90;
        public static readonly int C_BarHeight = 8;
        public static readonly int C_BarMoveDistance = 20;
        public static readonly int C_BarSection = 3;

        public static readonly int C_BlockFirstPositionX = 10;
        public static readonly int C_BlockFirstPositionY = 20;
        public static readonly int C_BlockWidth = 50;
        public static readonly int C_BlockHeight = 20;
        public static readonly int C_BlockGap = 5;
        public static readonly int C_BlockColumnNum = 6;
        public static readonly int C_BlockRowNum = 4;

        public static readonly int C_ScoreAddition = 10;
        public static readonly Brush[] GameOverColors = new Brush[] {
            Brushes.Navy,
            Brushes.DarkBlue,
            Brushes.MediumBlue,
            Brushes.Blue,
        };
        public static readonly Brush[] ClearColors = new Brush[] {
            Brushes.Tomato,
            Brushes.OrangeRed,
            Brushes.DarkOrange,
            Brushes.Orange,
        };
    }
    public enum Status {
        Start,
        Ready,
        Playing,
        GameOver,
        Clear
    }
}
