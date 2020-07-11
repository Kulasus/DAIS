namespace PollsDesktop.Forms
{
    partial class UserProfile
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
            this.LbProfileGroups = new System.Windows.Forms.Label();
            this.LbProfileInfo = new System.Windows.Forms.Label();
            this.LbProfileLogin = new System.Windows.Forms.Label();
            this.LbProfileEmail = new System.Windows.Forms.Label();
            this.LbProfileName = new System.Windows.Forms.Label();
            this.TbProfileLogin = new System.Windows.Forms.TextBox();
            this.TbPofileName = new System.Windows.Forms.TextBox();
            this.TbProfileEmail = new System.Windows.Forms.TextBox();
            this.BtnProfileInfo = new System.Windows.Forms.Button();
            this.TbProfileGroups1 = new System.Windows.Forms.TextBox();
            this.TbProfileGroups4 = new System.Windows.Forms.TextBox();
            this.TbProfileGroups3 = new System.Windows.Forms.TextBox();
            this.TbProfileGroups2 = new System.Windows.Forms.TextBox();
            this.ChartProfileGroups = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.BtnProfileGroups1 = new System.Windows.Forms.Button();
            this.BtnProfileGroups2 = new System.Windows.Forms.Button();
            this.BtnProfileGroups3 = new System.Windows.Forms.Button();
            this.BtnProfileGroups4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ChartProfileGroups)).BeginInit();
            this.SuspendLayout();
            // 
            // LbProfileGroups
            // 
            this.LbProfileGroups.AutoSize = true;
            this.LbProfileGroups.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LbProfileGroups.Location = new System.Drawing.Point(523, 76);
            this.LbProfileGroups.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LbProfileGroups.Name = "LbProfileGroups";
            this.LbProfileGroups.Size = new System.Drawing.Size(191, 39);
            this.LbProfileGroups.TabIndex = 9;
            this.LbProfileGroups.Text = "My Groups:";
            this.LbProfileGroups.Click += new System.EventHandler(this.LbProfileGroups_Click);
            // 
            // LbProfileInfo
            // 
            this.LbProfileInfo.AutoSize = true;
            this.LbProfileInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LbProfileInfo.Location = new System.Drawing.Point(40, 76);
            this.LbProfileInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LbProfileInfo.Name = "LbProfileInfo";
            this.LbProfileInfo.Size = new System.Drawing.Size(83, 39);
            this.LbProfileInfo.TabIndex = 1;
            this.LbProfileInfo.Text = "Info:";
            this.LbProfileInfo.Click += new System.EventHandler(this.label1_Click);
            // 
            // LbProfileLogin
            // 
            this.LbProfileLogin.AutoSize = true;
            this.LbProfileLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LbProfileLogin.Location = new System.Drawing.Point(85, 130);
            this.LbProfileLogin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LbProfileLogin.Name = "LbProfileLogin";
            this.LbProfileLogin.Size = new System.Drawing.Size(55, 20);
            this.LbProfileLogin.TabIndex = 2;
            this.LbProfileLogin.Text = "Login:";
            // 
            // LbProfileEmail
            // 
            this.LbProfileEmail.AutoSize = true;
            this.LbProfileEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LbProfileEmail.Location = new System.Drawing.Point(85, 169);
            this.LbProfileEmail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LbProfileEmail.Name = "LbProfileEmail";
            this.LbProfileEmail.Size = new System.Drawing.Size(62, 20);
            this.LbProfileEmail.TabIndex = 3;
            this.LbProfileEmail.Text = "E-mail:";
            // 
            // LbProfileName
            // 
            this.LbProfileName.AutoSize = true;
            this.LbProfileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LbProfileName.Location = new System.Drawing.Point(85, 206);
            this.LbProfileName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LbProfileName.Name = "LbProfileName";
            this.LbProfileName.Size = new System.Drawing.Size(58, 20);
            this.LbProfileName.TabIndex = 4;
            this.LbProfileName.Text = "Name:";
            // 
            // TbProfileLogin
            // 
            this.TbProfileLogin.Location = new System.Drawing.Point(172, 130);
            this.TbProfileLogin.Margin = new System.Windows.Forms.Padding(4);
            this.TbProfileLogin.Name = "TbProfileLogin";
            this.TbProfileLogin.ReadOnly = true;
            this.TbProfileLogin.Size = new System.Drawing.Size(275, 22);
            this.TbProfileLogin.TabIndex = 5;
            // 
            // TbPofileName
            // 
            this.TbPofileName.Location = new System.Drawing.Point(172, 204);
            this.TbPofileName.Margin = new System.Windows.Forms.Padding(4);
            this.TbPofileName.Name = "TbPofileName";
            this.TbPofileName.ReadOnly = true;
            this.TbPofileName.Size = new System.Drawing.Size(275, 22);
            this.TbPofileName.TabIndex = 6;
            // 
            // TbProfileEmail
            // 
            this.TbProfileEmail.Location = new System.Drawing.Point(172, 169);
            this.TbProfileEmail.Margin = new System.Windows.Forms.Padding(4);
            this.TbProfileEmail.Name = "TbProfileEmail";
            this.TbProfileEmail.ReadOnly = true;
            this.TbProfileEmail.Size = new System.Drawing.Size(275, 22);
            this.TbProfileEmail.TabIndex = 7;
            // 
            // BtnProfileInfo
            // 
            this.BtnProfileInfo.Location = new System.Drawing.Point(172, 263);
            this.BtnProfileInfo.Margin = new System.Windows.Forms.Padding(4);
            this.BtnProfileInfo.Name = "BtnProfileInfo";
            this.BtnProfileInfo.Size = new System.Drawing.Size(276, 48);
            this.BtnProfileInfo.TabIndex = 8;
            this.BtnProfileInfo.Text = "Change information";
            this.BtnProfileInfo.UseVisualStyleBackColor = true;
            this.BtnProfileInfo.Click += new System.EventHandler(this.BtnProfileInfo_Click);
            // 
            // TbProfileGroups1
            // 
            this.TbProfileGroups1.Location = new System.Drawing.Point(531, 130);
            this.TbProfileGroups1.Margin = new System.Windows.Forms.Padding(4);
            this.TbProfileGroups1.Name = "TbProfileGroups1";
            this.TbProfileGroups1.ReadOnly = true;
            this.TbProfileGroups1.Size = new System.Drawing.Size(365, 22);
            this.TbProfileGroups1.TabIndex = 10;
            this.TbProfileGroups1.Visible = false;
            // 
            // TbProfileGroups4
            // 
            this.TbProfileGroups4.Location = new System.Drawing.Point(531, 249);
            this.TbProfileGroups4.Margin = new System.Windows.Forms.Padding(4);
            this.TbProfileGroups4.Name = "TbProfileGroups4";
            this.TbProfileGroups4.ReadOnly = true;
            this.TbProfileGroups4.Size = new System.Drawing.Size(365, 22);
            this.TbProfileGroups4.TabIndex = 11;
            this.TbProfileGroups4.Visible = false;
            // 
            // TbProfileGroups3
            // 
            this.TbProfileGroups3.Location = new System.Drawing.Point(531, 206);
            this.TbProfileGroups3.Margin = new System.Windows.Forms.Padding(4);
            this.TbProfileGroups3.Name = "TbProfileGroups3";
            this.TbProfileGroups3.ReadOnly = true;
            this.TbProfileGroups3.Size = new System.Drawing.Size(365, 22);
            this.TbProfileGroups3.TabIndex = 12;
            this.TbProfileGroups3.Visible = false;
            // 
            // TbProfileGroups2
            // 
            this.TbProfileGroups2.Location = new System.Drawing.Point(531, 167);
            this.TbProfileGroups2.Margin = new System.Windows.Forms.Padding(4);
            this.TbProfileGroups2.Name = "TbProfileGroups2";
            this.TbProfileGroups2.ReadOnly = true;
            this.TbProfileGroups2.Size = new System.Drawing.Size(365, 22);
            this.TbProfileGroups2.TabIndex = 13;
            this.TbProfileGroups2.Visible = false;
            // 
            // ChartProfileGroups
            // 
            chartArea1.Name = "ChartArea1";
            this.ChartProfileGroups.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.ChartProfileGroups.Legends.Add(legend1);
            this.ChartProfileGroups.Location = new System.Drawing.Point(489, 306);
            this.ChartProfileGroups.Margin = new System.Windows.Forms.Padding(4);
            this.ChartProfileGroups.Name = "ChartProfileGroups";
            series1.BorderColor = System.Drawing.Color.Black;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            series1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            series1.Legend = "Legend1";
            series1.Name = "Surveys Activity %";
            series1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Grayscale;
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            this.ChartProfileGroups.Series.Add(series1);
            this.ChartProfileGroups.Size = new System.Drawing.Size(546, 218);
            this.ChartProfileGroups.TabIndex = 14;
            this.ChartProfileGroups.Text = "chart1";
            this.ChartProfileGroups.Click += new System.EventHandler(this.ChartProfileGroups_Click);
            // 
            // BtnProfileGroups1
            // 
            this.BtnProfileGroups1.Enabled = false;
            this.BtnProfileGroups1.Location = new System.Drawing.Point(907, 130);
            this.BtnProfileGroups1.Margin = new System.Windows.Forms.Padding(4);
            this.BtnProfileGroups1.Name = "BtnProfileGroups1";
            this.BtnProfileGroups1.Size = new System.Drawing.Size(100, 28);
            this.BtnProfileGroups1.TabIndex = 15;
            this.BtnProfileGroups1.Text = "Details";
            this.BtnProfileGroups1.UseVisualStyleBackColor = true;
            this.BtnProfileGroups1.Visible = false;
            this.BtnProfileGroups1.Click += new System.EventHandler(this.BtnProfileGroups1_Click);
            // 
            // BtnProfileGroups2
            // 
            this.BtnProfileGroups2.Enabled = false;
            this.BtnProfileGroups2.Location = new System.Drawing.Point(907, 166);
            this.BtnProfileGroups2.Margin = new System.Windows.Forms.Padding(4);
            this.BtnProfileGroups2.Name = "BtnProfileGroups2";
            this.BtnProfileGroups2.Size = new System.Drawing.Size(100, 28);
            this.BtnProfileGroups2.TabIndex = 16;
            this.BtnProfileGroups2.Text = "Details";
            this.BtnProfileGroups2.UseVisualStyleBackColor = true;
            this.BtnProfileGroups2.Visible = false;
            // 
            // BtnProfileGroups3
            // 
            this.BtnProfileGroups3.Enabled = false;
            this.BtnProfileGroups3.Location = new System.Drawing.Point(907, 206);
            this.BtnProfileGroups3.Margin = new System.Windows.Forms.Padding(4);
            this.BtnProfileGroups3.Name = "BtnProfileGroups3";
            this.BtnProfileGroups3.Size = new System.Drawing.Size(100, 28);
            this.BtnProfileGroups3.TabIndex = 17;
            this.BtnProfileGroups3.Text = "Details";
            this.BtnProfileGroups3.UseVisualStyleBackColor = true;
            this.BtnProfileGroups3.Visible = false;
            // 
            // BtnProfileGroups4
            // 
            this.BtnProfileGroups4.Enabled = false;
            this.BtnProfileGroups4.Location = new System.Drawing.Point(905, 249);
            this.BtnProfileGroups4.Margin = new System.Windows.Forms.Padding(4);
            this.BtnProfileGroups4.Name = "BtnProfileGroups4";
            this.BtnProfileGroups4.Size = new System.Drawing.Size(100, 28);
            this.BtnProfileGroups4.TabIndex = 18;
            this.BtnProfileGroups4.Text = "Details";
            this.BtnProfileGroups4.UseVisualStyleBackColor = true;
            this.BtnProfileGroups4.Visible = false;
            // 
            // UserProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.BtnProfileGroups4);
            this.Controls.Add(this.BtnProfileGroups3);
            this.Controls.Add(this.BtnProfileGroups2);
            this.Controls.Add(this.BtnProfileGroups1);
            this.Controls.Add(this.ChartProfileGroups);
            this.Controls.Add(this.TbProfileGroups2);
            this.Controls.Add(this.TbProfileGroups3);
            this.Controls.Add(this.TbProfileGroups4);
            this.Controls.Add(this.TbProfileGroups1);
            this.Controls.Add(this.LbProfileGroups);
            this.Controls.Add(this.BtnProfileInfo);
            this.Controls.Add(this.TbProfileEmail);
            this.Controls.Add(this.TbPofileName);
            this.Controls.Add(this.TbProfileLogin);
            this.Controls.Add(this.LbProfileName);
            this.Controls.Add(this.LbProfileEmail);
            this.Controls.Add(this.LbProfileLogin);
            this.Controls.Add(this.LbProfileInfo);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "UserProfile";
            this.Text = "UserProfile";
            this.Load += new System.EventHandler(this.UserProfile_Load);
            this.Controls.SetChildIndex(this.LbProfileInfo, 0);
            this.Controls.SetChildIndex(this.LbProfileLogin, 0);
            this.Controls.SetChildIndex(this.LbProfileEmail, 0);
            this.Controls.SetChildIndex(this.LbProfileName, 0);
            this.Controls.SetChildIndex(this.TbProfileLogin, 0);
            this.Controls.SetChildIndex(this.TbPofileName, 0);
            this.Controls.SetChildIndex(this.TbProfileEmail, 0);
            this.Controls.SetChildIndex(this.BtnProfileInfo, 0);
            this.Controls.SetChildIndex(this.LbProfileGroups, 0);
            this.Controls.SetChildIndex(this.TbProfileGroups1, 0);
            this.Controls.SetChildIndex(this.TbProfileGroups4, 0);
            this.Controls.SetChildIndex(this.TbProfileGroups3, 0);
            this.Controls.SetChildIndex(this.TbProfileGroups2, 0);
            this.Controls.SetChildIndex(this.ChartProfileGroups, 0);
            this.Controls.SetChildIndex(this.BtnProfileGroups1, 0);
            this.Controls.SetChildIndex(this.BtnProfileGroups2, 0);
            this.Controls.SetChildIndex(this.BtnProfileGroups3, 0);
            this.Controls.SetChildIndex(this.BtnProfileGroups4, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ChartProfileGroups)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label LbProfileGroups;
        private System.Windows.Forms.Label LbProfileInfo;
        private System.Windows.Forms.Label LbProfileLogin;
        private System.Windows.Forms.Label LbProfileEmail;
        private System.Windows.Forms.Label LbProfileName;
        private System.Windows.Forms.TextBox TbProfileLogin;
        private System.Windows.Forms.TextBox TbPofileName;
        private System.Windows.Forms.TextBox TbProfileEmail;
        private System.Windows.Forms.Button BtnProfileInfo;
        private System.Windows.Forms.TextBox TbProfileGroups1;
        private System.Windows.Forms.TextBox TbProfileGroups4;
        private System.Windows.Forms.TextBox TbProfileGroups3;
        private System.Windows.Forms.TextBox TbProfileGroups2;
        private System.Windows.Forms.DataVisualization.Charting.Chart ChartProfileGroups;
        private System.Windows.Forms.Button BtnProfileGroups1;
        private System.Windows.Forms.Button BtnProfileGroups2;
        private System.Windows.Forms.Button BtnProfileGroups3;
        private System.Windows.Forms.Button BtnProfileGroups4;
    }
}