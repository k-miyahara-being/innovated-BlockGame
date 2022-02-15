using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakBlock {
    public class DifficultyItem {
        public string Text { get; set; }
        public string Value { get; set; }

        public DifficultyItem(string vText, string vValue) {
            this.Text = vText;
            this.Value = vValue;
        }

        public override string ToString() {
            return this.Text;
        }
    }
}
