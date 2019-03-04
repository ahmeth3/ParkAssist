namespace ParkAssist
{
    partial class loginForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(loginForm));
			this.label1 = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.tbLozinka = new System.Windows.Forms.TextBox();
			this.tbKorisnickoIme = new System.Windows.Forms.TextBox();
			this.cbPrikaziLozinku = new System.Windows.Forms.CheckBox();
			this.btnUlogujSe = new System.Windows.Forms.Button();
			this.btnIzadji = new System.Windows.Forms.Button();
			this.btnPromenaLozinke = new System.Windows.Forms.Button();
			this.lbX = new System.Windows.Forms.Label();
			this.lb_ = new System.Windows.Forms.Label();
			this.lbNemore = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label1.ForeColor = System.Drawing.Color.Silver;
			this.label1.Location = new System.Drawing.Point(7, 7);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(108, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "ParkAssist Login";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(163, 104);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(474, 26);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox1.TabIndex = 1;
			this.pictureBox1.TabStop = false;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Corbel", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label2.ForeColor = System.Drawing.Color.Silver;
			this.label2.Location = new System.Drawing.Point(159, 226);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(135, 24);
			this.label2.TabIndex = 2;
			this.label2.Text = "Korisničko ime";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Corbel", 15F);
			this.label3.ForeColor = System.Drawing.Color.Silver;
			this.label3.Location = new System.Drawing.Point(218, 261);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(76, 24);
			this.label3.TabIndex = 3;
			this.label3.Text = "Lozinka";
			// 
			// tbLozinka
			// 
			this.tbLozinka.BackColor = System.Drawing.Color.Gray;
			this.tbLozinka.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tbLozinka.Cursor = System.Windows.Forms.Cursors.Hand;
			this.tbLozinka.Font = new System.Drawing.Font("Corbel", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.tbLozinka.ForeColor = System.Drawing.Color.White;
			this.tbLozinka.Location = new System.Drawing.Point(310, 261);
			this.tbLozinka.Margin = new System.Windows.Forms.Padding(4);
			this.tbLozinka.Multiline = true;
			this.tbLozinka.Name = "tbLozinka";
			this.tbLozinka.PasswordChar = '*';
			this.tbLozinka.Size = new System.Drawing.Size(327, 24);
			this.tbLozinka.TabIndex = 2;
			this.tbLozinka.TextChanged += new System.EventHandler(this.tbLozinka_TextChanged);
			// 
			// tbKorisnickoIme
			// 
			this.tbKorisnickoIme.BackColor = System.Drawing.Color.Gray;
			this.tbKorisnickoIme.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tbKorisnickoIme.Cursor = System.Windows.Forms.Cursors.Hand;
			this.tbKorisnickoIme.Font = new System.Drawing.Font("Corbel", 15F);
			this.tbKorisnickoIme.ForeColor = System.Drawing.Color.White;
			this.tbKorisnickoIme.Location = new System.Drawing.Point(310, 226);
			this.tbKorisnickoIme.Multiline = true;
			this.tbKorisnickoIme.Name = "tbKorisnickoIme";
			this.tbKorisnickoIme.Size = new System.Drawing.Size(327, 24);
			this.tbKorisnickoIme.TabIndex = 1;
			this.tbKorisnickoIme.TextChanged += new System.EventHandler(this.tbKorisnickoIme_TextChanged);
			this.tbKorisnickoIme.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbKorisnickoIme_KeyPress);
			// 
			// cbPrikaziLozinku
			// 
			this.cbPrikaziLozinku.AutoSize = true;
			this.cbPrikaziLozinku.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cbPrikaziLozinku.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
			this.cbPrikaziLozinku.ForeColor = System.Drawing.Color.Gray;
			this.cbPrikaziLozinku.Location = new System.Drawing.Point(310, 290);
			this.cbPrikaziLozinku.Name = "cbPrikaziLozinku";
			this.cbPrikaziLozinku.Size = new System.Drawing.Size(108, 20);
			this.cbPrikaziLozinku.TabIndex = 6;
			this.cbPrikaziLozinku.Text = "Prikaži lozinku";
			this.cbPrikaziLozinku.UseVisualStyleBackColor = true;
			this.cbPrikaziLozinku.CheckedChanged += new System.EventHandler(this.cbPrikaziLozinku_CheckedChanged);
			// 
			// btnUlogujSe
			// 
			this.btnUlogujSe.BackColor = System.Drawing.Color.Gray;
			this.btnUlogujSe.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
			this.btnUlogujSe.FlatAppearance.BorderSize = 0;
			this.btnUlogujSe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnUlogujSe.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
			this.btnUlogujSe.ForeColor = System.Drawing.Color.Silver;
			this.btnUlogujSe.Location = new System.Drawing.Point(310, 337);
			this.btnUlogujSe.Name = "btnUlogujSe";
			this.btnUlogujSe.Size = new System.Drawing.Size(158, 25);
			this.btnUlogujSe.TabIndex = 3;
			this.btnUlogujSe.Text = "Uloguj se";
			this.btnUlogujSe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnUlogujSe.UseVisualStyleBackColor = false;
			this.btnUlogujSe.Click += new System.EventHandler(this.btnUlogujSe_Click);
			// 
			// btnIzadji
			// 
			this.btnIzadji.BackColor = System.Drawing.Color.Gray;
			this.btnIzadji.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
			this.btnIzadji.FlatAppearance.BorderSize = 0;
			this.btnIzadji.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnIzadji.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
			this.btnIzadji.ForeColor = System.Drawing.Color.Silver;
			this.btnIzadji.Location = new System.Drawing.Point(479, 337);
			this.btnIzadji.Name = "btnIzadji";
			this.btnIzadji.Size = new System.Drawing.Size(158, 25);
			this.btnIzadji.TabIndex = 8;
			this.btnIzadji.Text = "Izađi";
			this.btnIzadji.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnIzadji.UseVisualStyleBackColor = false;
			this.btnIzadji.Click += new System.EventHandler(this.btnIzadji_Click);
			// 
			// btnPromenaLozinke
			// 
			this.btnPromenaLozinke.BackColor = System.Drawing.Color.Gray;
			this.btnPromenaLozinke.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
			this.btnPromenaLozinke.FlatAppearance.BorderSize = 0;
			this.btnPromenaLozinke.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnPromenaLozinke.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
			this.btnPromenaLozinke.ForeColor = System.Drawing.Color.Silver;
			this.btnPromenaLozinke.Location = new System.Drawing.Point(479, 377);
			this.btnPromenaLozinke.Name = "btnPromenaLozinke";
			this.btnPromenaLozinke.Size = new System.Drawing.Size(158, 25);
			this.btnPromenaLozinke.TabIndex = 9;
			this.btnPromenaLozinke.Text = "Promeni lozinku";
			this.btnPromenaLozinke.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnPromenaLozinke.UseVisualStyleBackColor = false;
			this.btnPromenaLozinke.Click += new System.EventHandler(this.btnPromenaLozinke_Click);
			// 
			// lbX
			// 
			this.lbX.AutoSize = true;
			this.lbX.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.lbX.ForeColor = System.Drawing.Color.Silver;
			this.lbX.Location = new System.Drawing.Point(776, 7);
			this.lbX.Name = "lbX";
			this.lbX.Size = new System.Drawing.Size(17, 16);
			this.lbX.TabIndex = 10;
			this.lbX.Text = "X";
			this.lbX.Click += new System.EventHandler(this.lbX_Click);
			// 
			// lb_
			// 
			this.lb_.AutoSize = true;
			this.lb_.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.lb_.ForeColor = System.Drawing.Color.Silver;
			this.lb_.Location = new System.Drawing.Point(753, 6);
			this.lb_.Name = "lb_";
			this.lb_.Size = new System.Drawing.Size(16, 16);
			this.lb_.TabIndex = 11;
			this.lb_.Text = "_";
			this.lb_.Click += new System.EventHandler(this.lb__Click);
			// 
			// lbNemore
			// 
			this.lbNemore.AutoSize = true;
			this.lbNemore.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.lbNemore.ForeColor = System.Drawing.Color.Red;
			this.lbNemore.Image = ((System.Drawing.Image)(resources.GetObject("lbNemore.Image")));
			this.lbNemore.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lbNemore.Location = new System.Drawing.Point(431, 207);
			this.lbNemore.Name = "lbNemore";
			this.lbNemore.Size = new System.Drawing.Size(206, 16);
			this.lbNemore.TabIndex = 12;
			this.lbNemore.Text = "     Uneli ste nedozvoljeni karakter";
			this.lbNemore.Visible = false;
			// 
			// loginForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.lbNemore);
			this.Controls.Add(this.lb_);
			this.Controls.Add(this.lbX);
			this.Controls.Add(this.btnPromenaLozinke);
			this.Controls.Add(this.btnIzadji);
			this.Controls.Add(this.btnUlogujSe);
			this.Controls.Add(this.cbPrikaziLozinku);
			this.Controls.Add(this.tbKorisnickoIme);
			this.Controls.Add(this.tbLozinka);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(800, 450);
			this.Name = "loginForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbLozinka;
        private System.Windows.Forms.TextBox tbKorisnickoIme;
        private System.Windows.Forms.CheckBox cbPrikaziLozinku;
        private System.Windows.Forms.Button btnUlogujSe;
        private System.Windows.Forms.Button btnIzadji;
        private System.Windows.Forms.Button btnPromenaLozinke;
        private System.Windows.Forms.Label lbX;
        private System.Windows.Forms.Label lb_;
        private System.Windows.Forms.Label lbNemore;
    }
}

