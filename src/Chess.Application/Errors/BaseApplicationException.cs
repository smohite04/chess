using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Application
{
    public class BaseApplicationException : Exception
    {
        public BaseApplicationException(string message) : base(message)
        {
        }      
    }
}
