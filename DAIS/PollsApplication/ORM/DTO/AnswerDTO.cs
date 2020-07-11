using System;
using System.Collections.Generic;
using System.Text;

namespace PollsApplication.ORM.DTO
{
    class AnswerDTO
    {
        public int Id { get; set; }
        public String Text { get; set; }
        public DateTime? CreationDate { get; set; }
        public String UserLogin { get; set; }
        public int SurveyId { get; set; }
    }
}
