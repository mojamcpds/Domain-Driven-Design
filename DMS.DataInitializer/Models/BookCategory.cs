
namespace DMS.DataInitializer.Models
{
    using System;
    using System.Collections.Generic;
    
    public class BookCategory
    {
        public BookCategory()
        {
            this.Books = new HashSet<Book>();
        }
    
        public int Id { get; set; }
        public string NameE { get; set; }
        public string NameB { get; set; }
        public int IsActive { get; set; }
        public int Creator { get; set; }
        public System.DateTime CreationDate { get; set; }
        public int Modifier { get; set; }
        public System.DateTime ModificationDate { get; set; }
        public string Remarks { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
