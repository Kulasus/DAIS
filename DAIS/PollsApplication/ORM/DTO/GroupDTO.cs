using System;
using System.Collections.Generic;
using System.Text;

namespace PollsApplication.ORM.DTO
{
    class GroupDTO
    {
        public int Id { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
        public String ManagerLogin { get; set; }
        public DateTime CreationDate { get; set; }

    }
}
