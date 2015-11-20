using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Books.Services.Viewmodels
{
    public class BookDetailsView
    {
        public int Id { get; set; }
        public string BookNameBengali { get; set; }
        public string BookNameEnglish { get; set; }
        public int CategoryId { get; set; }
        public string CategoryNameBengali { get; set; }
        public string CategoryNameEnglish { get; set; }
        public decimal Price { get; set; }
    }
}
