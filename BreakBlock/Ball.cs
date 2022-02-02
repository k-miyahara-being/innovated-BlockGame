using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media;

namespace BreakBlock {
    /// <summary>
    /// 弾のコレクションクラス
    /// </summary>
    class BallCollection {
        /// <summary>
        /// 弾のコレクション
        /// </summary>
        public Stack<Ball> Balls { get; set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="vPictureBox">描画先</param>
        public BallCollection(int vX, int vY, int vNum) {
            this.Balls = new Stack<Ball>();
            for (int i = 0; i < vNum; i++) {
                this.Balls.Push(new Ball(vX, vY));
            }
        }
    }
    /// <summary>
    /// 弾クラス
    /// </summary>
    class Ball {
        /// <summary>
        /// x,y座標
        /// </summary>
        public Vector Position { get; set; }
        /// <summary>
        /// スピード
        /// </summary>
        public Vector Speed { get; set; }
        /// <summary>
        /// 弾のリスト
        /// </summary>
        public Stack<Ball> Balls { get; set; }

        // 短時間でRandomのインスタンスを複数生成すると同一の乱数セットが生成され、弾が同じ方向に飛びます。
        // そのため、単一のオブジェクトを使いまわしています。
        private static Random G_Rnd = new Random();
        private int AccelerationCounter = 0;

        /// <summary>
        /// 弾のコンストラクタ
        /// </summary>       
        public Ball(int vX, int vY) {
            this.Position = new Vector(vX, vY);
            float wAngle = G_Rnd.Next(Define.C_AngleMin, Define.C_AngleMax);
            if (G_Rnd.Next() % 2 == 0) {
                wAngle *= -1;
            } else {
                wAngle *= 1;
            }
            this.Speed = new Vector(0, Define.C_InitialVelocity);
            var wMatrixAffine = new Matrix();
            wMatrixAffine.Rotate(wAngle);
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

        public void ChangeDirection(Matrix vMatrixAffine) {
            var wSpeed = new Vector(0, Define.C_InitialVelocity);
            this.Speed = Vector.Multiply(wSpeed, vMatrixAffine);
            //弾の速度を維持するための処理
            this.Speed *= Math.Pow(Define.C_Acceleration, AccelerationCounter);
        }

        /// <summary>
        /// 弾を加速させる
        /// </summary>
        public void Accelerate() {
            AccelerationCounter++;
            this.Speed *= Define.C_Acceleration;
        }
    }
}
