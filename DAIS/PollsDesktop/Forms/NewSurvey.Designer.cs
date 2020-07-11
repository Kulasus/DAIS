namespace PollsDesktop.Forms
{
    partial class NewSurvey
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
            this.TbNewSurveyTitle = new System.Windows.Forms.TextBox();
            this.TbNewSurveyDesc = new System.Windows.Forms.TextBox();
            this.TbNewSurveyText = new System.Windows.Forms.TextBox();
            this.CmbNewSurvey = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.BtnNewSurvey = new System.Windows.Forms.Button();
            this.BtnNewSurveyBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TbNewSurveyTitle
            // 
            this.TbNewSurveyTitle.Location = new System.Drawing.Point(88, 29);
            this.TbNewSurveyTitle.Name = "TbNewSurveyTitle";
            this.TbNewSurveyTitle.Size = new System.Drawing.Size(537, 20);
            this.TbNewSurveyTitle.TabIndex = 0;
            // 
            // TbNewSurveyDesc
            // 
            this.TbNewSurveyDesc.Location = new System.Drawing.Point(88, 56);
            this.TbNewSurveyDesc.Multiline = true;
            this.TbNewSurveyDesc.Name = "TbNewSurveyDesc";
            this.TbNewSurveyDesc.Size = new System.Drawing.Size(537, 53);
            this.TbNewSurveyDesc.TabIndex = 1;
            // 
            // TbNewSurveyText
            // 
            this.TbNewSurveyText.Location = new System.Drawing.Point(88, 115);
            this.TbNewSurveyText.Multiline = true;
            this.TbNewSurveyText.Name = "TbNewSurveyText";
            this.TbNewSurveyText.Size = new System.Drawing.Size(537, 203);
            this.TbNewSurveyText.TabIndex = 2;
            // 
            // CmbNewSurvey
            // 
            this.CmbNewSurvey.FormattingEnabled = true;
            this.CmbNewSurvey.Location = new System.Drawing.Point(88, 323);
            this.CmbNewSurvey.Name = "CmbNewSurvey";
            this.CmbNewSurvey.Size = new System.Drawing.Size(127, 21);
            this.CmbNewSurvey.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Title:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Description:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Text:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 323);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Group:";
            // 
            // BtnNewSurvey
            // 
            this.BtnNewSurvey.Location = new System.Drawing.Point(528, 324);
            this.BtnNewSurvey.Name = "BtnNewSurvey";
            this.BtnNewSurvey.Size = new System.Drawing.Size(97, 23);
            this.BtnNewSurvey.TabIndex = 8;
            this.BtnNewSurvey.Text = "Confirm";
            this.BtnNewSurvey.UseVisualStyleBackColor = true;
            this.BtnNewSurvey.Click += new System.EventHandler(this.BtnNewSurvey_Click);
            // 
            // BtnNewSurveyBack
            // 
            this.BtnNewSurveyBack.Location = new System.Drawing.Point(425, 324);
            this.BtnNewSurveyBack.Name = "BtnNewSurveyBack";
            this.BtnNewSurveyBack.Size = new System.Drawing.Size(97, 23);
            this.BtnNewSurveyBack.TabIndex = 9;
            this.BtnNewSurveyBack.Text = "Back";
            this.BtnNewSurveyBack.UseVisualStyleBackColor = true;
            this.BtnNewSurveyBack.Click += new System.EventHandler(this.BtnNewSurveyBack_Click);
            // 
            // NewSurvey
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 371);
            this.Controls.Add(this.BtnNewSurveyBack);
            this.Controls.Add(this.BtnNewSurvey);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CmbNewSurvey);
            this.Controls.Add(this.TbNewSurveyText);
            this.Controls.Add(this.TbNewSurveyDesc);
            this.Controls.Add(this.TbNewSurveyTitle);
            this.Name = "NewSurvey";
            this.Text = "NewSurvey";
            this.Load += new System.EventHandler(this.NewSurvey_Load);
            this.Controls.SetChildIndex(this.TbNewSurveyTitle, 0);
            this.Controls.SetChildIndex(this.TbNewSurveyDesc, 0);
            this.Controls.SetChildIndex(this.TbNewSurveyText, 0);
            this.Controls.SetChildIndex(this.CmbNewSurvey, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.BtnNewSurvey, 0);
            this.Controls.SetChildIndex(this.BtnNewSurveyBack, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TbNewSurveyTitle;
        private System.Windows.Forms.TextBox TbNewSurveyDesc;
        private System.Windows.Forms.TextBox TbNewSurveyText;
        private System.Windows.Forms.ComboBox CmbNewSurvey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button BtnNewSurvey;
        private System.Windows.Forms.Button BtnNewSurveyBack;
    }
}