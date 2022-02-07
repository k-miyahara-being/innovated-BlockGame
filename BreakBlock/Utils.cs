using System;
using System.Windows;

namespace BreakBlock {
    public static class Utils {
        /// <summary>
        /// 円と線分の当たり判定
        /// </summary>
        /// <param name="vPoint1">線分の左端の座標</param>
        /// <param name="vPoint2">線分の右端の座標</param>
        /// <param name="vBallCenter">円の中心座標</param>
        /// <param name="vBallRadius">円の半径</param>
        /// <returns>円が線分に当たったらTrue、当たらなかったらFalse</returns>
        public static bool IsCircleHitLine(Vector vPoint1, Vector vPoint2, Vector vBallCenter, int vBallRadius) {
            // 直線の方向ベクトル
            Vector wLineDir = (vPoint2 - vPoint1);
            // 直線の法線ベクトル
            var wN = new Vector(wLineDir.Y, -wLineDir.X);
            wN.Normalize();

            //直線の左端から弾の中心に向かうベクトル
            Vector wDirection1 = vBallCenter - vPoint1;
            //直線の右端から弾の中心に向かうベクトル
            Vector wDirection2 = vBallCenter - vPoint2;

            //内積を求めるローカルメソッド
            double DotProduct(Vector vA, Vector vB) => vA.X * vB.X + vA.Y * vB.Y;

            //直線と弾の間の距離
            double wDistance = Math.Abs(DotProduct(wDirection1, wN));
            //ベクトルwDirection1とベクトルwLineDirの内積
            double wA1 = DotProduct(wDirection1, wLineDir);
            //ベクトルwDirection2とベクトルwLineDirの内積
            double wA2 = DotProduct(wDirection2, wLineDir);

            return (wA1 * wA2 < 0 && wDistance < vBallRadius) ? true : false;
        }

    }
}
