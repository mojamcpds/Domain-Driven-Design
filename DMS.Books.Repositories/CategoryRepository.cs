using System;
using System.Collections.Generic;
using DMS.Books.Models.PocoModels;

namespace DMS.Books.Repositories
{
    public class CategoryRepository:BaseBookRepository<BookCategory,int>,ICategoryRepository
    {
        public CategoryRepository(IBookUnitOfWork unitOfWork) 
            : base(unitOfWork)
        {
            
        }


    }
}
