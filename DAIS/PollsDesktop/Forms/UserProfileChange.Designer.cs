namespace PollsDesktop.Forms
{
    partial class UserProfileChange
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
            this.BtnProfileChangeConfirm = new System.Windows.Forms.Button();
            this.TbProfileChangeName = new System.Windows.Forms.TextBox();
            this.TbProfileChangeEmail = new System.Windows.Forms.TextBox();
            this.LbProfileChangeName = new System.Windows.Forms.Label();
            this.LbProfileChangeEmail = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BtnProfileChangeConfirm
            // 
            this.BtnProfileChangeConfirm.Location = new System.Drawing.Point(102, 97);
            this.BtnProfileChangeConfirm.Name = "BtnProfileChangeConfirm";
            this.BtnProfileChangeConfirm.Size = new System.Drawing.Size(75, 23);
            this.BtnProfileChangeConfirm.TabIndex = 0;
            this.BtnProfileChangeConfirm.Text = "Confirm";
            this.BtnProfileChangeConfirm.UseVisualStyleBackColor = true;
            this.BtnProfileChangeConfirm.Click += new System.EventHandler(this.BtnProfileChangeConfirm_Click);
            // 
            // TbProfileChangeName
            // 
            this.TbProfileChangeName.Location = new System.Drawing.Point(90, 27);
            this.TbProfileChangeName.Name = "TbProfileChangeName";
            this.TbProfileChangeName.Size = new System.Drawing.Size(167, 20);
            this.TbProfileChangeName.TabIndex = 1;
            // 
            // TbProfileChangeEmail
            // 
            this.TbProfileChangeEmail.Location = new System.Drawing.Point(90, 62);
            this.TbProfileChangeEmail.Name = "TbProfileChangeEmail";
            this.TbProfileChangeEmail.Size = new System.Drawing.Size(167, 20);
            this.TbProfileChangeEmail.TabIndex = 2;
            // 
            // LbProfileChangeName
            // 
            this.LbProfileChangeName.AutoSize = true;
            this.LbProfileChangeName.Location = new System.Drawing.Point(23, 30);
            this.LbProfileChangeName.Name = "LbProfileChangeName";
            this.LbProfileChangeName.Size = new System.Drawing.Size(61, 13);
            this.LbProfileChangeName.TabIndex = 3;
            this.LbProfileChangeName.Text = "New name:";
            this.LbProfileChangeName.Click += new System.EventHandler(this.label1_Click);
            // 
            // LbProfileChangeEmail
            // 
            this.LbProfileChangeEmail.AutoSize = true;
            this.LbProfileChangeEmail.Location = new System.Drawing.Point(25, 65);
            this.LbProfileChangeEmail.Name = "LbProfileChangeEmail";
            this.LbProfileChangeEmail.Size = new System.Drawing.Size(59, 13);
            this.LbProfileChangeEmail.TabIndex = 4;
            this.LbProfileChangeEmail.Text = "New email:";
            // 
            // UserProfileChange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 132);
            this.Controls.Add(this.LbProfileChangeEmail);
            this.Controls.Add(this.LbProfileChangeName);
            this.Controls.Add(this.TbProfileChangeEmail);
            this.Controls.Add(this.TbProfileChangeName);
            this.Controls.Add(this.BtnProfileChangeConfirm);
            this.Name = "UserProfileChange";
            this.Text = "UserProfileChange";
            this.Load += new System.EventHandler(this.UserProfileChange_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnProfileChangeConfirm;
        private System.Windows.Forms.TextBox TbProfileChangeName;
        private System.Windows.Forms.TextBox TbProfileChangeEmail;
        private System.Windows.Forms.Label LbProfileChangeName;
        private System.Windows.Forms.Label LbProfileChangeEmail;
    }
}