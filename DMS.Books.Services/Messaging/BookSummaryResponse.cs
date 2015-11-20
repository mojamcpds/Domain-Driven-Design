using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DMS.Books.Services.Viewmodels;

namespace DMS.Books.Services.Messaging
{
    public class BookSummaryResponse
    {
        public IEnumerable<BookSummaryView> BookSummaries { get; set; }
        public IEnumerable<String> IniatialCharacters { get; set; }
        public int Count { get; set; }
    }
}
