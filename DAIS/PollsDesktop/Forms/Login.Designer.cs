namespace PollsDesktop
{
    partial class Form1
    {
        /// <summary>
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            this.BtnLogin = new System.Windows.Forms.Button();
            this.TbLogin = new System.Windows.Forms.TextBox();
            this.LbLogin = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnLogin
            // 
            this.BtnLogin.Location = new System.Drawing.Point(105, 206);
            this.BtnLogin.Margin = new System.Windows.Forms.Padding(4);
            this.BtnLogin.Name = "BtnLogin";
            this.BtnLogin.Size = new System.Drawing.Size(137, 54);
            this.BtnLogin.TabIndex = 0;
            this.BtnLogin.Text = "Login";
            this.BtnLogin.UseVisualStyleBackColor = true;
            this.BtnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            // 
            // TbLogin
            // 
            this.TbLogin.Location = new System.Drawing.Point(51, 153);
            this.TbLogin.Margin = new System.Windows.Forms.Padding(4);
            this.TbLogin.Name = "TbLogin";
            this.TbLogin.Size = new System.Drawing.Size(255, 22);
            this.TbLogin.TabIndex = 1;
            // 
            // LbLogin
            // 
            this.LbLogin.AutoSize = true;
            this.LbLogin.Location = new System.Drawing.Point(47, 133);
            this.LbLogin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LbLogin.Name = "LbLogin";
            this.LbLogin.Size = new System.Drawing.Size(150, 17);
            this.LbLogin.TabIndex = 2;
            this.LbLogin.Text = "*Enter your username:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PollsDesktop.Properties.Resources.login;
            this.pictureBox1.Location = new System.Drawing.Point(3, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(255, 118);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(363, 274);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.LbLogin);
            this.Controls.Add(this.TbLogin);
            this.Controls.Add(this.BtnLogin);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "PollsApp 1.0";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnLogin;
        private System.Windows.Forms.TextBox TbLogin;
        private System.Windows.Forms.Label LbLogin;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

