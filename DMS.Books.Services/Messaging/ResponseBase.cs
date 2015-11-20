using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Books.Services.Messaging
{
    public class ResponseBase
    {
        public bool TransactionStatus { get; set; }
        public string TransactionMessage { get; set; }
    }
}
