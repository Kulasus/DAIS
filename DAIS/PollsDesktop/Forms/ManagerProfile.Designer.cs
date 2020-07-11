namespace PollsDesktop.Forms
{
    partial class ManagerProfile
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
            this.BtnProfileInfo = new System.Windows.Forms.Button();
            this.TbProfileEmail = new System.Windows.Forms.TextBox();
            this.TbPofileName = new System.Windows.Forms.TextBox();
            this.TbProfileLogin = new System.Windows.Forms.TextBox();
            this.LbProfileName = new System.Windows.Forms.Label();
            this.LbProfileEmail = new System.Windows.Forms.Label();
            this.LbProfileLogin = new System.Windows.Forms.Label();
            this.LbProfileInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BtnProfileInfo
            // 
            this.BtnProfileInfo.Location = new System.Drawing.Point(174, 281);
            this.BtnProfileInfo.Margin = new System.Windows.Forms.Padding(4);
            this.BtnProfileInfo.Name = "BtnProfileInfo";
            this.BtnProfileInfo.Size = new System.Drawing.Size(276, 48);
            this.BtnProfileInfo.TabIndex = 16;
            this.BtnProfileInfo.Text = "Change information";
            this.BtnProfileInfo.UseVisualStyleBackColor = true;
            this.BtnProfileInfo.Click += new System.EventHandler(this.BtnProfileInfo_Click);
            // 
            // TbProfileEmail
            // 
            this.TbProfileEmail.Location = new System.Drawing.Point(174, 187);
            this.TbProfileEmail.Margin = new System.Windows.Forms.Padding(4);
            this.TbProfileEmail.Name = "TbProfileEmail";
            this.TbProfileEmail.ReadOnly = true;
            this.TbProfileEmail.Size = new System.Drawing.Size(275, 22);
            this.TbProfileEmail.TabIndex = 15;
            // 
            // TbPofileName
            // 
            this.TbPofileName.Location = new System.Drawing.Point(174, 222);
            this.TbPofileName.Margin = new System.Windows.Forms.Padding(4);
            this.TbPofileName.Name = "TbPofileName";
            this.TbPofileName.ReadOnly = true;
            this.TbPofileName.Size = new System.Drawing.Size(275, 22);
            this.TbPofileName.TabIndex = 14;
            // 
            // TbProfileLogin
            // 
            this.TbProfileLogin.Location = new System.Drawing.Point(174, 148);
            this.TbProfileLogin.Margin = new System.Windows.Forms.Padding(4);
            this.TbProfileLogin.Name = "TbProfileLogin";
            this.TbProfileLogin.ReadOnly = true;
            this.TbProfileLogin.Size = new System.Drawing.Size(275, 22);
            this.TbProfileLogin.TabIndex = 13;
            // 
            // LbProfileName
            // 
            this.LbProfileName.AutoSize = true;
            this.LbProfileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LbProfileName.Location = new System.Drawing.Point(87, 224);
            this.LbProfileName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LbProfileName.Name = "LbProfileName";
            this.LbProfileName.Size = new System.Drawing.Size(58, 20);
            this.LbProfileName.TabIndex = 12;
            this.LbProfileName.Text = "Name:";
            // 
            // LbProfileEmail
            // 
            this.LbProfileEmail.AutoSize = true;
            this.LbProfileEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LbProfileEmail.Location = new System.Drawing.Point(87, 187);
            this.LbProfileEmail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LbProfileEmail.Name = "LbProfileEmail";
            this.LbProfileEmail.Size = new System.Drawing.Size(62, 20);
            this.LbProfileEmail.TabIndex = 11;
            this.LbProfileEmail.Text = "E-mail:";
            // 
            // LbProfileLogin
            // 
            this.LbProfileLogin.AutoSize = true;
            this.LbProfileLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LbProfileLogin.Location = new System.Drawing.Point(87, 148);
            this.LbProfileLogin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LbProfileLogin.Name = "LbProfileLogin";
            this.LbProfileLogin.Size = new System.Drawing.Size(55, 20);
            this.LbProfileLogin.TabIndex = 10;
            this.LbProfileLogin.Text = "Login:";
            // 
            // LbProfileInfo
            // 
            this.LbProfileInfo.AutoSize = true;
            this.LbProfileInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LbProfileInfo.Location = new System.Drawing.Point(42, 94);
            this.LbProfileInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LbProfileInfo.Name = "LbProfileInfo";
            this.LbProfileInfo.Size = new System.Drawing.Size(83, 39);
            this.LbProfileInfo.TabIndex = 9;
            this.LbProfileInfo.Text = "Info:";
            // 
            // ManagerProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 386);
            this.Controls.Add(this.BtnProfileInfo);
            this.Controls.Add(this.TbProfileEmail);
            this.Controls.Add(this.TbPofileName);
            this.Controls.Add(this.TbProfileLogin);
            this.Controls.Add(this.LbProfileName);
            this.Controls.Add(this.LbProfileEmail);
            this.Controls.Add(this.LbProfileLogin);
            this.Controls.Add(this.LbProfileInfo);
            this.Name = "ManagerProfile";
            this.Text = "ManagerProfile";
            this.Load += new System.EventHandler(this.ManagerProfile_Load);
            this.Controls.SetChildIndex(this.LbProfileInfo, 0);
            this.Controls.SetChildIndex(this.LbProfileLogin, 0);
            this.Controls.SetChildIndex(this.LbProfileEmail, 0);
            this.Controls.SetChildIndex(this.LbProfileName, 0);
            this.Controls.SetChildIndex(this.TbProfileLogin, 0);
            this.Controls.SetChildIndex(this.TbPofileName, 0);
            this.Controls.SetChildIndex(this.TbProfileEmail, 0);
            this.Controls.SetChildIndex(this.BtnProfileInfo, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnProfileInfo;
        private System.Windows.Forms.TextBox TbProfileEmail;
        private System.Windows.Forms.TextBox TbPofileName;
        private System.Windows.Forms.TextBox TbProfileLogin;
        private System.Windows.Forms.Label LbProfileName;
        private System.Windows.Forms.Label LbProfileEmail;
        private System.Windows.Forms.Label LbProfileLogin;
        private System.Windows.Forms.Label LbProfileInfo;
    }
}