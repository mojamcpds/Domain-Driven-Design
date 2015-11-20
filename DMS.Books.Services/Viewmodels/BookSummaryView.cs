using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Books.Services.Viewmodels
{
    public class BookSummaryView
    {
        public int Id { get; set; }
        public string TitleBengali { get; set; }
        public string TitleEnglish { get; set; }
        public decimal PriceBdt { get; set; }
    }
}
