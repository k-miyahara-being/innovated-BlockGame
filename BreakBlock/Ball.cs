using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows;
using System.Windows.Forms;

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
            double wRndX = Rnd.Next(-5, 5);
            while(wRndX == 0) {
                wRndX = Rnd.Next(-5,5);
            }
            this.Speed = new Vector(wRndX, -4); 
        }
        
        /// <summary>
        /// ボールを動かす
        /// </summary>
        public void Move() { 
                this.Position += this.Speed;
        }
    }

}


