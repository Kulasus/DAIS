namespace PollsDesktop.Forms
{
    partial class AnswerDetails
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
            this.TbAnswerDetailsText = new System.Windows.Forms.TextBox();
            this.TbAnswerDetailsCreatinDate = new System.Windows.Forms.TextBox();
            this.TbAnswerDetailsLogin = new System.Windows.Forms.TextBox();
            this.LbAnserDetailCreationDate = new System.Windows.Forms.Label();
            this.LbAnserDetailLogin = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TbAnswerDetailsText
            // 
            this.TbAnswerDetailsText.Location = new System.Drawing.Point(9, 25);
            this.TbAnswerDetailsText.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TbAnswerDetailsText.Multiline = true;
            this.TbAnswerDetailsText.Name = "TbAnswerDetailsText";
            this.TbAnswerDetailsText.ReadOnly = true;
            this.TbAnswerDetailsText.Size = new System.Drawing.Size(596, 87);
            this.TbAnswerDetailsText.TabIndex = 0;
            // 
            // TbAnswerDetailsCreatinDate
            // 
            this.TbAnswerDetailsCreatinDate.Location = new System.Drawing.Point(208, 116);
            this.TbAnswerDetailsCreatinDate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TbAnswerDetailsCreatinDate.Name = "TbAnswerDetailsCreatinDate";
            this.TbAnswerDetailsCreatinDate.ReadOnly = true;
            this.TbAnswerDetailsCreatinDate.Size = new System.Drawing.Size(120, 20);
            this.TbAnswerDetailsCreatinDate.TabIndex = 2;
            // 
            // TbAnswerDetailsLogin
            // 
            this.TbAnswerDetailsLogin.Location = new System.Drawing.Point(46, 116);
            this.TbAnswerDetailsLogin.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TbAnswerDetailsLogin.Name = "TbAnswerDetailsLogin";
            this.TbAnswerDetailsLogin.ReadOnly = true;
            this.TbAnswerDetailsLogin.Size = new System.Drawing.Size(76, 20);
            this.TbAnswerDetailsLogin.TabIndex = 3;
            // 
            // LbAnserDetailCreationDate
            // 
            this.LbAnserDetailCreationDate.AutoSize = true;
            this.LbAnserDetailCreationDate.Location = new System.Drawing.Point(129, 119);
            this.LbAnserDetailCreationDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LbAnserDetailCreationDate.Name = "LbAnserDetailCreationDate";
            this.LbAnserDetailCreationDate.Size = new System.Drawing.Size(75, 13);
            this.LbAnserDetailCreationDate.TabIndex = 7;
            this.LbAnserDetailCreationDate.Text = "Creation Date:";
            // 
            // LbAnserDetailLogin
            // 
            this.LbAnserDetailLogin.AutoSize = true;
            this.LbAnserDetailLogin.Location = new System.Drawing.Point(7, 119);
            this.LbAnserDetailLogin.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LbAnserDetailLogin.Name = "LbAnserDetailLogin";
            this.LbAnserDetailLogin.Size = new System.Drawing.Size(36, 13);
            this.LbAnserDetailLogin.TabIndex = 8;
            this.LbAnserDetailLogin.Text = "Login:";
            // 
            // AnswerDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 145);
            this.Controls.Add(this.LbAnserDetailLogin);
            this.Controls.Add(this.LbAnserDetailCreationDate);
            this.Controls.Add(this.TbAnswerDetailsLogin);
            this.Controls.Add(this.TbAnswerDetailsCreatinDate);
            this.Controls.Add(this.TbAnswerDetailsText);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "AnswerDetails";
            this.Text = "AnswerDetails";
            this.Load += new System.EventHandler(this.AnswerDetails_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TbAnswerDetailsText;
        private System.Windows.Forms.TextBox TbAnswerDetailsCreatinDate;
        private System.Windows.Forms.TextBox TbAnswerDetailsLogin;
        private System.Windows.Forms.Label LbAnserDetailCreationDate;
        private System.Windows.Forms.Label LbAnserDetailLogin;
    }
}