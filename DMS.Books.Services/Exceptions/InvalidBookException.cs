using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Books.Services.Exceptions
{
    public class InvalidBookException:Exception
    {
        public InvalidBookException(string message)
            : base(message)
        {
        }
    }
}
