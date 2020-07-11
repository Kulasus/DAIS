namespace PollsDesktop.Forms
{
    partial class MySurveys
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
            this.DataGridViewMySurveys = new System.Windows.Forms.DataGridView();
            this.BtnMySurveysNew = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewMySurveys)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGridViewMySurveys
            // 
            this.DataGridViewMySurveys.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewMySurveys.Location = new System.Drawing.Point(9, 25);
            this.DataGridViewMySurveys.Margin = new System.Windows.Forms.Padding(2);
            this.DataGridViewMySurveys.Name = "DataGridViewMySurveys";
            this.DataGridViewMySurveys.ReadOnly = true;
            this.DataGridViewMySurveys.RowHeadersWidth = 51;
            this.DataGridViewMySurveys.RowTemplate.Height = 24;
            this.DataGridViewMySurveys.Size = new System.Drawing.Size(813, 392);
            this.DataGridViewMySurveys.TabIndex = 1;
            this.DataGridViewMySurveys.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewMySurveys_CellClick);
            this.DataGridViewMySurveys.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewMySurveys_CellContentClick);
            // 
            // BtnMySurveysNew
            // 
            this.BtnMySurveysNew.Location = new System.Drawing.Point(9, 423);
            this.BtnMySurveysNew.Name = "BtnMySurveysNew";
            this.BtnMySurveysNew.Size = new System.Drawing.Size(140, 39);
            this.BtnMySurveysNew.TabIndex = 2;
            this.BtnMySurveysNew.Text = "Create new survey";
            this.BtnMySurveysNew.UseVisualStyleBackColor = true;
            this.BtnMySurveysNew.Click += new System.EventHandler(this.BtnMySurveysNew_Click);
            // 
            // MySurveys
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 474);
            this.Controls.Add(this.BtnMySurveysNew);
            this.Controls.Add(this.DataGridViewMySurveys);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MySurveys";
            this.Text = "MySurveys";
            this.Load += new System.EventHandler(this.MySurveys_Load);
            this.Controls.SetChildIndex(this.DataGridViewMySurveys, 0);
            this.Controls.SetChildIndex(this.BtnMySurveysNew, 0);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewMySurveys)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DataGridViewMySurveys;
        private System.Windows.Forms.Button BtnMySurveysNew;
    }
}