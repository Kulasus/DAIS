using System;
using System.Collections.Generic;
using System.Text;

namespace PollsDesktop.DATABASE
{
    class ORMException : Exception
    {
        public ORMException(string message) : base(message){}
    }
}
