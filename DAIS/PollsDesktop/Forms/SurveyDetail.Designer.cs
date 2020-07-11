namespace PollsDesktop.Forms
{
    partial class SurveyDetail
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.BtnSurveyDetailsBack = new System.Windows.Forms.Button();
            this.TbSurveyDetailsTitle = new System.Windows.Forms.TextBox();
            this.TbSurveyDetailsText = new System.Windows.Forms.TextBox();
            this.TbSurveyDetailsState = new System.Windows.Forms.TextBox();
            this.TbSurveyDetailsLogin = new System.Windows.Forms.TextBox();
            this.LbSurveyDetailsState = new System.Windows.Forms.Label();
            this.LbSurveyDetailsLogin = new System.Windows.Forms.Label();
            this.DataGridViewSurveyDetails = new System.Windows.Forms.DataGridView();
            this.ChartSurveyDetails = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewSurveyDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChartSurveyDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnSurveyDetailsBack
            // 
            this.BtnSurveyDetailsBack.Location = new System.Drawing.Point(526, 0);
            this.BtnSurveyDetailsBack.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BtnSurveyDetailsBack.Name = "BtnSurveyDetailsBack";
            this.BtnSurveyDetailsBack.Size = new System.Drawing.Size(74, 23);
            this.BtnSurveyDetailsBack.TabIndex = 1;
            this.BtnSurveyDetailsBack.Text = "Back";
            this.BtnSurveyDetailsBack.UseVisualStyleBackColor = true;
            this.BtnSurveyDetailsBack.Click += new System.EventHandler(this.BtnSurveyDetailsBack_Click);
            // 
            // TbSurveyDetailsTitle
            // 
            this.TbSurveyDetailsTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.TbSurveyDetailsTitle.Location = new System.Drawing.Point(9, 28);
            this.TbSurveyDetailsTitle.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TbSurveyDetailsTitle.Name = "TbSurveyDetailsTitle";
            this.TbSurveyDetailsTitle.ReadOnly = true;
            this.TbSurveyDetailsTitle.Size = new System.Drawing.Size(583, 38);
            this.TbSurveyDetailsTitle.TabIndex = 2;
            // 
            // TbSurveyDetailsText
            // 
            this.TbSurveyDetailsText.Location = new System.Drawing.Point(9, 70);
            this.TbSurveyDetailsText.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TbSurveyDetailsText.Multiline = true;
            this.TbSurveyDetailsText.Name = "TbSurveyDetailsText";
            this.TbSurveyDetailsText.ReadOnly = true;
            this.TbSurveyDetailsText.Size = new System.Drawing.Size(583, 98);
            this.TbSurveyDetailsText.TabIndex = 3;
            // 
            // TbSurveyDetailsState
            // 
            this.TbSurveyDetailsState.Location = new System.Drawing.Point(56, 172);
            this.TbSurveyDetailsState.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TbSurveyDetailsState.Name = "TbSurveyDetailsState";
            this.TbSurveyDetailsState.ReadOnly = true;
            this.TbSurveyDetailsState.Size = new System.Drawing.Size(96, 20);
            this.TbSurveyDetailsState.TabIndex = 4;
            // 
            // TbSurveyDetailsLogin
            // 
            this.TbSurveyDetailsLogin.Location = new System.Drawing.Point(476, 172);
            this.TbSurveyDetailsLogin.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TbSurveyDetailsLogin.Name = "TbSurveyDetailsLogin";
            this.TbSurveyDetailsLogin.ReadOnly = true;
            this.TbSurveyDetailsLogin.Size = new System.Drawing.Size(96, 20);
            this.TbSurveyDetailsLogin.TabIndex = 5;
            // 
            // LbSurveyDetailsState
            // 
            this.LbSurveyDetailsState.AutoSize = true;
            this.LbSurveyDetailsState.Location = new System.Drawing.Point(18, 175);
            this.LbSurveyDetailsState.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LbSurveyDetailsState.Name = "LbSurveyDetailsState";
            this.LbSurveyDetailsState.Size = new System.Drawing.Size(35, 13);
            this.LbSurveyDetailsState.TabIndex = 7;
            this.LbSurveyDetailsState.Text = "State:";
            // 
            // LbSurveyDetailsLogin
            // 
            this.LbSurveyDetailsLogin.AutoSize = true;
            this.LbSurveyDetailsLogin.Location = new System.Drawing.Point(418, 175);
            this.LbSurveyDetailsLogin.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LbSurveyDetailsLogin.Name = "LbSurveyDetailsLogin";
            this.LbSurveyDetailsLogin.Size = new System.Drawing.Size(55, 13);
            this.LbSurveyDetailsLogin.TabIndex = 9;
            this.LbSurveyDetailsLogin.Text = "Manager: ";
            // 
            // DataGridViewSurveyDetails
            // 
            this.DataGridViewSurveyDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewSurveyDetails.Location = new System.Drawing.Point(9, 217);
            this.DataGridViewSurveyDetails.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.DataGridViewSurveyDetails.Name = "DataGridViewSurveyDetails";
            this.DataGridViewSurveyDetails.RowHeadersWidth = 51;
            this.DataGridViewSurveyDetails.RowTemplate.Height = 24;
            this.DataGridViewSurveyDetails.Size = new System.Drawing.Size(251, 174);
            this.DataGridViewSurveyDetails.TabIndex = 10;
            this.DataGridViewSurveyDetails.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewSurveyDetails_CellClick);
            // 
            // ChartSurveyDetails
            // 
            chartArea1.Name = "ChartArea1";
            this.ChartSurveyDetails.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.ChartSurveyDetails.Legends.Add(legend1);
            this.ChartSurveyDetails.Location = new System.Drawing.Point(347, 217);
            this.ChartSurveyDetails.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ChartSurveyDetails.Name = "ChartSurveyDetails";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Legend = "Legend1";
            series1.Name = "Answers";
            this.ChartSurveyDetails.Series.Add(series1);
            this.ChartSurveyDetails.Size = new System.Drawing.Size(225, 174);
            this.ChartSurveyDetails.TabIndex = 11;
            this.ChartSurveyDetails.Text = "chart1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(9, 194);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "Answers:";
            // 
            // SurveyDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 404);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ChartSurveyDetails);
            this.Controls.Add(this.DataGridViewSurveyDetails);
            this.Controls.Add(this.LbSurveyDetailsLogin);
            this.Controls.Add(this.LbSurveyDetailsState);
            this.Controls.Add(this.TbSurveyDetailsLogin);
            this.Controls.Add(this.TbSurveyDetailsState);
            this.Controls.Add(this.TbSurveyDetailsText);
            this.Controls.Add(this.TbSurveyDetailsTitle);
            this.Controls.Add(this.BtnSurveyDetailsBack);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "SurveyDetail";
            this.Text = "SurveyDetail";
            this.Load += new System.EventHandler(this.SurveyDetail_Load);
            this.Controls.SetChildIndex(this.BtnSurveyDetailsBack, 0);
            this.Controls.SetChildIndex(this.TbSurveyDetailsTitle, 0);
            this.Controls.SetChildIndex(this.TbSurveyDetailsText, 0);
            this.Controls.SetChildIndex(this.TbSurveyDetailsState, 0);
            this.Controls.SetChildIndex(this.TbSurveyDetailsLogin, 0);
            this.Controls.SetChildIndex(this.LbSurveyDetailsState, 0);
            this.Controls.SetChildIndex(this.LbSurveyDetailsLogin, 0);
            this.Controls.SetChildIndex(this.DataGridViewSurveyDetails, 0);
            this.Controls.SetChildIndex(this.ChartSurveyDetails, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewSurveyDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChartSurveyDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnSurveyDetailsBack;
        private System.Windows.Forms.TextBox TbSurveyDetailsTitle;
        private System.Windows.Forms.TextBox TbSurveyDetailsText;
        private System.Windows.Forms.TextBox TbSurveyDetailsState;
        private System.Windows.Forms.TextBox TbSurveyDetailsLogin;
        private System.Windows.Forms.Label LbSurveyDetailsState;
        private System.Windows.Forms.Label LbSurveyDetailsLogin;
        private System.Windows.Forms.DataGridView DataGridViewSurveyDetails;
        private System.Windows.Forms.DataVisualization.Charting.Chart ChartSurveyDetails;
        private System.Windows.Forms.Label label1;
    }
}