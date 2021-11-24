using System;
using System.Collections.Generic;
using System.Drawing;
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

        private Random Rnd;

        /// <summary>
        /// ボールのコンストラクタ
        /// </summary>       
        public Ball(int vX, int vY) {
            this.Position = new Vector(vX, vY);
            // TODO:スピードが変わる問題を解決
            Rnd = new Random();
            float wRnd1 = Rnd.Next(20, 70);
            int wRnd2 = Rnd.Next();
            if (wRnd2 % 2 == 0) {
                wRnd1 *= -1;
            } else {
                wRnd1 *= 1;
            }
            this.Speed = new Vector(0, -4);
            var wMatrixAffine = new Matrix();
            wMatrixAffine.Rotate(wRnd1);
            this.Speed = Vector.Multiply(this.Speed, wMatrixAffine);
        }
        
        /// <summary>
        /// ボールを動かす
        /// </summary>
        public void Move() { 
                this.Position += this.Speed;
        }
    }

}


