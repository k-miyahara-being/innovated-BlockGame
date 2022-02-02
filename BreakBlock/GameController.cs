using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows;
using System.Windows.Forms;

namespace BreakBlock {
    /// <summary>
    /// ゲームコントローラクラス
    /// </summary>
    class GameController {
        public int Score { get; set; }
        public Status Bound(Ball vCurrentBall, List<Rectangle> vBlocks, Stack<Ball> vBalls, Bar vBar, PictureBox vPictureBox1, Label vLabelScore) {
            //左右の壁に当たった際の跳ね返り
            if (vCurrentBall.Position.X + Define.C_BallRadius > vPictureBox1.Width || vCurrentBall.Position.X - Define.C_BallRadius < 0) {
                vCurrentBall.Reverse(Orientation.Horizontal);
            }
            //上の壁に当たった際の跳ね返り
            if (vCurrentBall.Position.Y - Define.C_BallRadius < 0) {
                vCurrentBall.Reverse(Orientation.Vertical);
            }
            //下の壁に当たってゲームオーバー
            if (vCurrentBall.Position.Y + Define.C_BallRadius >= vPictureBox1.Height) {
                if (vBalls.Count == 0) return Status.GameOver;

                return Status.Ready;
            }
            //バーの左部分に当たった際の跳ね返り
            if (LineVsCircle(new Vector(vBar.Rect.X, Define.C_BarPositionY),
                new Vector(vBar.Rect.X + Define.C_BarWidth / 3, Define.C_BarPositionY), vCurrentBall.Position, Define.C_BallRadius)) {
                vCurrentBall.Reverse(Orientation.Vertical);
                if (vCurrentBall.Speed.X > 0) {
                    vCurrentBall.Reverse(Orientation.Horizontal);
                }
            }
            //バーの右部分に当たった際の跳ね返り
            if (LineVsCircle(new Vector(vBar.Rect.X + 2 * Define.C_BarWidth / Define.C_BarSection, Define.C_BarPositionY),
                new Vector(vBar.Rect.X + Define.C_BarWidth, Define.C_BarPositionY), vCurrentBall.Position, Define.C_BallRadius)) {
                vCurrentBall.Reverse(Orientation.Vertical);
                if (vCurrentBall.Speed.X < 0) {
                    vCurrentBall.Reverse(Orientation.Horizontal);
                }
            }
            //バーの真ん中部分に当たった際の跳ね返り
            if (LineVsCircle(new Vector(vBar.Rect.X + Define.C_BarWidth / Define.C_BarSection, Define.C_BarPositionY),
                new Vector(vBar.Rect.X + 2 * Define.C_BarWidth / Define.C_BarSection, Define.C_BarPositionY), vCurrentBall.Position, Define.C_BallRadius)) {
                vCurrentBall.Reverse(Orientation.Vertical);
            }
            //バーでのランダム跳ね返り
            this.BarVsBall(vBar, vCurrentBall);

            //ブロックに当たった際の跳ね返り・加速とブロックを消す処理
            for (int i = 0; i < vBlocks.Count; i++) {
                Orientation? collision = BlockVsCircle(vBlocks[i], vCurrentBall);
                if (collision != null) {
                    vCurrentBall.Reverse(collision.Value);
                    vCurrentBall.Accelerate();
                    vBlocks.RemoveAt(i);
                    this.Score += Define.C_ScoreAddition;
                    vLabelScore.Text = this.Score.ToString();
                    break;
                }
            }
            return vBlocks.Any() ? Status.Playing : Status.Clear;
        }

