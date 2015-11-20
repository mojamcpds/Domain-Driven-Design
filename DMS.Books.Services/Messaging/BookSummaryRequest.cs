using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Books.Services.Messaging
{
    public class BookSummaryRequest
    {
        public int Take { get; set; }
        public int Skip { get; set; }
        public string SearchString { get; set; }
    }
}
