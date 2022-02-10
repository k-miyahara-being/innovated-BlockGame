using System;
using System.Drawing;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media;

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
    public class Ball : IBall {
        /// <summary>
        /// x,y座標
        /// </summary>
        public Vector Position { get; set; }
        /// <summary>
        /// スピード
        /// </summary>
        public Vector Speed { get; set; }
        /// <summary>
        /// 半径
        /// </summary>
        public int Radius { get; set; }

        // 短時間でRandomのインスタンスを複数生成すると同一の乱数セットが生成され、弾が同じ方向に飛びます。
        // そのため、単一のオブジェクトを使いまわしています。
        private static Random G_Rnd = new Random();
        private int FAccelerationCounter = 0;

        /// <summary>
        /// 弾のコンストラクタ
        /// </summary>       
        public Ball(int vX, int vY, int vRadius, Vector vLaunchSpeed) {
            this.Radius = vRadius;
            this.Position = new Vector(vX, vY);
            this.Speed = vLaunchSpeed;
        }

        /// <summary>
        /// 弾を動かす
        /// </summary>
        public void Move() => this.Position += this.Speed;

        /// <summary>
        /// 発射前に弾を動かす
        /// </summary>
        /// <param name="vDistance">移動の方向と量</param>
        public void Move(Vector vDistance) => this.Position += vDistance;

        /// <summary>
        /// 衝突時の弾を反転させる
        /// </summary>
        /// <param name="vDirection">弾の当たった方向</param>
        public void Reverse(Orientation vOrientation) {
            //構造体のプロパティの値を変更しようとすると、コンパイルエラーになりました
            //そのため、構造体のコピーを作り、そのコピーのプロパティの値を変更しコピー元に再代入しています
            //次のページを参照してください
            //https://docs.microsoft.com/ja-jp/dotnet/csharp/language-reference/compiler-messages/cs1612
            Vector wSpeed = this.Speed;
            switch (vOrientation) {
                case Orientation.Horizontal:
                    wSpeed.X *= -1;
                    break;
                case Orientation.Vertical:
                    wSpeed.Y *= -1;
                    break;
            }
            this.Speed = wSpeed;
        }

        /// <summary>
        /// 跳ね返る角度を変える
        /// </summary>
        /// <param name="vAngle"></param>
        public void ChangeDirection(int vAngle) {
            var wMatrixAffine = new Matrix();
            wMatrixAffine.Rotate(vAngle);
            var wSpeed = new Vector(0, Define.C_LaunchVelocity);
            this.Speed = Vector.Multiply(wSpeed, wMatrixAffine);
            //弾の速度を維持するための処理
            this.Speed *= Math.Pow(Define.C_Acceleration, FAccelerationCounter);
        }

        /// <summary>
        /// 弾を加速させる
        /// </summary>
        public void Accelerate() {
            FAccelerationCounter++;
            this.Speed *= Define.C_Acceleration;
        }

        /// <summary>
        /// 壁に当たった時の判定
        /// </summary>
        /// <param name="vWidth">画面の幅</param>
        /// <param name="vHeight">画面の高さ</param>
        /// <returns>当たった箇所</returns>
        public HitPointWall? VsWall(int vWidth, int vHeight) {
            if (this.Position.X - this.Radius <= 0) {
                return HitPointWall.Left;
            }
            if (this.Position.X + this.Radius >= vWidth) {
                return HitPointWall.Right;
            }
            if (this.Position.Y - this.Radius <= 0) {
                return HitPointWall.Top;
            }
            if (this.Position.Y + this.Radius >= vHeight) {
                return HitPointWall.Bottom;
            }
            return null;
        }

        /// <summary>
        /// バーに当たった時の判定
        /// </summary>
        /// <param name="vBar">バーインスタンス</param>
        /// <returns>当たった箇所</returns>
        public HitPointBar? VsBar(Bar vBar) {
            if (Utils.IsCircleHitLine(new Vector(vBar.Rect.X, vBar.Rect.Y),
                new Vector(vBar.Rect.X + vBar.Rect.Width / 5, vBar.Rect.Y), this.Position, this.Radius)) {
                return HitPointBar.First;
            }
            if (Utils.IsCircleHitLine(new Vector(vBar.Rect.X + vBar.Rect.Width / 5, vBar.Rect.Y),
                new Vector(vBar.Rect.X + vBar.Rect.Width * 2 / 5, vBar.Rect.Y), this.Position, this.Radius)) {
                return HitPointBar.Second;
            }
            if (Utils.IsCircleHitLine(new Vector(vBar.Rect.X + vBar.Rect.Width * 2 / 5, vBar.Rect.Y),
                new Vector(vBar.Rect.X + vBar.Rect.Width * 3 / 5, vBar.Rect.Y), this.Position, this.Radius)) {
                return HitPointBar.Third;
            }
            if (Utils.IsCircleHitLine(new Vector(vBar.Rect.X + vBar.Rect.Width * 3 / 5, vBar.Rect.Y),
                new Vector(vBar.Rect.X + vBar.Rect.Width * 4 / 5, vBar.Rect.Y), this.Position, this.Radius)) {
                return HitPointBar.Fourth;
            }
            if (Utils.IsCircleHitLine(new Vector(vBar.Rect.X + vBar.Rect.Width * 4 / 5, vBar.Rect.Y),
                new Vector(vBar.Rect.X + vBar.Rect.Width, vBar.Rect.Y), this.Position, this.Radius)) {
                return HitPointBar.Fifth;
            }
            return null;
        }

        /// <summary>
        ///ブロックに当たった時の判定
        /// </summary>
        /// <param name="vBlock">ブロックインスタンス</param>
        /// <returns>当たった箇所</returns>
        public Orientation? VsBlock(Rectangle vBlock) {
            if ((this.Speed.Y > 0 && Utils.IsCircleHitLine(new Vector(vBlock.Left, vBlock.Top), new Vector(vBlock.Right, vBlock.Top), this.Position, this.Radius)
                || (this.Speed.Y < 0 && Utils.IsCircleHitLine(new Vector(vBlock.Left, vBlock.Bottom), new Vector(vBlock.Right, vBlock.Bottom), this.Position, this.Radius)))) {
                return Orientation.Vertical;
            }
            if ((this.Speed.X < 0 && Utils.IsCircleHitLine(new Vector(vBlock.Right, vBlock.Top), new Vector(vBlock.Right, vBlock.Bottom), this.Position, this.Radius)
                || (this.Speed.X >= 0 && Utils.IsCircleHitLine(new Vector(vBlock.Left, vBlock.Top), new Vector(vBlock.Left, vBlock.Bottom), this.Position, this.Radius)))) {
                return Orientation.Horizontal;
            }
            return null;
        }

    }
}
