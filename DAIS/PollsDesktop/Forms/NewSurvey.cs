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
using PollsDesktop.DATABASE.DTO;
using PollsDesktop.DATABASE.DAO;

namespace PollsDesktop.Forms
{
    public partial class NewSurvey : FormMenuTemplate
    {
        public NewSurvey()
        {
            InitializeComponent();
        }

        private void NewSurvey_Load(object sender, EventArgs e)
        {
            GroupDAO dao = new GroupDAO();
            Session.NewSurveyGroups = dao.SelectByManagerLogin(Session.LoggedUser.Login);
            foreach(GroupDTO item in Session.NewSurveyGroups)
            {
                CmbNewSurvey.Items.Add(item.Title);
            }
        }

        private void BtnNewSurvey_Click(object sender, EventArgs e)
        {
            if(TbNewSurveyDesc.Text.Length <= 0 || TbNewSurveyText.Text.Length <= 0 || TbNewSurveyTitle.Text.Length <= 0 || CmbNewSurvey.SelectedItem == null)
            {
                MessageBox.Show("Invalid parameters!");
            }
            else
            {
                SurveyDAO dao = new SurveyDAO();
                SurveyDTO dto = new SurveyDTO();
                dto.Title = TbNewSurveyTitle.Text;
                dto.Text = TbNewSurveyText.Text;
                dto.Description = TbNewSurveyDesc.Text;
                dto.GroupId = Session.NewSurveyGroups[CmbNewSurvey.SelectedIndex].Id;
                dao.Insert(dto);
                var v = new MySurveys();
                this.Close();
                v.Show();
            }
        }

        private void BtnNewSurveyBack_Click(object sender, EventArgs e)
        {
            var v = new MySurveys();
            this.Close();
            v.Show();
        }
    }
}
