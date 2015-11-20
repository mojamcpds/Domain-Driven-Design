using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Books.Repositories
{
    public class BookUnitOfWork : IBookUnitOfWork
    {
        private readonly IBookDbContext _context;

        public BookUnitOfWork()
        {
            _context = new BookDbContext();
        }

        public BookUnitOfWork(IBookDbContext context)
        {
            _context = context;
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public IBookDbContext Context
        {
            get { return _context; }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
