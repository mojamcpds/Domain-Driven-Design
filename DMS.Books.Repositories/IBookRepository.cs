using DMS.Books.Models.PocoModels;
using DMS.SharedKernel.Infrastructure.Data;

namespace DMS.Books.Repositories
{
    public interface IBookRepository:IRepository<Book,int>
    {

    }
}
