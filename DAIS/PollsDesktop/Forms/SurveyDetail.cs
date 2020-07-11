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
using PollsDesktop.DATABASE;
using PollsDesktop.DATABASE.DAO;
using PollsDesktop.DATABASE.DTO;

namespace PollsDesktop.Forms
{
    public partial class SurveyDetail : FormMenuTemplate
    {
        public SurveyDetail()
        {
            InitializeComponent();
        }

        private void SurveyDetail_Load(object sender, EventArgs e)
        {
            TbSurveyDetailsTitle.Text = Session.SelectedSurvey.Title;
            TbSurveyDetailsText.Text = Session.SelectedSurvey.Text;
            StateDAO daoS = new StateDAO();
            GroupDAO daoG = new GroupDAO();
            StateDTO stateDTO = daoS.Select(Session.SelectedSurvey.StateId);
            GroupDTO groupDTO = daoG.Select(Session.SelectedSurvey.GroupId);
            TbSurveyDetailsLogin.Text = groupDTO.ManagerLogin;
            TbSurveyDetailsState.Text = stateDTO.Title;

            LoadAnswers();
            LoadChart();
        }

        private void LoadAnswers()
        {
            DataGridViewSurveyDetails.ColumnCount = 1;
            //DataGridViewSurveyDetails.Columns[0].Name = "Id";
            DataGridViewSurveyDetails.Columns[0].Name = "Text";

            Session.SurveysAnswers = new Collection<int>();

            AnswerDAO daoA = new AnswerDAO();
            Database db = new Database();
            db.Connect();
            Collection<AnswerDTO> answers = daoA.SelectBySurveyId(Session.SelectedSurvey.Id, db);
            foreach(AnswerDTO item in answers)
            {
                Session.SurveysAnswers.Add(item.Id);
                string[] row = new string[] {item.Text };
                DataGridViewSurveyDetails.Rows.Add(row);
            }

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            DataGridViewSurveyDetails.Columns.Add(btn);
            btn.HeaderText = "Details";
            btn.Text = "Click here";
            btn.Name = "btn";
            btn.UseColumnTextForButtonValue = true;
        }

        private void BtnSurveyDetailsBack_Click(object sender, EventArgs e)
        {
            var v = new MySurveys();
            this.Close();
            v.Show();
        }
        private void DataGridViewSurveyDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.RowIndex != DataGridViewSurveyDetails.Rows.Count - 1)
            {
                AnswerDAO dao = new AnswerDAO();
                Session.SelectedAnswer = dao.Select(Session.SurveysAnswers[e.RowIndex]);
                var v = new AnswerDetails();
                v.Show();
            }

        }

        private void LoadChart()
        {
            SurveyDAO.SetAnswerPercentage(Session.SelectedSurvey.Id);
            SurveyDAO dao = new SurveyDAO();
            Session.SelectedSurvey.AnswersPercentage = dao.Select(Session.SelectedSurvey.Id).AnswersPercentage;
            ChartSurveyDetails.Series["Answers"].Points.AddXY("Answered", Session.SelectedSurvey.AnswersPercentage);
            ChartSurveyDetails.Series["Answers"].Points.AddXY("Unanswered", 100 - Session.SelectedSurvey.AnswersPercentage);
        }
    }
}
