using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DMS.Books.Services.Viewmodels;

namespace DMS.Books.Services.Messaging
{
    public class CategoryResponse
    {
        public CategoryResponse()
        {
            Categories = new List<BookCategoryView>();
        }
        public IEnumerable<BookCategoryView> Categories { get; set; }
    }
}
