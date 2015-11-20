using System;
using System.ComponentModel.DataAnnotations.Schema;
using DMS.SharedKernel.Infrastructure.Domain;

namespace DMS.Books.Models.PocoModels
{
    [Table("Book")]
    public class Book:Entity<int>,IAggregateRoot
    {
        public Book()
        {
        }

        public string TitleE { get; set; }
        public string TitleB { get; set; }
        public int BookCategoryId { get; set; }
        public virtual BookCategory BookCategory { get; set; }
        public int TotalPage { get; set; }
        public byte[] CoverPage { get; set; }
        public decimal Price { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Description { get; set; }
        public int IsActive { get; set; }
        public int Creator { get; set; }
        public DateTime CreationDate { get; set; }
        public int Modifier { get; set; }
        public DateTime ModificationDate { get; set; }
        public string Remarks { get; set; }
        public string IsbnNumber { get; set; }
       
    }
}
