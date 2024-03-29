﻿using System.Runtime.Serialization;

namespace BreakBlock {
    /// <summary>
    /// ゲーム設定クラス
    /// </summary>
    [DataContract]
    public class GameSetting {
        /// <summary>
        /// 残弾数
        /// </summary>
        [DataMember]
        public int BallNum { get; set; }
        /// <summary>
        /// 弾の半径
        /// </summary>
        [DataMember]
        public int BallRadius { get; set; }
        /// <summary>
        /// ブロックの縦の数
        /// </summary>
        [DataMember]
        public int BlockRowNum { get; set; }
        /// <summary>
        /// ブロックの横の数
        /// </summary>
        [DataMember]
        public int BlockColumnNum { get; set; }
        /// <summary>
        /// メタルブロックの個数
        /// </summary>
        [DataMember]
        public int MetalBlockNum { get; set; }
        /// <summary>
        /// バーの幅
        /// </summary>
        [DataMember]
        public int BarWidth { get; set; }
        /// <summary>
        /// バーの高さ
        /// </summary>
        [DataMember]
        public int BarHeight { get; set; }
    }
}
