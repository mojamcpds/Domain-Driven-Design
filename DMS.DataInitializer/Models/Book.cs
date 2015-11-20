namespace DMS.DataInitializer.Models
{
    public class Book
    {
        public Book()
        {
        }
    
        public int Id { get; set; }
        public string TitleE { get; set; }
        public string TitleB { get; set; }
        public int BookCategoryId { get; set; }
        public virtual BookCategory BookCategory { get; set; }
        public int TotalPage { get; set; }
        public byte[] CoverPage { get; set; }
        public decimal Price { get; set; }
        public System.DateTime PublishedDate { get; set; }
        public string Description { get; set; }
        public int IsActive { get; set; }
        public int Creator { get; set; }
        public System.DateTime CreationDate { get; set; }
        public int Modifier { get; set; }
        public System.DateTime ModificationDate { get; set; }
        public string Remarks { get; set; }
        public string IsbnNumber { get; set; }
    
        
        
    }
}
