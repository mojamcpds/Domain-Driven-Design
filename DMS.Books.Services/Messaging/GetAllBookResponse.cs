using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DMS.Books.Services.Viewmodels;

namespace DMS.Books.Services.Messaging
{
    public class GetAllBookResponse
    {
        public GetAllBookResponse()
        {
            BookDetails = new List<BookDetailsView>();
        }

        public IEnumerable<BookDetailsView> BookDetails { get; set; }
    }
}
