using System;
using System.Data.Entity;
using DMS.Books.Models.PocoModels;
using DMS.Books.Repositories;
using DMS.SharedKernel.Infrastructure.Domain;

namespace DMS.Books.Fakes
{
    public class FakeBookContext:IBookDbContext
    {
        public FakeBookContext()
        {
            Books = new FakeBookDbSet();
            BookCategories=new FakeCategoryDbSet();
        }

        public IDbSet<BookCategory> BookCategories { get; set; }
        
        public IDbSet<Book> Books { get; set; }
        public void SetModified<T, TId>(T entity) where T : Entity<TId>, IAggregateRoot
        {
            throw new NotImplementedException();
        }

        public void SetAdd<T, TId>(T entity) where T : Entity<TId>, IAggregateRoot
        {
            throw new NotImplementedException();
        }

        public System.Collections.Generic.IEnumerable<TClass> ExecuteQuery<TClass>(string query) where TClass : class, new()
        {
            throw new NotImplementedException();
        }

        public void ExecuteCommand(string query, params object[] parameters)
        {
            throw new NotImplementedException();
        }
        public IDbSet<T> DbSet<T, TId>() where T : Entity<TId>, IAggregateRoot
        {
            return (IDbSet<T>) Books;
        }

        public int SaveChanges()
        {
            return 0;
        }

        public void Dispose()
        {
        }


        
    }
}
