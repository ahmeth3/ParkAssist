namespace ParkAssist
{
    partial class customMessageBox
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.btnOk = new System.Windows.Forms.Button();
			this.panel2 = new System.Windows.Forms.Panel();
			this.lbCMB = new System.Windows.Forms.Label();
			this.panel3 = new System.Windows.Forms.Panel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel4 = new System.Windows.Forms.Panel();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnOk
			// 
			this.btnOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
			this.btnOk.FlatAppearance.BorderSize = 0;
			this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.btnOk.Location = new System.Drawing.Point(109, 125);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(200, 45);
			this.btnOk.TabIndex = 0;
			this.btnOk.Text = "OK";
			this.btnOk.UseVisualStyleBackColor = false;
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.lbCMB);
			this.panel2.Location = new System.Drawing.Point(33, 26);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(349, 77);
			this.panel2.TabIndex = 1;
			// 
			// lbCMB
			// 
			this.lbCMB.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lbCMB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbCMB.ForeColor = System.Drawing.SystemColors.ControlLight;
			this.lbCMB.Location = new System.Drawing.Point(0, 0);
			this.lbCMB.Name = "lbCMB";
			this.lbCMB.Size = new System.Drawing.Size(349, 77);
			this.lbCMB.TabIndex = 0;
			this.lbCMB.Text = "label1";
			this.lbCMB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panel3
			// 
			this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
			this.panel3.Controls.Add(this.btnOk);
			this.panel3.Controls.Add(this.panel2);
			this.panel3.Location = new System.Drawing.Point(0, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(417, 189);
			this.panel3.TabIndex = 2;
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.panel1.Location = new System.Drawing.Point(0, 189);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(13, 13);
			this.panel1.TabIndex = 3;
			// 
			// panel4
			// 
			this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.panel4.Location = new System.Drawing.Point(417, 0);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(13, 13);
			this.panel4.TabIndex = 4;
			// 
			// customMessageBox
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
			this.ClientSize = new System.Drawing.Size(430, 202);
			this.Controls.Add(this.panel4);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.panel3);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "customMessageBox";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "customMessageBox";
			this.panel2.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label lbCMB;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel4;
	}
}