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
using PollsDesktop.DATABASE.DAO;
using PollsDesktop.DATABASE.DTO;

namespace PollsDesktop.Forms
{
    public partial class MySurveys : FormMenuTemplate
    {
        public MySurveys()
        {
            InitializeComponent();
        }

        private void MySurveys_Load(object sender, EventArgs e)
        {
            if(Session.LoggedUser.RoleId == 3)
            {
                BtnMySurveysNew.Enabled = false;
            }
            DataGridViewMySurveys.ColumnCount = 4;
            DataGridViewMySurveys.Columns[0].Name = "Title";
            DataGridViewMySurveys.Columns[1].Name = "Creation Date";
            DataGridViewMySurveys.Columns[2].Name = "Start Date";
            DataGridViewMySurveys.Columns[3].Name = "End Date";

            Session.MySurveys = new Collection<int>();

            GroupDAO daoG = new GroupDAO();
            SurveyDAO daoS = new SurveyDAO();
            Collection<GroupDTO> groups = daoG.SelectByManagerLogin(Session.LoggedUser.Login);
            foreach (GroupDTO item in groups)
            {
                Collection<SurveyDTO> groupsSurveys = daoS.SelectByGroupId(item.Id);
                foreach (SurveyDTO s in groupsSurveys)
                {
                    Session.MySurveys.Add(Convert.ToInt32(s.Id));
                    string[] row = new string[] { s.Title, s.CreationDate.ToString(), s.StartDate.ToString(), s.EndDate.ToString()};
                    DataGridViewMySurveys.Rows.Add(row);
                }
            }

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            DataGridViewMySurveys.Columns.Add(btn);
            btn.HeaderText = "Survey Details";
            btn.Text = "Details";
            btn.Name = "btn";
            btn.UseColumnTextForButtonValue = true;

            DataGridViewButtonColumn btnStart = new DataGridViewButtonColumn();
            DataGridViewMySurveys.Columns.Add(btnStart);
            btnStart.HeaderText = "Start Survey";
            btnStart.Text = "Start";
            btnStart.Name = "btnStart";
            btnStart.UseColumnTextForButtonValue = true;

            DataGridViewButtonColumn btnEnd = new DataGridViewButtonColumn();
            DataGridViewMySurveys.Columns.Add(btnEnd);
            btnEnd.HeaderText = "End Survey";
            btnEnd.Text = "End";
            btnEnd.Name = "btnEnd";
            btnEnd.UseColumnTextForButtonValue = true;

            DataGridViewButtonColumn btnArchive = new DataGridViewButtonColumn();
            DataGridViewMySurveys.Columns.Add(btnArchive);
            btnArchive.HeaderText = "Archive Survey";
            btnArchive.Text = "Archive";
            btnArchive.Name = "btnArchive";
            btnArchive.UseColumnTextForButtonValue = true;

        }
        private void DataGridViewMySurveys_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //details
            if (e.ColumnIndex == 4 && e.RowIndex != DataGridViewMySurveys.Rows.Count-1)
            {
                SurveyDAO dao = new SurveyDAO();
                Session.SelectedSurvey = dao.Select(Session.MySurveys[e.RowIndex]);
                var v = new SurveyDetail();
                this.Close();
                v.Show();
            }
            //start
            else if (e.ColumnIndex == 5 && e.RowIndex != DataGridViewMySurveys.Rows.Count - 1)
            {
                SurveyDAO dao = new SurveyDAO();
                Session.SelectedSurvey = dao.Select(Session.MySurveys[e.RowIndex]);
                if (Session.SelectedSurvey.StateId != 2)
                {
                    MessageBox.Show("Can't start this survey!");
                }
                else
                {
                    SurveyDAO.StartSurvey(Session.SelectedSurvey.Id);
                    DataGridViewMySurveys.Refresh();
                    var v = new MySurveys();
                    this.Close();
                    v.Show();
                }
            }
            //end
            else if (e.ColumnIndex == 6 && e.RowIndex != DataGridViewMySurveys.Rows.Count - 1)
            {
                SurveyDAO dao = new SurveyDAO();
                Session.SelectedSurvey = dao.Select(Session.MySurveys[e.RowIndex]);
                if(Session.SelectedSurvey.StateId != 3)
                {
                    MessageBox.Show("Can't end this survey!");
                }
                else
                {
                    SurveyDAO.EndSurvey(Session.SelectedSurvey.Id);
                    DataGridViewMySurveys.Refresh();
                    var v = new MySurveys();
                    this.Close();
                    v.Show();
                }
            }
            //archive
            else if (e.ColumnIndex == 7 && e.RowIndex != DataGridViewMySurveys.Rows.Count - 1)
            {
                SurveyDAO dao = new SurveyDAO();
                Session.SelectedSurvey = dao.Select(Session.MySurveys[e.RowIndex]);
                if (Session.SelectedSurvey.StateId != 4)
                {
                    MessageBox.Show("Can't archive this survey!");
                }
                else
                {
                    SurveyDAO.ArchiveSurvey(Session.SelectedSurvey.Id);
                    DataGridViewMySurveys.Refresh();
                    var v = new MySurveys();
                    this.Close();
                    v.Show();
                }
            }
        }

        private void DataGridViewMySurveys_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BtnMySurveysNew_Click(object sender, EventArgs e)
        {
            var v = new NewSurvey();
            this.Close();
            v.Show();
        }
    }
}
