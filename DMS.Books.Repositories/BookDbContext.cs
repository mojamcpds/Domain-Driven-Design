using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Security.Policy;
using DMS.Books.Models.PocoModels;
using DMS.SharedKernel.Infrastructure.Data;
using DMS.SharedKernel.Infrastructure.Domain;

namespace DMS.Books.Repositories
{
    public class BookDbContext : BaseDbContext<BookDbContext>, IBookDbContext
    {

        public BookDbContext()
        {

        }

        public IDbSet<BookCategory> BookCategories { get; set; }
        public IDbSet<Book> Books { get; set; }

        public void SetModified<T, TId>(T entity) where T : Entity<TId>, IAggregateRoot
        {
            Entry(entity).State = EntityState.Modified;
        }

        public void SetAdd<T, TId>(T entity) where T : Entity<TId>, IAggregateRoot
        {
            Entry(entity).State = EntityState.Added;
        }

        public IDbSet<T> DbSet<T,TId>() where T:Entity<TId>,IAggregateRoot
        {
            return Set<T>();
        }

        public IEnumerable<TClass> ExecuteQuery<TClass>(string query) where TClass : class, new()
        {
            return Database.SqlQuery<TClass>(query);
        }

        public void ExecuteCommand(string query, params object[] parameters)
        {
            Database.ExecuteSqlCommand(query, parameters);
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           // modelBuilder.Conventions.Add<PluralizingEntitySetNameConvention>();
            modelBuilder.Entity<Book>()
                    .HasRequired(m => m.BookCategory)
                    .WithMany(t => t.Books)
                    .HasForeignKey(m => m.BookCategoryId)
                    .WillCascadeOnDelete(true);

            //base.OnModelCreating(modelBuilder);

          
        }


      
    }
}
