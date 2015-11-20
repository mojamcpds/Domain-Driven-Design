using System.Data.Entity;
using System.Security.Policy;
using DMS.Books.Models.PocoModels;
using DMS.SharedKernel.Infrastructure.Data;

namespace DMS.Books.Repositories
{
    public interface IBookDbContext:IDbContext
    {
        IDbSet<BookCategory> BookCategories { get; set; }
        IDbSet<Book> Books { get; set; }
    }
}
