using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PollsDesktop.DATABASE.DTO;
using PollsDesktop.DATABASE.DAO;
using PollsDesktop.Forms;

namespace PollsDesktop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string login = TbLogin.Text;
            if (login.Length != 10)
            {
                MessageBox.Show("Invalid username!");
            }
            else
            {
                try
                {
                    UserDTO user = new UserDAO().Select(login);
                    RefreshTime(user);
                    Session.LoggedUser = user;
                    if(user.RoleId == 3)
                    {
                        var m = new UserProfile();
                        this.Hide();
                        m.Show();
                    }
                    else
                    {
                        var m = new ManagerProfile();
                        this.Hide();
                        m.Show();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Username doesn't exist.");
                    //throw e;
                }
            }   
        }
        private void RefreshTime(UserDTO user)
        {
            user.LastVisit = DateTime.Now;
            UserDAO dao = new UserDAO();
            dao.Update(user);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
