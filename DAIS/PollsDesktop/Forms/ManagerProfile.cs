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
    public partial class ManagerProfile : FormMenuTemplate
    {
        public ManagerProfile()
        {
            InitializeComponent();
        }

        private void ManagerProfile_Load(object sender, EventArgs e)
        {
            TbPofileName.Text = Session.LoggedUser.Fname + " " + Session.LoggedUser.Lname;
            TbProfileEmail.Text = Session.LoggedUser.Email;
            TbProfileLogin.Text = Session.LoggedUser.Login;
        }

        private void BtnProfileInfo_Click(object sender, EventArgs e)
        {
            var m = new UserProfileChange();
            this.Close();
            m.Show();
        }
    }
}
