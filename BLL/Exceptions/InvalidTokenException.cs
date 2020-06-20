using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Exceptions
{
    public class InvalidTokenException : Exception
    {
        public InvalidTokenException(string message)
            : base(message) { }
    }
}
