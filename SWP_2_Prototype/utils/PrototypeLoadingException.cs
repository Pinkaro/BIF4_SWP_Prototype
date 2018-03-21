using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWP_2_Prototype.utils
{
    class PrototypeLoadingException : Exception
    {
        public PrototypeLoadingException()
        {
        }

        public PrototypeLoadingException(string message)
        : base(message)
        {
        }

        public PrototypeLoadingException(string message, Exception inner)
        : base(message, inner)
        {
        }
    }
}
