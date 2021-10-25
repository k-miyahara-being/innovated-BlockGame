using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BreakBlock {
    class Ball {
        private PictureBox FPictureBox; //描画するpictureBox
        private Bitmap FCanvas;         //描画するキャンバス
        private Brush FBrushColor;      //塗りつぶす色
        private int FPreviousX;         //以前の横位置(x座標)
        private int FPreviousY;         //以前の縦位置(y座標)
        private int FPositionX;          //横位置(x座標)
        private int FPositionY;          //縦位置(y座標)
        private int FDirectionX;         //移動方向(x座標)
        private int FDirectionY;         //移動方向(y座標)
        private int FRadius;             //円の半径
        private int FPitch;              //移動の割合
        private int FHitNum;  　　　　　//跳ね返り回数の変数宣言
        private int FAccel;             //加速度
        /// <summary>
        /// スコア
        /// </summary>
        public int Score { get; set; }     
        /// <summary>
        /// ゲームの終了
        /// </summary>
        public int Finish { get; set; }          

        /// <summary>
        /// ボールのコンストラクタ
        /// </summary>
        /// <param name="vPb">ピクチャーボックス</param>
        /// <param name="vCv">キャンバス</param>
        /// <param name="vCl">色</param>        
        public Ball(PictureBox vPb, Bitmap vCv, Brush vCl) {
            FPictureBox = vPb;            //描画するpictureBox
            FCanvas = vCv;                //描画するキャンバス
            FBrushColor = vCl;            //塗りつぶす色
            FRadius = 8;                  //円の半径の初期設定
            FPitch = FRadius / 2;         //移動の割合の初期設定(半径の半分)

            //ランダム発射
            Random wR = new Random();
            int wRandomX = wR.Next(0, 100) % 4;
            if (wRandomX == 0) {
                FDirectionX = -1;        //角度45°
            } else if (wRandomX == 1) {
                FDirectionX = +1;        //角度(180-45)°
            } else if (wRandomX == 2) {
                FDirectionX = +2;        //角度22.5°
                FPitch = FRadius / 3;
            } else if (wRandomX == 3) {
                FDirectionX = -2;        //角度(180-22.5)°
                FPitch = FRadius / 3;
            }
            FDirectionY = -1;
        }

        /// <summary>
        /// 引数で指定した位置にボールを描く
        /// </summary>
        /// <param name="wX">X座標</param>
        /// <param name="wY">Y座標</param>
        public void PutCircle(int wX, int wY) {
            //現在の位置を記憶
            FPositionX = wX;
            FPositionY = wY;

            using (Graphics g = Graphics.FromImage(FCanvas)) {
                //弾をbrushColorで指定された色で描く
                g.FillEllipse(FBrushColor, wX - FRadius, wY - FRadius, FRadius * 2, FRadius * 2);

                FPictureBox.Image = FCanvas;
            }
        }

        /// <summary>
        /// 指定した位置のボールを消す(黒で描く)
        /// </summary>
        public void DeleteCircle() {

            //初めて呼ばれて以前の値が無い時
            if (FPreviousX == 0) {
                FPreviousX = FPositionX;
            }
            if (FPreviousY == 0) {
                FPreviousY = FPositionY;
            }

            using (Graphics g = Graphics.FromImage(FCanvas)) {
                //弾を黒で描く
                g.FillEllipse(Brushes.Black, FPreviousX - FRadius, FPreviousY - FRadius, FRadius * 2, FRadius * 2);

                FPictureBox.Image = FCanvas;
            }

        }

        /// <summary>
        /// ボールを動かす
        /// </summary>
        /// <param name="vBlocks">リストブロック</param>
        public void Move(List<Block> vBlocks) {

            //以前の表示を削除
            DeleteCircle();

            //新しい移動先の計算
            int wX = FPositionX + (FPitch + FAccel) * FDirectionX;
            int wY = FPositionY + (FPitch + FAccel) * FDirectionY;

            //壁で跳ね返る補正
            if (wX >= FCanvas.Width - FRadius) //右端に来た場合の判定
            {
                FDirectionX = -1;
                FPitch = FRadius / 2;
            }
            if (wX <= FRadius) //左端に来た場合の判定
            {
                FDirectionX = +1;
                FPitch = FRadius / 2;
            }
            if (wY <= FRadius) //上端に来た場合の判定
            {
                FDirectionY = +1;
            }
            if (wY >= FCanvas.Height)  //下端に来たときゲームオーバー画面に移る
            {
                this.Finish = 2;
            }

            //ブロックに当たった時の跳ね返りとブロックを消す処理
            for (int wI = 0; wI < vBlocks.Count; wI++) {
                if ((wY >= vBlocks[wI].BlockTop - FRadius) && (wY <= vBlocks[wI].BlockBottom + FRadius) && (wX >= vBlocks[wI].BlockLeft - FRadius) && (wX <= vBlocks[wI].BlockRight + FRadius)) {
                    Acceleration();

                    if ((FPositionY < vBlocks[wI].BlockBottom + FRadius / 2) && (FPositionY > vBlocks[wI].BlockTop - FRadius / 2)) {
                        FDirectionX *= -1; //左右からきた
                    } else if ((FPositionX > vBlocks[wI].BlockLeft - FRadius / 2) && (FPositionX < vBlocks[wI].BlockRight + FRadius / 2)) {
                        FDirectionY *= -1;  //上下からきた
                    } else  //斜めからきた
                      {
                        FDirectionX *= -1;
                        FDirectionY *= -1;
                    }
                    vBlocks[wI].DeleteBlock();
                    vBlocks.RemoveAt(wI);
                    this.Score += 10;
                    break;
                }
            }

            //バーに衝突すると跳ね返る
            
            if (wY >= 350 - FRadius && wY <= 350) {
                if (wX >= Bar.BarPositionX - 10 && wX <= Bar.BarPositionX + 100) {
                    FDirectionY = -1;
                    if (wX < Bar.BarPositionX + 30)　　//バーの左側
                    {
                        FDirectionX = -2;
                        FPitch = 2;
                    }
                    if (wX > Bar.BarPositionX + 60)　　//バーの右側
                    {
                        FDirectionX = +2;
                        FPitch = 2;
                    }
                }
            }

            //跳ね返り補正を反映した値で新しい位置を計算
            FPositionX = wX + FDirectionX;
            FPositionY = wY + FDirectionY;

            //新しい位置に描画
            PutCircle(FPositionX, FPositionY);

            //新しい位置を以前の値として記憶
            FPreviousX = FPositionX;
            FPreviousY = FPositionY;
        }

        /// <summary>
        /// ボールの加速処理
        /// </summary>
        private void Acceleration() {
            FHitNum += 1;
            if (FHitNum == 4) {
                FAccel += 1;
                FHitNum = 0;
            }
        }
    }

}


