namespace BreakBlock {
    /// <summary>
    /// コンボボックスのItemクラス
    /// </summary>
    public class DifficultyItem {
        /// <summary>
        /// コンボボックスに表示する文字列
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// プログラムで扱う文字列
        /// </summary>
        public GameSetting Value { get; set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="vText"></param>
        /// <param name="vValue"></param>
        public DifficultyItem(string vText, GameSetting vValue) {
            this.Text = vText;
            this.Value = vValue;
        }

        /// <summary>
        /// コンボボックスに文字列を表示する
        /// </summary>
        /// <returns></returns>
        public override string ToString() => this.Text;
    }
}
