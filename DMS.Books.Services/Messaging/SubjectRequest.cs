namespace DMS.Books.Services.Messaging
{
    public class SubjectRequest
    {
        public int Take { get; set; }
        public int Skip { get; set; }
        public string SearchString { get; set; }
    }
}
