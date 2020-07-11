using PollsDesktop.DATABASE;
using PollsDesktop.DATABASE.DAO;
using PollsDesktop.DATABASE.DTO;
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
    public partial class UserProfileChange : Form
    {
        public UserProfileChange()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void BtnProfileChangeConfirm_Click(object sender, EventArgs e)
        {
            if (TbProfileChangeName.Text.Length < 1 || TbProfileChangeName.Text.Length < 1 || !TbProfileChangeEmail.Text.Contains('@'))
            {
                MessageBox.Show("Invalid data!");
            }
            else{
                string fname = TbProfileChangeName.Text.Substring(0,TbProfileChangeName.Text.IndexOf(' '));
                string lname = TbProfileChangeName.Text.Substring(TbProfileChangeName.Text.IndexOf(' ')+1);
                string email = TbProfileChangeEmail.Text;
                if (lname.Length < 5 || fname.Length < 3 || fname.Substring(0, 3).ToLower() + lname.Substring(0, 5).ToLower() + Session.LoggedUser.Login.Substring(8) != Session.LoggedUser.Login)
                {
                    MessageBox.Show("Invalid data! Your new name is not consistent with our bussines policy! Please contact our support to change your name manualy on lukas.kondiolka.st@vsb.cz");
                }
                else
                {
                    Session.LoggedUser.Lname = lname;
                    Session.LoggedUser.Fname = fname;
                    Session.LoggedUser.Email = email;
                    UserDAO dao = new UserDAO();
                    dao.Update(Session.LoggedUser);
                }
            }
            if (Session.LoggedUser.RoleId == 3)
            {
                var m = new UserProfile();
                m.Show();
                this.Hide();
            }
            else
            {
                var m = new ManagerProfile();
                m.Show();
                this.Hide();
            }
        }

        private void UserProfileChange_Load(object sender, EventArgs e)
        {
            TbProfileChangeEmail.Text = Session.LoggedUser.Email;
            TbProfileChangeName.Text = Session.LoggedUser.Fname + " " + Session.LoggedUser.Lname;
        }
    }
}
