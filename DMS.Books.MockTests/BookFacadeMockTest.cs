using System;
using DMS.Books.Repositories;
using DMS.Books.Services.Implementations;
using DMS.Books.Services.Interfaces;
using DMS.Books.Services.Messaging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DMS.Books.MockTests
{
    [TestClass]
    public class BookFacadeMockTest
    {
        [TestMethod]
        public void Book_Save_Testing()
        {
            var context = new Mock<IBookDbContext>();
            var bookUnitOfWork = new BookUnitOfWork(context.Object);
            var bookRepository = new Mock<IBookRepository>();
            var categoryRepository = new Mock<ICategoryRepository>();
            var facade = new BookFacade(bookRepository.Object, categoryRepository.Object, bookUnitOfWork);
            //var createRequest = new Mock<CreateBookRequest>();
            //createRequest.Object.Create.Id = 0;
            //createRequest.Object.Create.IsActive = 1;
            //createRequest.Object.Create.IsbnNumber = "12345";
            //createRequest.Object.Create.Price = 566;
            //createRequest.Object.Create.PublishedDate = DateTime.Now;
            //createRequest.Object.Create.Remarks = "Remarks";
            //createRequest.Object.Create.TitleB = "Book Bengali";
            //createRequest.Object.Create.TitleE = "Book English";
            //createRequest.Object.Create.TotalPage = 150;
            //createRequest.Object.Create.BookCategoryId = 1;
            //createRequest.Object.Create.Description = "desc";

            var createRequest = new CreateBookRequest
            {
                Create =
                {
                    Id = 0,
                    IsActive = 1,
                    IsbnNumber = "12345",
                    Price = 566,
                    PublishedDate = DateTime.Now,
                    Remarks = "Remarks",
                    TitleB = "Book Bengali",
                    TitleE = "Book English",
                    TotalPage = 150,
                    BookCategoryId = 1,
                    Description = "desc"
                }
            };
            facade.SaveBook(createRequest);

        }

        [TestMethod]
        public void Book_Update_Testing()
        {
            var facade = new Mock<IBookFacade>();

            var createRequest = new CreateBookRequest
            {
                Create =
                {
                    Id = 0,
                    IsActive = 1,
                    IsbnNumber = "12345",
                    Price = 566,
                    PublishedDate = DateTime.Now,
                    Remarks = "Remarks",
                    TitleB = "Book Bengali",
                    TitleE = "Book English",
                    TotalPage = 150,
                    BookCategoryId = 1,
                    Description = "desc"
                }
            };

            var success = new ResponseBase {TransactionMessage = "Data Modified Successfully", TransactionStatus = true};

            facade.Setup(x=>x.UpdateBook(createRequest)).Returns(success);

        }
    }


}
