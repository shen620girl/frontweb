namespace WindowsFormEnjoy
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			this.timer2 = new System.Windows.Forms.Timer(this.components);
			this.lblDate = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// timer2
			// 
			this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
			// 
			// lblDate
			// 
			this.lblDate.AutoSize = true;
			this.lblDate.BackColor = System.Drawing.Color.Transparent;
			this.lblDate.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblDate.ForeColor = System.Drawing.Color.Tomato;
			this.lblDate.Location = new System.Drawing.Point(3, 9);
			this.lblDate.Name = "lblDate";
			this.lblDate.Size = new System.Drawing.Size(54, 19);
			this.lblDate.TabIndex = 0;
			this.lblDate.Text = "label1";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.HotTrack;
			this.ClientSize = new System.Drawing.Size(181, 35);
			this.Controls.Add(this.lblDate);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Location = new System.Drawing.Point(226, 191);
			this.Name = "Form1";
			this.Text = "Form1";
			this.TopMost = true;
			this.TransparencyKey = System.Drawing.SystemColors.Highlight;
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label lblDate;
    }
}

