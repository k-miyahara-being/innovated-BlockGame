
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelContinue = new System.Windows.Forms.Label();
            this.labelPlay = new System.Windows.Forms.Label();
            this.labelStart = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelClear = new System.Windows.Forms.Label();
            this.ResultLabelScore = new System.Windows.Forms.Label();
            this.ResultTextScore = new System.Windows.Forms.Label();
            this.labelScore = new System.Windows.Forms.Label();
            this.textScore = new System.Windows.Forms.Label();
            this.buttonContinue = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.labelGameover = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.labelContinue);
            this.panel1.Controls.Add(this.labelPlay);
            this.panel1.Controls.Add(this.labelStart);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 618);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(568, 82);
            this.panel1.TabIndex = 0;
            // 
            // labelContinue
            // 
            this.labelContinue.AutoSize = true;
            this.labelContinue.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelContinue.Location = new System.Drawing.Point(80, 25);
            this.labelContinue.Name = "labelContinue";
            this.labelContinue.Size = new System.Drawing.Size(344, 36);
            this.labelContinue.TabIndex = 2;
            this.labelContinue.Text = "コンティニューしますか？";
            this.labelContinue.Visible = false;
            // 
            // labelPlay
            // 
            this.labelPlay.AutoSize = true;
            this.labelPlay.Font = new System.Drawing.Font("MS UI Gothic", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelPlay.Location = new System.Drawing.Point(85, 21);
            this.labelPlay.Name = "labelPlay";
            this.labelPlay.Size = new System.Drawing.Size(365, 40);
            this.labelPlay.TabIndex = 1;
            this.labelPlay.Text = "[Fキー] ⇦　　⇨ [Jキー]";
            this.labelPlay.Visible = false;
            // 
            // labelStart
            // 
            this.labelStart.AutoSize = true;
            this.labelStart.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelStart.Location = new System.Drawing.Point(55, 25);
            this.labelStart.Name = "labelStart";
            this.labelStart.Size = new System.Drawing.Size(421, 36);
            this.labelStart.TabIndex = 0;
            this.labelStart.Text = "スタートボタンを押してください";
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
            this.panel2.Size = new System.Drawing.Size(568, 618);
            this.panel2.TabIndex = 1;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
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
            // ResultLabelScore
            // 
            this.ResultLabelScore.AutoSize = true;
            this.ResultLabelScore.Font = new System.Drawing.Font("MS UI Gothic", 17F);
            this.ResultLabelScore.ForeColor = System.Drawing.Color.White;
            this.ResultLabelScore.Location = new System.Drawing.Point(327, 344);
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
            this.ResultTextScore.Location = new System.Drawing.Point(209, 341);
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
            this.buttonContinue.BackColor = System.Drawing.Color.PaleTurquoise;
            this.buttonContinue.Font = new System.Drawing.Font("MS UI Gothic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonContinue.Location = new System.Drawing.Point(200, 489);
            this.buttonContinue.Name = "buttonContinue";
            this.buttonContinue.Size = new System.Drawing.Size(173, 40);
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
            this.buttonStart.Text = "スタート";
            this.buttonStart.UseVisualStyleBackColor = false;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(568, 618);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 20;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
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
            // FormBreakBlock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(568, 700);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
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
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Label labelStart;
        private System.Windows.Forms.Label labelPlay;
        private System.Windows.Forms.Label labelContinue;
        private System.Windows.Forms.Button buttonContinue;
        private System.Windows.Forms.Label labelClear;
        private System.Windows.Forms.Label labelGameover;
        private System.Windows.Forms.Label textScore;
        private System.Windows.Forms.Label labelScore;
        private System.Windows.Forms.Label ResultLabelScore;
        private System.Windows.Forms.Label ResultTextScore;
    }
}

