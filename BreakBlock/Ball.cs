using System;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media;

namespace BreakBlock {
    class Ball {
        /// <summary>
        /// x,y座標
        /// </summary>
        public Vector Position { get; set; }
        /// <summary>
        /// スピード
        /// </summary>
        public Vector Speed { get; set; }

        private Random FRnd;

        /// <summary>
        /// 弾のコンストラクタ
        /// </summary>       
        public Ball(int vX, int vY) {
            this.Position = new Vector(vX, vY);
            FRnd = new Random();
            float wRnd1 = FRnd.Next(Define.C_AngleMin, Define.C_AngleMax);
            int wRnd2 = FRnd.Next();
            if (wRnd2 % 2 == 0) {
                wRnd1 *= -1;
            } else {
                wRnd1 *= 1;
            }
            this.Speed = new Vector(0, Define.C_InitialVelocity);
            var wMatrixAffine = new Matrix();
            wMatrixAffine.Rotate(wRnd1);
            this.Speed = Vector.Multiply(this.Speed, wMatrixAffine);
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
        /// 弾を加速させる
        /// </summary>
        public void Accelerate() {
            Vector wSpeed = this.Speed;
            wSpeed.X *= Define.C_Acceleration;
            wSpeed.Y *= Define.C_Acceleration;
            this.Speed = wSpeed;
        }
    }
}
