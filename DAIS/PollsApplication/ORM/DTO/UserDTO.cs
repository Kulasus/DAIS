using System;
using System.Collections.Generic;
using System.Text;

namespace PollsApplication.ORM.DTO
{
    class UserDTO
    {
        public String Login { get; set; }
        public String Fname { get; set; }
        public String Lname { get; set; }
        public String Email { get; set; }
        public DateTime? LastVisit { get; set; }
        public int RoleId { get; set; }
        public String State { get; set; }
    }
}
