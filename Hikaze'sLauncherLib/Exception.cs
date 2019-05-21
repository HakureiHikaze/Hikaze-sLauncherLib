using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    public class TypeErrException :ApplicationException
    {
        public TypeErrException(string message):base(message)
        {

        }
    }
}
