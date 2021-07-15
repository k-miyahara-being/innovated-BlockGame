
namespace BreakBlock
{
    partial class FormBreakBlock
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
            this.labelGameover = new System.Windows.Forms.Label();
            this.ResultLabelScore = new System.Windows.Forms.Label();
            this.ResultTextScore = new System.Windows.Forms.Label();
            this.labelScore = new System.Windows.Forms.Label();
            this.textScore = new System.Windows.Forms.Label();
            this.buttonContinue = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.labelClear = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.labelGameover);
            this.panel2.Controls.Add(this.ResultLabelScore);
            this.panel2.Controls.Add(this.ResultTextScore);
            this.panel2.Controls.Add(this.labelScore);
            this.panel2.Controls.Add(this.textScore);
            this.panel2.Controls.Add(this.buttonContinue);
            this.panel2.Controls.Add(this.buttonStart);
            this.panel2.Controls.Add(this.labelClear);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(568, 608);
            this.panel2.TabIndex = 1;
            // 
            // labelGameover
            // 
            this.labelGameover.AutoSize = true;
            this.labelGameover.BackColor = System.Drawing.Color.Blue;
            this.labelGameover.Font = new System.Drawing.Font("MS UI Gothic", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelGameover.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.labelGameover.Location = new System.Drawing.Point(134, 210);
            this.labelGameover.Name = "labelGameover";
            this.labelGameover.Size = new System.Drawing.Size(261, 44);
            this.labelGameover.TabIndex = 4;
            this.labelGameover.Text = "GAME OVER";
            this.labelGameover.Visible = false;
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
            // labelScore
            // 
            this.labelScore.AutoSize = true;
            this.labelScore.Font = new System.Drawing.Font("MS UI Gothic", 17F);
            this.labelScore.ForeColor = System.Drawing.Color.White;
            this.labelScore.Location = new System.Drawing.Point(503, 562);
            this.labelScore.Name = "labelScore";
            this.labelScore.Size = new System.Drawing.Size(32, 34);
            this.labelScore.TabIndex = 4;
            this.labelScore.Text = "0";
            this.labelScore.Visible = false;
            // 
            // textScore
            // 
            this.textScore.AutoSize = true;
            this.textScore.Font = new System.Drawing.Font("MS UI Gothic", 17F);
            this.textScore.ForeColor = System.Drawing.Color.White;
            this.textScore.Location = new System.Drawing.Point(380, 558);
            this.textScore.Name = "textScore";
            this.textScore.Size = new System.Drawing.Size(111, 34);
            this.textScore.TabIndex = 3;
            this.textScore.Text = "score：";
            this.textScore.Visible = false;
            // 
            // buttonContinue
            // 
            this.buttonContinue.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.buttonContinue.Font = new System.Drawing.Font("MS UI Gothic", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonContinue.Location = new System.Drawing.Point(185, 470);
            this.buttonContinue.Name = "buttonContinue";
            this.buttonContinue.Size = new System.Drawing.Size(210, 70);
            this.buttonContinue.TabIndex = 2;
            this.buttonContinue.Text = "Continue";
            this.buttonContinue.UseVisualStyleBackColor = false;
            this.buttonContinue.Visible = false;
            this.buttonContinue.Click += new System.EventHandler(this.buttonContinue_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.buttonStart.Font = new System.Drawing.Font("MS UI Gothic", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonStart.Location = new System.Drawing.Point(195, 257);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(200, 70);
            this.buttonStart.TabIndex = 1;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = false;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // labelClear
            // 
            this.labelClear.AutoSize = true;
            this.labelClear.BackColor = System.Drawing.Color.Orange;
            this.labelClear.Font = new System.Drawing.Font("MS UI Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelClear.ForeColor = System.Drawing.Color.Yellow;
            this.labelClear.Location = new System.Drawing.Point(195, 210);
            this.labelClear.Name = "labelClear";
            this.labelClear.Size = new System.Drawing.Size(165, 48);
            this.labelClear.TabIndex = 3;
            this.labelClear.Text = "CLEAR";
            this.labelClear.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(568, 608);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 20;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FormBreakBlock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(568, 608);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(590, 782);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(590, 662);
            this.Name = "FormBreakBlock";
            this.Text = "ブロック崩し";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormBreakBlock_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormBreakBlock_KeyDown);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonContinue;
        private System.Windows.Forms.Label labelClear;
        private System.Windows.Forms.Label labelGameover;
        private System.Windows.Forms.Label textScore;
        private System.Windows.Forms.Label labelScore;
        private System.Windows.Forms.Label ResultLabelScore;
        private System.Windows.Forms.Label ResultTextScore;
    }
}

