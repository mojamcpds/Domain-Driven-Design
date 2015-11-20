using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DMS.Books.Services.Messaging;
using DMS.Books.Services.Viewmodels;

namespace DMS.Books.Services.Interfaces
{
    public interface IBookFacade
    {
        HomePageResponse GetHomePageBooks(HomePageRequest request);
        BookSummaryResponse GetBookSummaries(BookSummaryRequest request);
        CategoryResponse GetAllSubjects();
        GetAllBookResponse GetAllBooks();
        ResponseBase SaveBook(CreateBookRequest request);
        ResponseBase UpdateBook(CreateBookRequest request);
        ResponseBase DeleteBook(DeleteBookRequest request);
    }
}