        /// <summary>
        /// 直線と弾の当たり判定
        /// </summary>
        /// <param name="vPoint1">直線の左端の座標</param>
        /// <param name="vPoint2">直線の右端の座標</param>
        /// <param name="vBallCenter">弾の中心座標</param>
        /// <param name="vBallRadius">弾の半径</param>
        /// <returns>直線との当たり判定</returns>
        bool LineVsCircle(Vector vPoint1, Vector vPoint2, Vector vBallCenter, float vBallRadius) {
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
        private void BarVsBall(Bar vBar, Ball vCurrentBall) {
            var wMatrixAffine = new System.Windows.Media.Matrix();
            var wRandomAngle = new Random();
            if (LineVsCircle(new Vector(vBar.Rect.X, Define.C_BarPositionY),
                new Vector(vBar.Rect.X + Define.C_BarWidth / 5, Define.C_BarPositionY), vCurrentBall.Position, Define.C_BallRadius)) {
                wMatrixAffine.Rotate(wRandomAngle.Next(-70, -59));
                vCurrentBall.ChangeDirection(wMatrixAffine);
            }
            if (LineVsCircle(new Vector(vBar.Rect.X + Define.C_BarWidth / 5, Define.C_BarPositionY),
                new Vector(vBar.Rect.X + Define.C_BarWidth * 2 / 5, Define.C_BarPositionY), vCurrentBall.Position, Define.C_BallRadius)) {
                wMatrixAffine.Rotate(wRandomAngle.Next(-35, -29));
                vCurrentBall.ChangeDirection(wMatrixAffine);
            }
            if (LineVsCircle(new Vector(vBar.Rect.X + Define.C_BarWidth * 2 / 5, Define.C_BarPositionY),
                new Vector(vBar.Rect.X + Define.C_BarWidth * 3 / 5, Define.C_BarPositionY), vCurrentBall.Position, Define.C_BallRadius)) {
                wMatrixAffine.Rotate(wRandomAngle.Next(-10, 11));
                vCurrentBall.ChangeDirection(wMatrixAffine);
            }
            if (LineVsCircle(new Vector(vBar.Rect.X + Define.C_BarWidth * 3 / 5, Define.C_BarPositionY),
                new Vector(vBar.Rect.X + Define.C_BarWidth * 4 / 5, Define.C_BarPositionY), vCurrentBall.Position, Define.C_BallRadius)) {
                wMatrixAffine.Rotate(wRandomAngle.Next(30, 36));
                vCurrentBall.ChangeDirection(wMatrixAffine);
            }
            if (LineVsCircle(new Vector(vBar.Rect.X + Define.C_BarWidth * 4 / 5, Define.C_BarPositionY),
                new Vector(vBar.Rect.X + Define.C_BarWidth, Define.C_BarPositionY), vCurrentBall.Position, Define.C_BallRadius)) {
                wMatrixAffine.Rotate(wRandomAngle.Next(60, 71));
                vCurrentBall.ChangeDirection(wMatrixAffine);
            }
        }
        /// <summary>
        /// 弾とブロックの当たり判定
        /// </summary>
        /// <param name="vBlock">ブロック</param>
        /// <param name="vBall">弾</param>
        /// <returns>ブロックとの当たり判定</returns>
        private Orientation? BlockVsCircle(Rectangle vBlock, Ball vBall) {
            //上辺と下辺での当たり判定
            if ((vBall.Speed.Y > 0 && LineVsCircle(new Vector(vBlock.Left, vBlock.Top), new Vector(vBlock.Right, vBlock.Top), vBall.Position, Define.C_BallRadius)
                || (vBall.Speed.Y < 0 && LineVsCircle(new Vector(vBlock.Left, vBlock.Bottom), new Vector(vBlock.Right, vBlock.Bottom), vBall.Position, Define.C_BallRadius)))) {
                return Orientation.Vertical;
            }
            //右辺と左辺での当たり判定
            if ((vBall.Speed.X < 0 && LineVsCircle(new Vector(vBlock.Right, vBlock.Top), new Vector(vBlock.Right, vBlock.Bottom), vBall.Position, Define.C_BallRadius)
                || (vBall.Speed.X >= 0 && LineVsCircle(new Vector(vBlock.Left, vBlock.Top), new Vector(vBlock.Left, vBlock.Bottom), vBall.Position, Define.C_BallRadius)))) {
                return Orientation.Horizontal;
            }
            return null;
        }
    }
}
