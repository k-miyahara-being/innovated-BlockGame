using System.Drawing;

namespace BreakBlock {
    public static class Define {
        //弾関連
        public const double C_Acceleration = 1.05;
        public const int C_LaunchAngleMin = 20;
        public const int C_LaunchAngleMax = 71;
        public const int C_LaunchVelocity = -3;

        public const int C_SmallBallX = 20;
        public const int C_SmallBallY = 383;
        public const int C_SmallBallRadius = 6;

        //バー関連
        public const int C_BarPositionY = 350;
        public const int C_BarMoveDistance = 20;

        //ブロック関連
        public const int C_BlockDrawingAreaWidth = 324;
        public const int C_BlockDrawingAreaHeight = 100;
        public const int C_BlockFirstPositionX = 10;
        public const int C_BlockFirstPositionY = 20;
        public static readonly Brush[] BlockColors = new Brush[] {
            Brushes.LightBlue,
            Brushes.CadetBlue,
            Brushes.SteelBlue,
            Brushes.RoyalBlue,
        };

        //スコア関連
        public const int C_ScoreAddition = 10;
        public const int C_ScoreSubtraction = 20;
        public const int C_ScoreBonus = 30;

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
