using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DMS.Books.Services.Viewmodels;

namespace DMS.Books.Services.Messaging
{
    public class BookByAuthorResponse
    {
        public IEnumerable<BookSummaryView> Books { get; set; }
        public IEnumerable<BookCategoryView> BookCategoryViews { get; set; }
        public int BookCount { get; set; }
        public List<string> InitialCharacters { get; set; }
    }
}
