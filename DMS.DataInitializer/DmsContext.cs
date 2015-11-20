using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DMS.DataInitializer.Models;

namespace DMS.DataInitializer
{
    public class DmsContext : DbContext
    {
        public DmsContext()
            : base("name=DmsContext")
        {
        }

        public DbSet<BookCategory> BookCategories { get; set; }
        public DbSet<Book> Books { get; set; }

        //Context Mapping
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            
            // Configure Id as PK 
            modelBuilder.Entity<BookCategory>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<Book>()
                .HasKey(e => e.Id);
            

            // Configure BookCategoryId as FK for Book
            modelBuilder.Entity<Book>()
            .HasRequired<BookCategory>(s => s.BookCategory)
            .WithMany(s => s.Books)
            .HasForeignKey(s => s.BookCategoryId)
            .WillCascadeOnDelete(true);

            base.OnModelCreating(modelBuilder);
        }
    }
}
