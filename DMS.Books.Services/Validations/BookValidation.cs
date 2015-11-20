using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DMS.Books.Models.PocoModels;
using DMS.SharedKernel.Infrastructure.Domain;

namespace DMS.Books.Services.Validations
{
    public class BookValidation
    {
        public static void BookValidationLogic(Book book)
        {
            Guard.ForNullOrEmpty(book.TitleB, "Bengali Name");
            Guard.ForNullOrEmpty(book.TitleE, "English Name");
            Guard.ForLessEqualZero(book.BookCategoryId,"Category");
            Guard.ForLessEqualZeroDecimal(book.Price, "Price");
        }
    }
}
