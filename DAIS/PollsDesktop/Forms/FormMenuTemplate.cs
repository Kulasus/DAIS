using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PollsDesktop.Forms
{
    public partial class FormMenuTemplate : Form
    {
        public FormMenuTemplate()
        {
            InitializeComponent();
        }

        private void myGroupsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void myProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(Session.LoggedUser.RoleId == 3)
            {
                var v = new UserProfile();
                this.Close();
                v.Show();
            }
            else
            {
                var v = new ManagerProfile();
                this.Close();
                v.Show();
            }
        }

        private void mySurveysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(Session.LoggedUser.RoleId != 3)
            {
                var v = new MySurveys();
                this.Close();
                v.Show();   
            }
            else
            {
                MessageBox.Show("Only for managers!");
            }
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var v = new Form1();
            this.Close();
            v.Show();
            Session.LoggedUser = null;
        }

        private void myAnswersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Session.LoggedUser.RoleId == 3)
            {
                var v = new NewAnswer();
                this.Close();
                v.Show();
            }
            else
            {
                MessageBox.Show("Only for employees!");
            }
        }
    }
}
