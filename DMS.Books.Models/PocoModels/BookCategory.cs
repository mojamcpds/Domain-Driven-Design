
using System.ComponentModel.DataAnnotations.Schema;
using DMS.SharedKernel.Infrastructure.Domain;

namespace DMS.Books.Models.PocoModels
{
    using System;
    using System.Collections.Generic;

    [Table("BookCategory")]
    public class BookCategory : Entity<int>, IAggregateRoot
    {
        public BookCategory()
        {
       
            this.Books = new HashSet<Book>();
        }
    
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
