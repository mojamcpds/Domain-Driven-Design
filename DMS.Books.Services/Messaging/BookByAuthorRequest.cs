using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Books.Services.Messaging
{
    public class BookByAuthorRequest
    {
        public int AuthorId { get; set; }
        public int BookSkip { get; set; }
        public int BookTake { get; set; }
        public string BookSearchString { get; set; }
        public string CategorySearchString { get; set; }
    }
}
