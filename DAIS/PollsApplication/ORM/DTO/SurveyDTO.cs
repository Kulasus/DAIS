using System;
using System.Collections.Generic;
using System.Text;

namespace PollsApplication.ORM.DTO
{
    class SurveyDTO
    {
        public int Id { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
        public String Text { get; set; }
        public int? AnswersPercentage { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public long? Duration { get; set; }
        public int GroupId { get; set; }
        public int StateId { get; set; }
    }
}
