using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Books.Services.Viewmodels
{
    public class CreateBookView
    {
        public int Id { get; set; }
        public string TitleE { get; set; }
        public string TitleB { get; set; }
        public int BookCategoryId { get; set; }
        public int TotalPage { get; set; }
        public byte[] CoverPage { get; set; }
        public decimal Price { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Description { get; set; }
        public int IsActive { get; set; }
        public string Remarks { get; set; }
        public string IsbnNumber { get; set; }
    }
}
