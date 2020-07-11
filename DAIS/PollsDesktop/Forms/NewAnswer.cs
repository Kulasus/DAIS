using PollsDesktop.DATABASE.DAO;
using PollsDesktop.DATABASE.DTO;
using PollsDesktop.DATABASE;
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
    public partial class NewAnswer : FormMenuTemplate
    {
        public NewAnswer()
        {
            InitializeComponent();
        }

        private void NewAnswer_Load(object sender, EventArgs e)
        {
            Database db = new Database();
            db.Connect();
            //Selecting all groups where user is
            Collection<GroupDTO> groups = new Collection<GroupDTO>();
            Collection<UserGroupDTO> usergroups = new Collection<UserGroupDTO>();
            usergroups = new UserGroupDAO().SelectByUserLogin(Session.LoggedUser.Login, db);
            foreach (UserGroupDTO ug in usergroups)
            {
                groups.Add(new GroupDAO().Select(ug.GroupId));
            }
            //Selecting all surveys accessible for user
            SurveyDAO surveyDAO = new SurveyDAO();
            Collection<SurveyDTO> surveys = new Collection<SurveyDTO>();
            Collection<SurveyDTO> surveysTmp = new Collection<SurveyDTO>();
            foreach (GroupDTO g in groups)
            {
                surveysTmp = surveyDAO.SelectByGroupId(g.Id);
                foreach (SurveyDTO s in surveysTmp)
                {
                    surveys.Add(s);
                }
            }
            //Deleting surveys which are already answered or aren't ongoing
            AnswerDAO answerDAO = new AnswerDAO();
            Collection<AnswerDTO> answers = new Collection<AnswerDTO>();
            Collection<SurveyDTO> realSurveys = new Collection<SurveyDTO>();
            foreach (SurveyDTO s in surveys)
            {
                if (s.StateId != 3)
                {
                    Console.WriteLine("break1 " + s.Id);
                    continue;

                    //surveys.Remove(s);
                }
                else
                {
                    answers = answerDAO.SelectBySurveyId(s.Id, db);
                    if (answers.Count != 0)
                    {
                        Console.WriteLine("break2 " + s.Id);
                        continue;

                        //surveys.Remove(s);
                    }
                    else
                    {
                        realSurveys.Add(s);
                        CmbNewAnswer.Items.Add(s.Title);
                    }
                }
            }

            //Now I have suitable content for combobox in variable REALsurveys
            Console.WriteLine("xxxxxxxxxxxxxx " + surveys.Count);
            Console.WriteLine("xxxxxxxxxxxxxx " + realSurveys.Count);
            Session.NewAnswerSurveys = realSurveys;
        }

        private void BtnNewAnswer_Click(object sender, EventArgs e)
        {
            if(TbNewAnswerText.Text.Length <= 0 || CmbNewAnswer.SelectedItem == null)
            {
                MessageBox.Show("Invalid parameter!");
            }
            else
            {
                AnswerDAO dao = new AnswerDAO();
                AnswerDTO dto = new AnswerDTO();
                dto.Text = TbNewAnswerText.Text;
                dto.UserLogin = Session.LoggedUser.Login;
                dto.SurveyId = Session.NewAnswerSurveys[CmbNewAnswer.SelectedIndex].Id;
                dao.Insert(dto);
                var v = new UserProfile();
                this.Close();
                v.Show();
            }
        }

        private void BtnNewAnswerBack_Click(object sender, EventArgs e)
        {
            var v = new UserProfile();
            this.Close();
            v.Show();
        }

        private void CmbNewAnswer_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
