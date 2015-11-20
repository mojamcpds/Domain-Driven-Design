using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DMS.Books.Services.Viewmodels;

namespace DMS.Books.Services.Messaging
{
    public class SubjectsResponse
    {
        public SubjectsResponse()
        {
            Subjects = new List<BookCategoryView>();
            Initials = new List<string>();
        }
        public IEnumerable<BookCategoryView> Subjects { get; set; }
        public IEnumerable<string> Initials { get; set; }
        public int CategoryCount { get; set; }
    }
}
