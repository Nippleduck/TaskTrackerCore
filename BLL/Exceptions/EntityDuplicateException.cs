using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Exceptions
{
    public class EntityDuplicateException : Exception
    {
        public EntityDuplicateException(string message)
            : base(message) { }
    }
}
