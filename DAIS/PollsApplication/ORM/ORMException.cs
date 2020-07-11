using System;
using System.Collections.Generic;
using System.Text;

namespace PollsApplication.ORM
{
    class ORMException : Exception
    {
        public ORMException(string message) : base(message){}
    }
}
