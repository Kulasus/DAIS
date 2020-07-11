using PollsDesktop.DATABASE;
using PollsDesktop.DATABASE.DAO;
using PollsDesktop.DATABASE.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PollsDesktop.Forms
{
    public partial class UserProfile : FormMenuTemplate
    {
        public UserProfile()
        {
            InitializeComponent();
        }

        private void UserProfile_Load(object sender, EventArgs e)
        {
            SetChart();
            TbPofileName.Text = Session.LoggedUser.Fname + " " + Session.LoggedUser.Lname;
            TbProfileEmail.Text = Session.LoggedUser.Email;
            TbProfileLogin.Text = Session.LoggedUser.Login;
            Database db = new Database();
            db.Connect();
            Collection<GroupDTO> groups = new Collection<GroupDTO>();
            Collection<UserGroupDTO> usergroups = new Collection<UserGroupDTO>();
            usergroups = new UserGroupDAO().SelectByUserLogin(Session.LoggedUser.Login,db);
            foreach (UserGroupDTO ug in usergroups)
            {
                groups.Add(new GroupDAO().Select(ug.GroupId));
            }
            SetGroups(groups);
        }

        private void SetChart()
        {
            Database db = new Database();
            db.Connect();
            ChartProfileGroups.Series["Surveys Activity %"].Points.AddXY("Answered", UserDAO.GetUserAnswersPercentage(Session.LoggedUser.Login, db));
            ChartProfileGroups.Series["Surveys Activity %"].Points.AddXY("Unanswered", 100 - UserDAO.GetUserAnswersPercentage(Session.LoggedUser.Login, db));
        }
        private void SetGroups(Collection<GroupDTO> groups)
        {
            if(groups.Count >= 1){
                TbProfileGroups1.Text = groups[0].Title;
                TbProfileGroups1.Visible = true;
                BtnProfileGroups1.Visible = true;
            }
            if (groups.Count >= 2)
            {
                TbProfileGroups2.Text = groups[1].Title;
                TbProfileGroups2.Visible = true;
                BtnProfileGroups2.Visible = true;
            }
            if (groups.Count >= 3)
            {
                TbProfileGroups3.Text = groups[2].Title;
                TbProfileGroups3.Visible = true;
                BtnProfileGroups3.Visible = true;
            }
            if (groups.Count >= 4)
            {
                TbProfileGroups4.Text = groups[3].Title;
                TbProfileGroups4.Visible = true;
                BtnProfileGroups4.Visible = true;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void LbProfileGroups_Click(object sender, EventArgs e)
        {

        }

        private void BtnProfileInfo_Click(object sender, EventArgs e)
        {
            var m = new UserProfileChange();
            this.Close();
            m.Show();

        }

        private void ChartProfileGroups_Click(object sender, EventArgs e)
        {

        }

        private void BtnProfileGroups1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
