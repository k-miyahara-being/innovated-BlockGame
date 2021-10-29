using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows;
using System.Windows.Forms;

namespace BreakBlock {
    class Ball {

        public Vector Position { get; set; }          //横位置(x,y座標)
        public Vector Speed { get; set; }
        public float Radius { get; set; } = 8;         //円の半径

        /// <summary>
        /// ボールのコンストラクタ
        /// </summary>       
        public Ball(int vX, int vY) {
            this.Position = new Vector(vX, vY);
            // TODO:値xをランダムにする
            this.Speed = new Vector(-2, -4); 
        }
        
        /// <summary>
        /// ボールを動かす
        /// </summary>
        public void Move() {
            // TODO:弾の位置の更新処理
            this.Position += this.Speed;
        }
    }

}


