using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DMS.Books.Services.Viewmodels;

namespace DMS.Books.Services.Messaging
{
    public class HomePageResponse
    {
        public HomePageResponse()
        {
            TopRecent = new List<BookSummaryView>();
            TopDownloaded = new List<BookSummaryView>();
            TopRated = new List<BookSummaryView>();
        }

        public IEnumerable<BookSummaryView> TopRecent { get; set; }
        public IEnumerable<BookSummaryView> TopDownloaded { get; set; }
        public IEnumerable<BookSummaryView> TopRated { get; set; }
    }
}
