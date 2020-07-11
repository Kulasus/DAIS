namespace PollsDesktop.Forms
{
    partial class NewAnswer
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
            this.TbNewAnswerText = new System.Windows.Forms.TextBox();
            this.CmbNewAnswer = new System.Windows.Forms.ComboBox();
            this.BtnNewAnswer = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnNewAnswerBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TbNewAnswerText
            // 
            this.TbNewAnswerText.Location = new System.Drawing.Point(75, 27);
            this.TbNewAnswerText.Multiline = true;
            this.TbNewAnswerText.Name = "TbNewAnswerText";
            this.TbNewAnswerText.Size = new System.Drawing.Size(429, 91);
            this.TbNewAnswerText.TabIndex = 0;
            // 
            // CmbNewAnswer
            // 
            this.CmbNewAnswer.FormattingEnabled = true;
            this.CmbNewAnswer.Location = new System.Drawing.Point(75, 125);
            this.CmbNewAnswer.Name = "CmbNewAnswer";
            this.CmbNewAnswer.Size = new System.Drawing.Size(121, 21);
            this.CmbNewAnswer.TabIndex = 1;
            this.CmbNewAnswer.SelectedIndexChanged += new System.EventHandler(this.CmbNewAnswer_SelectedIndexChanged);
            // 
            // BtnNewAnswer
            // 
            this.BtnNewAnswer.Location = new System.Drawing.Point(391, 125);
            this.BtnNewAnswer.Name = "BtnNewAnswer";
            this.BtnNewAnswer.Size = new System.Drawing.Size(111, 23);
            this.BtnNewAnswer.TabIndex = 2;
            this.BtnNewAnswer.Text = "Confirm";
            this.BtnNewAnswer.UseVisualStyleBackColor = true;
            this.BtnNewAnswer.Click += new System.EventHandler(this.BtnNewAnswer_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Text:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Survey:";
            // 
            // BtnNewAnswerBack
            // 
            this.BtnNewAnswerBack.Location = new System.Drawing.Point(274, 125);
            this.BtnNewAnswerBack.Name = "BtnNewAnswerBack";
            this.BtnNewAnswerBack.Size = new System.Drawing.Size(111, 23);
            this.BtnNewAnswerBack.TabIndex = 5;
            this.BtnNewAnswerBack.Text = "Back";
            this.BtnNewAnswerBack.UseVisualStyleBackColor = true;
            this.BtnNewAnswerBack.Click += new System.EventHandler(this.BtnNewAnswerBack_Click);
            // 
            // NewAnswer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 204);
            this.Controls.Add(this.BtnNewAnswerBack);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnNewAnswer);
            this.Controls.Add(this.CmbNewAnswer);
            this.Controls.Add(this.TbNewAnswerText);
            this.Name = "NewAnswer";
            this.Text = "NewAnswer";
            this.Load += new System.EventHandler(this.NewAnswer_Load);
            this.Controls.SetChildIndex(this.TbNewAnswerText, 0);
            this.Controls.SetChildIndex(this.CmbNewAnswer, 0);
            this.Controls.SetChildIndex(this.BtnNewAnswer, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.BtnNewAnswerBack, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TbNewAnswerText;
        private System.Windows.Forms.ComboBox CmbNewAnswer;
        private System.Windows.Forms.Button BtnNewAnswer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnNewAnswerBack;
    }
}