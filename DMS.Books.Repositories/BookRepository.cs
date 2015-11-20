using System;
using System.Collections.Generic;
using DMS.Books.Models.PocoModels;

namespace DMS.Books.Repositories
{
    public class BookRepository:BaseBookRepository<Book,int>,IBookRepository
    {
        public BookRepository(IBookUnitOfWork unitOfWork) 
            : base(unitOfWork)
        {
            
        }
        
       
    }
}
