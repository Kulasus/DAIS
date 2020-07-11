using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PollsDesktop.DATABASE.DTO;

namespace PollsDesktop
{
    static class Session
    {
        public static UserDTO LoggedUser { get; set; }

        public static Collection<int> SurveysAnswers = new Collection<int>();

        public static Collection<int> MySurveys = new Collection<int>();

        public static Collection<GroupDTO> NewSurveyGroups = new Collection<GroupDTO>();

        public static Collection<SurveyDTO> NewAnswerSurveys = new Collection<SurveyDTO>();
        public static SurveyDTO SelectedSurvey { get; set; }
        public static AnswerDTO SelectedAnswer { get; set; }
    }
}
