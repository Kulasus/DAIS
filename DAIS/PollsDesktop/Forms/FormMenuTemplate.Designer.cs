namespace PollsDesktop.Forms
{
    partial class FormMenuTemplate
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.myPollsAppToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.myProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.myGroupsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mySurveysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.myNotificationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.categoriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.myAnswersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.myPollsAppToolStripMenuItem,
            this.adminToolStripMenuItem,
            this.logoutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // myPollsAppToolStripMenuItem
            // 
            this.myPollsAppToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.myProfileToolStripMenuItem,
            this.myGroupsToolStripMenuItem,
            this.mySurveysToolStripMenuItem,
            this.myNotificationsToolStripMenuItem,
            this.myAnswersToolStripMenuItem});
            this.myPollsAppToolStripMenuItem.Name = "myPollsAppToolStripMenuItem";
            this.myPollsAppToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.myPollsAppToolStripMenuItem.Text = "My PollsApp";
            // 
            // myProfileToolStripMenuItem
            // 
            this.myProfileToolStripMenuItem.Name = "myProfileToolStripMenuItem";
            this.myProfileToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.myProfileToolStripMenuItem.Text = "My profile";
            this.myProfileToolStripMenuItem.Click += new System.EventHandler(this.myProfileToolStripMenuItem_Click);
            // 
            // myGroupsToolStripMenuItem
            // 
            this.myGroupsToolStripMenuItem.Enabled = false;
            this.myGroupsToolStripMenuItem.Name = "myGroupsToolStripMenuItem";
            this.myGroupsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.myGroupsToolStripMenuItem.Text = "My groups";
            this.myGroupsToolStripMenuItem.Click += new System.EventHandler(this.myGroupsToolStripMenuItem_Click);
            // 
            // mySurveysToolStripMenuItem
            // 
            this.mySurveysToolStripMenuItem.Name = "mySurveysToolStripMenuItem";
            this.mySurveysToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.mySurveysToolStripMenuItem.Text = "My surveys";
            this.mySurveysToolStripMenuItem.Click += new System.EventHandler(this.mySurveysToolStripMenuItem_Click);
            // 
            // myNotificationsToolStripMenuItem
            // 
            this.myNotificationsToolStripMenuItem.Enabled = false;
            this.myNotificationsToolStripMenuItem.Name = "myNotificationsToolStripMenuItem";
            this.myNotificationsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.myNotificationsToolStripMenuItem.Text = "My notifications";
            // 
            // adminToolStripMenuItem
            // 
            this.adminToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usersToolStripMenuItem,
            this.categoriesToolStripMenuItem});
            this.adminToolStripMenuItem.Enabled = false;
            this.adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            this.adminToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.adminToolStripMenuItem.Text = "Admin";
            // 
            // usersToolStripMenuItem
            // 
            this.usersToolStripMenuItem.Enabled = false;
            this.usersToolStripMenuItem.Name = "usersToolStripMenuItem";
            this.usersToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.usersToolStripMenuItem.Text = "Users";
            // 
            // categoriesToolStripMenuItem
            // 
            this.categoriesToolStripMenuItem.Enabled = false;
            this.categoriesToolStripMenuItem.Name = "categoriesToolStripMenuItem";
            this.categoriesToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.categoriesToolStripMenuItem.Text = "Categories";
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.logoutToolStripMenuItem.Text = "Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // myAnswersToolStripMenuItem
            // 
            this.myAnswersToolStripMenuItem.Name = "myAnswersToolStripMenuItem";
            this.myAnswersToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.myAnswersToolStripMenuItem.Text = "My answers";
            this.myAnswersToolStripMenuItem.Click += new System.EventHandler(this.myAnswersToolStripMenuItem_Click);
            // 
            // FormMenuTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMenuTemplate";
            this.Text = "FormMenuTemplate";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem myPollsAppToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem myProfileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem myGroupsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mySurveysToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem myNotificationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem categoriesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem myAnswersToolStripMenuItem;
    }
}