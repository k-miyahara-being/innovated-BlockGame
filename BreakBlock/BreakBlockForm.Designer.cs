﻿
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
            this.LabelTextScoreBonus = new System.Windows.Forms.Label();
            this.ComboBoxDifficulty = new System.Windows.Forms.ComboBox();
            this.LabelBallNum = new System.Windows.Forms.Label();
            this.LabelX = new System.Windows.Forms.Label();
            this.LabelGameover = new System.Windows.Forms.Label();
            this.LabelResultScore = new System.Windows.Forms.Label();
            this.LabelResultTextScore = new System.Windows.Forms.Label();
            this.LabelScore = new System.Windows.Forms.Label();
            this.LabelTextScore = new System.Windows.Forms.Label();
            this.ButtonContinue = new System.Windows.Forms.Button();
            this.ButtonStart = new System.Windows.Forms.Button();
            this.LabelClear = new System.Windows.Forms.Label();
            this.PictureBox = new System.Windows.Forms.PictureBox();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.AnimationTimer = new System.Windows.Forms.Timer(this.components);
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.LabelScoreBonus);
            this.panel2.Controls.Add(this.LabelTextScoreBonus);
            this.panel2.Controls.Add(this.ComboBoxDifficulty);
            this.panel2.Controls.Add(this.LabelBallNum);
            this.panel2.Controls.Add(this.LabelX);
            this.panel2.Controls.Add(this.LabelGameover);
            this.panel2.Controls.Add(this.LabelResultScore);
            this.panel2.Controls.Add(this.LabelResultTextScore);
            this.panel2.Controls.Add(this.LabelScore);
            this.panel2.Controls.Add(this.LabelTextScore);
            this.panel2.Controls.Add(this.ButtonContinue);
            this.panel2.Controls.Add(this.ButtonStart);
            this.panel2.Controls.Add(this.LabelClear);
            this.panel2.Controls.Add(this.PictureBox);
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
            // LabelTextScoreBonus
            // 
            this.LabelTextScoreBonus.AutoSize = true;
            this.LabelTextScoreBonus.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LabelTextScoreBonus.ForeColor = System.Drawing.Color.White;
            this.LabelTextScoreBonus.Location = new System.Drawing.Point(133, 339);
            this.LabelTextScoreBonus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabelTextScoreBonus.Name = "LabelTextScoreBonus";
            this.LabelTextScoreBonus.Size = new System.Drawing.Size(118, 30);
            this.LabelTextScoreBonus.TabIndex = 10;
            this.LabelTextScoreBonus.Text = "( Bonus ";
            this.LabelTextScoreBonus.Visible = false;
            // 
            // ComboBoxDifficulty
            // 
            this.ComboBoxDifficulty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxDifficulty.Font = new System.Drawing.Font("メイリオ", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboBoxDifficulty.FormattingEnabled = true;
            this.ComboBoxDifficulty.Location = new System.Drawing.Point(138, 313);
            this.ComboBoxDifficulty.Margin = new System.Windows.Forms.Padding(4);
            this.ComboBoxDifficulty.Name = "ComboBoxDifficulty";
            this.ComboBoxDifficulty.Size = new System.Drawing.Size(187, 35);
            this.ComboBoxDifficulty.TabIndex = 9;
            // 
            // LabelBallNum
            // 
            this.LabelBallNum.BackColor = System.Drawing.Color.Transparent;
            this.LabelBallNum.Font = new System.Drawing.Font("MS UI Gothic", 17F);
            this.LabelBallNum.ForeColor = System.Drawing.Color.White;
            this.LabelBallNum.Location = new System.Drawing.Point(69, 470);
            this.LabelBallNum.Name = "LabelBallNum";
            this.LabelBallNum.Size = new System.Drawing.Size(27, 28);
            this.LabelBallNum.TabIndex = 8;
            this.LabelBallNum.Text = "2";
            this.LabelBallNum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LabelBallNum.Visible = false;
            // 
            // LabelX
            // 
            this.LabelX.AutoSize = true;
            this.LabelX.BackColor = System.Drawing.Color.Transparent;
            this.LabelX.Font = new System.Drawing.Font("MS UI Gothic", 9F);
            this.LabelX.ForeColor = System.Drawing.Color.White;
            this.LabelX.Location = new System.Drawing.Point(48, 480);
            this.LabelX.Margin = new System.Windows.Forms.Padding(0);
            this.LabelX.Name = "LabelX";
            this.LabelX.Size = new System.Drawing.Size(22, 15);
            this.LabelX.TabIndex = 7;
            this.LabelX.Text = "×";
            this.LabelX.Visible = false;
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
            // LabelResultScore
            // 
            this.LabelResultScore.AutoSize = true;
            this.LabelResultScore.Font = new System.Drawing.Font("MS UI Gothic", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LabelResultScore.ForeColor = System.Drawing.Color.White;
            this.LabelResultScore.Location = new System.Drawing.Point(302, 290);
            this.LabelResultScore.Name = "LabelResultScore";
            this.LabelResultScore.Size = new System.Drawing.Size(36, 38);
            this.LabelResultScore.TabIndex = 6;
            this.LabelResultScore.Text = "0";
            this.LabelResultScore.Visible = false;
            // 
            // LabelResultTextScore
            // 
            this.LabelResultTextScore.AutoSize = true;
            this.LabelResultTextScore.Font = new System.Drawing.Font("MS UI Gothic", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LabelResultTextScore.ForeColor = System.Drawing.Color.White;
            this.LabelResultTextScore.Location = new System.Drawing.Point(107, 290);
            this.LabelResultTextScore.Name = "LabelResultTextScore";
            this.LabelResultTextScore.Size = new System.Drawing.Size(124, 38);
            this.LabelResultTextScore.TabIndex = 5;
            this.LabelResultTextScore.Text = "score：";
            this.LabelResultTextScore.Visible = false;
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
            // LabelTextScore
            // 
            this.LabelTextScore.AutoSize = true;
            this.LabelTextScore.Font = new System.Drawing.Font("MS UI Gothic", 17F);
            this.LabelTextScore.ForeColor = System.Drawing.Color.White;
            this.LabelTextScore.Location = new System.Drawing.Point(304, 465);
            this.LabelTextScore.Name = "LabelTextScore";
            this.LabelTextScore.Size = new System.Drawing.Size(96, 29);
            this.LabelTextScore.TabIndex = 3;
            this.LabelTextScore.Text = "score：";
            this.LabelTextScore.Visible = false;
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
            // PictureBox
            // 
            this.PictureBox.BackColor = System.Drawing.Color.Black;
            this.PictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PictureBox.Location = new System.Drawing.Point(0, 0);
            this.PictureBox.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.PictureBox.Name = "PictureBox";
            this.PictureBox.Size = new System.Drawing.Size(457, 520);
            this.PictureBox.TabIndex = 0;
            this.PictureBox.TabStop = false;
            this.PictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureBox1_MouseDown);
            this.PictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PictureBox1_MouseMove);
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
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;

        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.PictureBox PictureBox;
        private System.Windows.Forms.Button ButtonStart;
        private System.Windows.Forms.Button ButtonContinue;
        private System.Windows.Forms.Label LabelClear;
        private System.Windows.Forms.Label LabelGameover;
        private System.Windows.Forms.Label LabelTextScore;
        private System.Windows.Forms.Label LabelScore;
        private System.Windows.Forms.Label LabelResultScore;
        private System.Windows.Forms.Label LabelResultTextScore;
        private System.Windows.Forms.Label LabelX;
        private System.Windows.Forms.Label LabelBallNum;
        private System.Windows.Forms.Timer AnimationTimer;
        private System.Windows.Forms.ComboBox ComboBoxDifficulty;
        private System.Windows.Forms.Label LabelTextScoreBonus;
        private System.Windows.Forms.Label LabelScoreBonus;
    }
}

