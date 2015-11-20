using DMS.Books.Models.PocoModels;
using DMS.SharedKernel.Infrastructure.Data;

namespace DMS.Books.Repositories
{
    public interface ICategoryRepository : IRepository<BookCategory, int>
    {
    }
}
