
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
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
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
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(568, 608);
            this.panel2.TabIndex = 1;
            // 
            // remainingBallNum
            // 
            this.remainingBallNum.BackColor = System.Drawing.Color.Transparent;
            this.remainingBallNum.Font = new System.Drawing.Font("MS UI Gothic", 17F);
            this.remainingBallNum.ForeColor = System.Drawing.Color.White;
            this.remainingBallNum.Location = new System.Drawing.Point(86, 564);
            this.remainingBallNum.Name = "remainingBallNum";
            this.remainingBallNum.Size = new System.Drawing.Size(32, 34);
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
            this.label.Location = new System.Drawing.Point(60, 576);
            this.label.Margin = new System.Windows.Forms.Padding(0);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(26, 18);
            this.label.TabIndex = 7;
            this.label.Text = "×";
            this.label.Visible = false;
            // 
            // LabelGameover
            // 
            this.LabelGameover.AutoSize = true;
            this.LabelGameover.BackColor = System.Drawing.Color.Blue;
            this.LabelGameover.Font = new System.Drawing.Font("MS UI Gothic", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LabelGameover.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.LabelGameover.Location = new System.Drawing.Point(134, 210);
            this.LabelGameover.Name = "LabelGameover";
            this.LabelGameover.Size = new System.Drawing.Size(261, 44);
            this.LabelGameover.TabIndex = 4;
            this.LabelGameover.Text = "GAME OVER";
            this.LabelGameover.Visible = false;
            // 
            // ResultLabelScore
            // 
            this.ResultLabelScore.AutoSize = true;
            this.ResultLabelScore.Font = new System.Drawing.Font("MS UI Gothic", 17F);
            this.ResultLabelScore.ForeColor = System.Drawing.Color.White;
            this.ResultLabelScore.Location = new System.Drawing.Point(322, 344);
            this.ResultLabelScore.Name = "ResultLabelScore";
            this.ResultLabelScore.Size = new System.Drawing.Size(32, 34);
            this.ResultLabelScore.TabIndex = 6;
            this.ResultLabelScore.Text = "0";
            this.ResultLabelScore.Visible = false;
            // 
            // ResultTextScore
            // 
            this.ResultTextScore.AutoSize = true;
            this.ResultTextScore.Font = new System.Drawing.Font("MS UI Gothic", 17F);
            this.ResultTextScore.ForeColor = System.Drawing.Color.White;
            this.ResultTextScore.Location = new System.Drawing.Point(201, 341);
            this.ResultTextScore.Name = "ResultTextScore";
            this.ResultTextScore.Size = new System.Drawing.Size(111, 34);
            this.ResultTextScore.TabIndex = 5;
            this.ResultTextScore.Text = "score：";
            this.ResultTextScore.Visible = false;
            // 
            // LabelScore
            // 
            this.LabelScore.AutoSize = true;
            this.LabelScore.Font = new System.Drawing.Font("MS UI Gothic", 17F);
            this.LabelScore.ForeColor = System.Drawing.Color.White;
            this.LabelScore.Location = new System.Drawing.Point(503, 562);
            this.LabelScore.Name = "LabelScore";
            this.LabelScore.Size = new System.Drawing.Size(32, 34);
            this.LabelScore.TabIndex = 4;
            this.LabelScore.Text = "0";
            this.LabelScore.Visible = false;
            // 
            // TextScore
            // 
            this.TextScore.AutoSize = true;
            this.TextScore.Font = new System.Drawing.Font("MS UI Gothic", 17F);
            this.TextScore.ForeColor = System.Drawing.Color.White;
            this.TextScore.Location = new System.Drawing.Point(380, 558);
            this.TextScore.Name = "TextScore";
            this.TextScore.Size = new System.Drawing.Size(111, 34);
            this.TextScore.TabIndex = 3;
            this.TextScore.Text = "score：";
            this.TextScore.Visible = false;
            // 
            // ButtonContinue
            // 
            this.ButtonContinue.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ButtonContinue.Font = new System.Drawing.Font("MS UI Gothic", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ButtonContinue.Location = new System.Drawing.Point(185, 470);
            this.ButtonContinue.Name = "ButtonContinue";
            this.ButtonContinue.Size = new System.Drawing.Size(210, 70);
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
            this.ButtonStart.Location = new System.Drawing.Point(195, 257);
            this.ButtonStart.Name = "ButtonStart";
            this.ButtonStart.Size = new System.Drawing.Size(200, 70);
            this.ButtonStart.TabIndex = 1;
            this.ButtonStart.Text = "Start";
            this.ButtonStart.UseVisualStyleBackColor = false;
            this.ButtonStart.Click += new System.EventHandler(this.ButtonStart_Click);
            // 
            // LabelClear
            // 
            this.LabelClear.AutoSize = true;
            this.LabelClear.BackColor = System.Drawing.Color.Orange;
            this.LabelClear.Font = new System.Drawing.Font("MS UI Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LabelClear.ForeColor = System.Drawing.Color.Yellow;
            this.LabelClear.Location = new System.Drawing.Point(195, 210);
            this.LabelClear.Name = "LabelClear";
            this.LabelClear.Size = new System.Drawing.Size(165, 48);
            this.LabelClear.TabIndex = 3;
            this.LabelClear.Text = "CLEAR";
            this.LabelClear.Visible = false;
            // 
            // PictureBox1
            // 
            this.PictureBox1.BackColor = System.Drawing.Color.Black;
            this.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PictureBox1.Location = new System.Drawing.Point(0, 0);
            this.PictureBox1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(568, 608);
            this.PictureBox1.TabIndex = 0;
            this.PictureBox1.TabStop = false;
            // 
            // Timer
            // 
            this.Timer.Interval = 20;
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // BreakBlockForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(568, 608);
            this.Controls.Add(this.panel2);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(590, 782);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(590, 662);
            this.Name = "BreakBlockForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ブロック崩し";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.BreakBlockForm_Load);
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
    }
}

