namespace ParkAssist
{
    partial class clanoviSluzbe
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(clanoviSluzbe));
			this.panelZaClanove = new System.Windows.Forms.Panel();
			this.btnDodaj = new System.Windows.Forms.Button();
			this.btnAktivni = new System.Windows.Forms.Button();
			this.btnBivsi = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// panelZaClanove
			// 
			this.panelZaClanove.Location = new System.Drawing.Point(38, 286);
			this.panelZaClanove.Name = "panelZaClanove";
			this.panelZaClanove.Size = new System.Drawing.Size(1413, 572);
			this.panelZaClanove.TabIndex = 0;
			this.panelZaClanove.Paint += new System.Windows.Forms.PaintEventHandler(this.panelZaClanove_Paint);
			// 
			// btnDodaj
			// 
			this.btnDodaj.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
			this.btnDodaj.FlatAppearance.BorderSize = 0;
			this.btnDodaj.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnDodaj.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
			this.btnDodaj.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.btnDodaj.Image = ((System.Drawing.Image)(resources.GetObject("btnDodaj.Image")));
			this.btnDodaj.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnDodaj.Location = new System.Drawing.Point(100, 154);
			this.btnDodaj.Name = "btnDodaj";
			this.btnDodaj.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
			this.btnDodaj.Size = new System.Drawing.Size(1288, 80);
			this.btnDodaj.TabIndex = 1;
			this.btnDodaj.Text = "Dodaj      ";
			this.btnDodaj.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnDodaj.UseVisualStyleBackColor = false;
			this.btnDodaj.Click += new System.EventHandler(this.btnDodaj_Click);
			// 
			// btnAktivni
			// 
			this.btnAktivni.FlatAppearance.BorderSize = 0;
			this.btnAktivni.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
			this.btnAktivni.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.btnAktivni.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnAktivni.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Underline);
			this.btnAktivni.ForeColor = System.Drawing.Color.Silver;
			this.btnAktivni.Location = new System.Drawing.Point(0, 0);
			this.btnAktivni.Margin = new System.Windows.Forms.Padding(0);
			this.btnAktivni.Name = "btnAktivni";
			this.btnAktivni.Size = new System.Drawing.Size(744, 100);
			this.btnAktivni.TabIndex = 2;
			this.btnAktivni.Text = "Aktivni";
			this.btnAktivni.UseVisualStyleBackColor = true;
			this.btnAktivni.Click += new System.EventHandler(this.btnAktivni_Click);
			// 
			// btnBivsi
			// 
			this.btnBivsi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
			this.btnBivsi.FlatAppearance.BorderSize = 0;
			this.btnBivsi.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
			this.btnBivsi.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
			this.btnBivsi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnBivsi.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Underline);
			this.btnBivsi.ForeColor = System.Drawing.Color.Gray;
			this.btnBivsi.Location = new System.Drawing.Point(744, 0);
			this.btnBivsi.Margin = new System.Windows.Forms.Padding(0);
			this.btnBivsi.Name = "btnBivsi";
			this.btnBivsi.Size = new System.Drawing.Size(744, 100);
			this.btnBivsi.TabIndex = 3;
			this.btnBivsi.Text = "Bivši";
			this.btnBivsi.UseVisualStyleBackColor = false;
			this.btnBivsi.Click += new System.EventHandler(this.btnBivsi_Click);
			// 
			// clanoviSluzbe
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
			this.Controls.Add(this.btnBivsi);
			this.Controls.Add(this.btnAktivni);
			this.Controls.Add(this.btnDodaj);
			this.Controls.Add(this.panelZaClanove);
			this.Name = "clanoviSluzbe";
			this.Size = new System.Drawing.Size(1488, 896);
			this.Load += new System.EventHandler(this.clanoviSluzbe_Load);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelZaClanove;
        private System.Windows.Forms.Button btnDodaj;
        private System.Windows.Forms.Button btnAktivni;
        private System.Windows.Forms.Button btnBivsi;
    }
}
