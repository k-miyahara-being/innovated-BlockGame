
namespace BreakBlock
{
    partial class BreakBlockForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel2 = new System.Windows.Forms.Panel();
            this.LabelScoreBonus = new System.Windows.Forms.Label();
            this.TextScoreBonus = new System.Windows.Forms.Label();
            this.DifficultyBox = new System.Windows.Forms.ComboBox();
            this.remainingBallNum = new System.Windows.Forms.Label();
            this.label = new System.Windows.Forms.Label();
            this.LabelGameover = new System.Windows.Forms.Label();
            this.ResultLabelScore = new System.Windows.Forms.Label();
            this.ResultTextScore = new System.Windows.Forms.Label();
            this.LabelScore = new System.Windows.Forms.Label();
            this.TextScore = new System.Windows.Forms.Label();
            this.ButtonContinue = new System.Windows.Forms.Button();
            this.ButtonStart = new System.Windows.Forms.Button();
            this.LabelClear = new System.Windows.Forms.Label();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.AnimationTimer = new System.Windows.Forms.Timer(this.components);
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.LabelScoreBonus);
            this.panel2.Controls.Add(this.TextScoreBonus);
            this.panel2.Controls.Add(this.DifficultyBox);
            this.panel2.Controls.Add(this.remainingBallNum);
            this.panel2.Controls.Add(this.label);
            this.panel2.Controls.Add(this.LabelGameover);
            this.panel2.Controls.Add(this.ResultLabelScore);
            this.panel2.Controls.Add(this.ResultTextScore);
            this.panel2.Controls.Add(this.LabelScore);
            this.panel2.Controls.Add(this.TextScore);
            this.panel2.Controls.Add(this.ButtonContinue);
            this.panel2.Controls.Add(this.ButtonStart);
            this.panel2.Controls.Add(this.LabelClear);
            this.panel2.Controls.Add(this.PictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(457, 520);
            this.panel2.TabIndex = 1;
            // 
            // LabelScoreBonus
            // 
            this.LabelScoreBonus.AutoSize = true;
            this.LabelScoreBonus.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LabelScoreBonus.ForeColor = System.Drawing.Color.White;
            this.LabelScoreBonus.Location = new System.Drawing.Point(292, 339);
            this.LabelScoreBonus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabelScoreBonus.Name = "LabelScoreBonus";
            this.LabelScoreBonus.Size = new System.Drawing.Size(46, 30);
            this.LabelScoreBonus.TabIndex = 11;
            this.LabelScoreBonus.Text = "0 )";
            this.LabelScoreBonus.Visible = false;
            // 
            // TextScoreBonus
            // 
            this.TextScoreBonus.AutoSize = true;
            this.TextScoreBonus.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TextScoreBonus.ForeColor = System.Drawing.Color.White;
            this.TextScoreBonus.Location = new System.Drawing.Point(133, 339);
            this.TextScoreBonus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TextScoreBonus.Name = "TextScoreBonus";
            this.TextScoreBonus.Size = new System.Drawing.Size(118, 30);
            this.TextScoreBonus.TabIndex = 10;
            this.TextScoreBonus.Text = "( Bonus ";
            this.TextScoreBonus.Visible = false;
            // 
            // DifficultyBox
            // 
            this.DifficultyBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DifficultyBox.Font = new System.Drawing.Font("メイリオ", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DifficultyBox.FormattingEnabled = true;
            this.DifficultyBox.Location = new System.Drawing.Point(138, 313);
            this.DifficultyBox.Margin = new System.Windows.Forms.Padding(4);
            this.DifficultyBox.Name = "DifficultyBox";
            this.DifficultyBox.Size = new System.Drawing.Size(187, 35);
            this.DifficultyBox.TabIndex = 9;
            // 
            // remainingBallNum
            // 
            this.remainingBallNum.BackColor = System.Drawing.Color.Transparent;
            this.remainingBallNum.Font = new System.Drawing.Font("MS UI Gothic", 17F);
            this.remainingBallNum.ForeColor = System.Drawing.Color.White;
            this.remainingBallNum.Location = new System.Drawing.Point(69, 470);
            this.remainingBallNum.Name = "remainingBallNum";
            this.remainingBallNum.Size = new System.Drawing.Size(27, 28);
            this.remainingBallNum.TabIndex = 8;
            this.remainingBallNum.Text = "2";
            this.remainingBallNum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.remainingBallNum.Visible = false;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.BackColor = System.Drawing.Color.Transparent;
            this.label.Font = new System.Drawing.Font("MS UI Gothic", 9F);
            this.label.ForeColor = System.Drawing.Color.White;
            this.label.Location = new System.Drawing.Point(48, 480);
            this.label.Margin = new System.Windows.Forms.Padding(0);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(22, 15);
            this.label.TabIndex = 7;
            this.label.Text = "×";
            this.label.Visible = false;
            // 
            // LabelGameover
            // 
            this.LabelGameover.AutoSize = true;
            this.LabelGameover.BackColor = System.Drawing.Color.Transparent;
            this.LabelGameover.Font = new System.Drawing.Font("MS UI Gothic", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LabelGameover.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.LabelGameover.Location = new System.Drawing.Point(107, 175);
            this.LabelGameover.Name = "LabelGameover";
            this.LabelGameover.Size = new System.Drawing.Size(217, 37);
            this.LabelGameover.TabIndex = 4;
            this.LabelGameover.Text = "GAME OVER";
            this.LabelGameover.Visible = false;
            // 
            // ResultLabelScore
            // 
            this.ResultLabelScore.AutoSize = true;
            this.ResultLabelScore.Font = new System.Drawing.Font("MS UI Gothic", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ResultLabelScore.ForeColor = System.Drawing.Color.White;
            this.ResultLabelScore.Location = new System.Drawing.Point(302, 290);
            this.ResultLabelScore.Name = "ResultLabelScore";
            this.ResultLabelScore.Size = new System.Drawing.Size(36, 38);
            this.ResultLabelScore.TabIndex = 6;
            this.ResultLabelScore.Text = "0";
            this.ResultLabelScore.Visible = false;
            // 
            // ResultTextScore
            // 
            this.ResultTextScore.AutoSize = true;
            this.ResultTextScore.Font = new System.Drawing.Font("MS UI Gothic", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ResultTextScore.ForeColor = System.Drawing.Color.White;
            this.ResultTextScore.Location = new System.Drawing.Point(107, 290);
            this.ResultTextScore.Name = "ResultTextScore";
            this.ResultTextScore.Size = new System.Drawing.Size(124, 38);
            this.ResultTextScore.TabIndex = 5;
            this.ResultTextScore.Text = "score：";
            this.ResultTextScore.Visible = false;
            // 
            // LabelScore
            // 
            this.LabelScore.AutoSize = true;
            this.LabelScore.Font = new System.Drawing.Font("MS UI Gothic", 17F);
            this.LabelScore.ForeColor = System.Drawing.Color.White;
            this.LabelScore.Location = new System.Drawing.Point(403, 468);
            this.LabelScore.Name = "LabelScore";
            this.LabelScore.Size = new System.Drawing.Size(28, 29);
            this.LabelScore.TabIndex = 4;
            this.LabelScore.Text = "0";
            this.LabelScore.Visible = false;
            // 
            // TextScore
            // 
            this.TextScore.AutoSize = true;
            this.TextScore.Font = new System.Drawing.Font("MS UI Gothic", 17F);
            this.TextScore.ForeColor = System.Drawing.Color.White;
            this.TextScore.Location = new System.Drawing.Point(304, 465);
            this.TextScore.Name = "TextScore";
            this.TextScore.Size = new System.Drawing.Size(96, 29);
            this.TextScore.TabIndex = 3;
            this.TextScore.Text = "score：";
            this.TextScore.Visible = false;
            // 
            // ButtonContinue
            // 
            this.ButtonContinue.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ButtonContinue.Font = new System.Drawing.Font("MS UI Gothic", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ButtonContinue.Location = new System.Drawing.Point(148, 392);
            this.ButtonContinue.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ButtonContinue.Name = "ButtonContinue";
            this.ButtonContinue.Size = new System.Drawing.Size(168, 58);
            this.ButtonContinue.TabIndex = 2;
            this.ButtonContinue.Text = "Continue";
            this.ButtonContinue.UseVisualStyleBackColor = false;
            this.ButtonContinue.Visible = false;
            this.ButtonContinue.Click += new System.EventHandler(this.ButtonContinue_Click);
            // 
            // ButtonStart
            // 
            this.ButtonStart.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ButtonStart.Font = new System.Drawing.Font("MS UI Gothic", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ButtonStart.Location = new System.Drawing.Point(156, 214);
            this.ButtonStart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ButtonStart.Name = "ButtonStart";
            this.ButtonStart.Size = new System.Drawing.Size(160, 58);
            this.ButtonStart.TabIndex = 1;
            this.ButtonStart.Text = "Start";
            this.ButtonStart.UseVisualStyleBackColor = false;
            this.ButtonStart.Click += new System.EventHandler(this.ButtonStart_Click);
            // 
            // LabelClear
            // 
            this.LabelClear.AutoSize = true;
            this.LabelClear.BackColor = System.Drawing.Color.Transparent;
            this.LabelClear.Font = new System.Drawing.Font("MS UI Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LabelClear.ForeColor = System.Drawing.Color.Yellow;
            this.LabelClear.Location = new System.Drawing.Point(156, 171);
            this.LabelClear.Name = "LabelClear";
            this.LabelClear.Size = new System.Drawing.Size(139, 40);
            this.LabelClear.TabIndex = 3;
            this.LabelClear.Text = "CLEAR";
            this.LabelClear.Visible = false;
            // 
            // PictureBox1
            // 
            this.PictureBox1.BackColor = System.Drawing.Color.Black;
            this.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PictureBox1.Location = new System.Drawing.Point(0, 0);
            this.PictureBox1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(457, 520);
            this.PictureBox1.TabIndex = 0;
            this.PictureBox1.TabStop = false;
            this.PictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureBox1_MouseDown);
            this.PictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PictureBox1_MouseMove);
            // 
            // Timer
            // 
            this.Timer.Interval = 15;
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // AnimationTimer
            // 
            this.AnimationTimer.Tick += new System.EventHandler(this.AnimationTimer_Tick);
            // 
            // BreakBlockForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(457, 520);
            this.Controls.Add(this.panel2);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(475, 657);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(475, 557);
            this.Name = "BreakBlockForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ブロック崩し";
            this.TopMost = true;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormBreakBlock_KeyDown);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;

        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.PictureBox PictureBox1;
        private System.Windows.Forms.Button ButtonStart;
        private System.Windows.Forms.Button ButtonContinue;
        private System.Windows.Forms.Label LabelClear;
        private System.Windows.Forms.Label LabelGameover;
        private System.Windows.Forms.Label TextScore;
        private System.Windows.Forms.Label LabelScore;
        private System.Windows.Forms.Label ResultLabelScore;
        private System.Windows.Forms.Label ResultTextScore;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label remainingBallNum;
        private System.Windows.Forms.Timer AnimationTimer;
        private System.Windows.Forms.ComboBox DifficultyBox;
        private System.Windows.Forms.Label TextScoreBonus;
        private System.Windows.Forms.Label LabelScoreBonus;
    }
}

