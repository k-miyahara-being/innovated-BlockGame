using System.Drawing;

namespace BreakBlock {
    public static class Define {
        //弾関連
        public static readonly int C_BallNum = 3;
        public static readonly double C_Acceleration = 1.05;
        public static readonly int C_LaunchAngleMin = 20;
        public static readonly int C_LaunchAngleMax = 71;
        public static readonly int C_LaunchVelocity = -3;

        public static readonly int C_SmallBallX = 20;
        public static readonly int C_SmallBallY = 383;
        public static readonly int C_SmallBallRadius = 6;

        //バー関連
        public static readonly int C_BarPositionY = 350;
        public static readonly int C_BarMoveDistance = 20;

        //ブロック関連
        public static readonly int C_BlockDrawingAreaWidth = 324;
        public static readonly int C_BlockDrawingAreaHeight = 100;
        public static readonly int C_BlockFirstPositionX = 10;
        public static readonly int C_BlockFirstPositionY = 20;

        //スコア関連
        public static readonly int C_ScoreAddition = 10;
        public static readonly int C_ScoreSubtraction = 20;
        public static readonly int C_ScoreBonus = 30;

        //アニメーションの色
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
    public enum HitPointWall {
        Top,
        Bottom,
        Left,
        Right,
    }
    public enum HitPointBar {
        First,
        Second,
        Third,
        Fourth,
        Fifth,
    }
}
