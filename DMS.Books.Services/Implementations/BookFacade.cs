using System;
using System.Collections.Generic;
using System.Linq;
using DMS.Books.Models.PocoModels;
using DMS.Books.Repositories;
using DMS.Books.Services.Exceptions;
using DMS.Books.Services.Interfaces;
using DMS.Books.Services.Messaging;
using DMS.Books.Services.Viewmodels;
using DMS.SharedKernel.Infrastructure.Domain;
using DMS.SharedKernel.Infrastructure.Logging;

namespace DMS.Books.Services.Implementations
{
    public class BookFacade:IBookFacade
    {

        private  readonly IBookRepository _bookRepository;
        private readonly ICategoryRepository _category;
        private readonly IBookUnitOfWork _bookUnitOfWork;
        

        public BookFacade(IBookRepository bookRepository, ICategoryRepository category, IBookUnitOfWork bookUnitOfWork)
        {
            _bookRepository = bookRepository;
            _category = category;
            _bookUnitOfWork = bookUnitOfWork;
        }


        private IEnumerable<BookSummaryView> GetTopRecent(int take)
        {
            return _bookRepository.GetAll().Where(x => x.IsActive == 1)
                    .OrderByDescending(x => x.Id)
                    .Take(take)
                    .Select(b => new BookSummaryView
                    {
                        Id = b.Id,
                        TitleBengali = b.TitleB,
                        TitleEnglish = b.TitleE,
                        PriceBdt = b.Price
                    });
        }

        private IEnumerable<BookSummaryView> GetTopDownloaded(int take)
        {
            var query = _bookRepository.GetAll().Where(x => x.IsActive == 1).Select(b => new
            {
                Id = b.Id,
                TitleBengali = b.TitleB,
                TitleEnglish = b.TitleE,
                PriceBdt = b.Price

            });

            return query.OrderByDescending(x => x.PriceBdt).Take(take).Select(b => new BookSummaryView
            {
                Id = b.Id,
                TitleBengali = b.TitleBengali,
                TitleEnglish = b.TitleEnglish,
                PriceBdt = b.PriceBdt

            });
        }

        private IEnumerable<BookSummaryView> GetTopRated(int take)
        {
            return _bookRepository.GetAll().Where(x => x.IsActive == 1).Take(take).Select(b => new BookSummaryView
            {
                Id = b.Id,
                TitleBengali = b.TitleB,
                TitleEnglish = b.TitleE,
                PriceBdt = b.Price
            }).OrderByDescending(y => y.PriceBdt);

        }



        /// <summary>
        /// Get books for Home page
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public HomePageResponse GetHomePageBooks(HomePageRequest request)
        {
            HomePageResponse response = new HomePageResponse();
            response.TopRecent = this.GetTopRecent(request.TakeBook);
            response.TopDownloaded = this.GetTopDownloaded(request.TakeBook);
            response.TopRated = this.GetTopRated(request.TakeBook);
            return response;
        }

        /// <summary>
        /// Get All books order by published date descending
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public BookSummaryResponse GetBookSummaries(BookSummaryRequest request)
        {

            BookSummaryResponse response = new BookSummaryResponse();

            response.BookSummaries = _bookRepository.GetAll().Where(x => x.IsActive == 1)
                .OrderByDescending(x => x.Id)
                .Select(b => new BookSummaryView
                {
                    Id = b.Id,
                    TitleBengali = b.TitleB,
                    TitleEnglish = b.TitleE,
                    PriceBdt = b.Price
                });


            var bookSummaryViews = response.BookSummaries as BookSummaryView[] ?? response.BookSummaries.ToArray();
            response.IniatialCharacters =
                bookSummaryViews.Select(summary => summary.TitleBengali.ToArray()[0].ToString()).ToList();

            response.Count = bookSummaryViews.Count();

            if (!string.IsNullOrEmpty(request.SearchString))
                bookSummaryViews = bookSummaryViews.Where(x => x.TitleBengali.StartsWith(request.SearchString)).ToArray();

            response.BookSummaries = bookSummaryViews.Skip(request.Skip).Take(request.Take);

            return response;

        }

        /// <summary>
        /// Get All Subjects
        /// </summary>
        /// <returns></returns>
        public CategoryResponse GetAllSubjects()
        {
            CategoryResponse response = new CategoryResponse
            {
                Categories = 
                    _category.GetAll()
                        .Where(x => x.IsActive == 1)
                        .OrderBy(y => y.NameB)
                        .Select(b => new BookCategoryView
                        {
                            Id = b.Id,
                            CategoryNameBengali = b.NameB,
                            CategoryNameEnglish = b.NameE
                        })
            };


            return response;
        }



        public GetAllBookResponse GetAllBooks()
        {
            var bookDetailsView = _bookRepository.GetAll().Select(x=>new BookDetailsView
            {
                Id = x.Id,
                BookNameBengali = x.TitleB,
                BookNameEnglish = x.TitleE,
                CategoryNameBengali = x.BookCategory.NameB,
                CategoryNameEnglish = x.BookCategory.NameE,
                CategoryId = x.BookCategoryId,
                Price = x.Price
            });

            var response = new GetAllBookResponse {BookDetails = bookDetailsView};
            return response;
        }

        public ResponseBase SaveBook(CreateBookRequest request)
        {
            var response = new ResponseBase();

            try
            {
                var book = new Book
                {
                    BookCategoryId = request.Create.BookCategoryId,
                    CoverPage = request.Create.CoverPage,
                    CreationDate = DateTime.Now,
                    Description = request.Create.Description,
                    IsActive = request.Create.IsActive,
                    IsbnNumber = request.Create.IsbnNumber,
                    Price = request.Create.Price,
                    PublishedDate = request.Create.PublishedDate,
                    Remarks = request.Create.Remarks,
                    TitleB = request.Create.TitleB,
                    TitleE = request.Create.TitleE,
                    TotalPage = request.Create.TotalPage
                };

                _bookRepository.Save(book);
                _bookUnitOfWork.Commit();

                response.TransactionMessage = "Data Saved Successfully";
                response.TransactionStatus = true;
            }
            catch (InvalidBookException ex)
            {
                response.TransactionMessage = "Failed To Save Data";
                response.TransactionStatus = false;
                LoggingFactory.GetLogger().Log(ex.Message.ToString());
            }

            return response;
        }

        public ResponseBase UpdateBook(CreateBookRequest request)
        {
            var response = new ResponseBase();

            try
            {
                var book = _bookRepository.GetById(request.Create.Id);
                book.BookCategoryId = request.Create.BookCategoryId;
                book.CoverPage = request.Create.CoverPage;
                book.CreationDate = DateTime.Now;
                book.Description = request.Create.Description;
                book.IsActive = request.Create.IsActive;
                book.IsbnNumber = request.Create.IsbnNumber;
                book.Price = request.Create.Price;
                book.PublishedDate = request.Create.PublishedDate;
                book.Remarks = request.Create.Remarks;
                book.TitleB = request.Create.TitleB;
                book.TitleE = request.Create.TitleE;
                book.TotalPage = request.Create.TotalPage;

                _bookRepository.Update(book);
                _bookUnitOfWork.Commit();

                response.TransactionMessage = "Data Updated Successfully";
                response.TransactionStatus = true;
            }
            catch (InvalidBookException ex)
            {
                response.TransactionMessage = "Failed to Update Data";
                response.TransactionStatus = false;
                LoggingFactory.GetLogger().Log(ex.Message.ToString());
            }

            return response;

        }

        public ResponseBase DeleteBook(DeleteBookRequest request)
        {
            var response = new ResponseBase();

            try
            {
                var book = _bookRepository.GetById(request.Id);
                _bookRepository.Delete(book);
                _bookUnitOfWork.Commit();

                response.TransactionMessage = "Book deleted Successfully";
                response.TransactionStatus = true;

            }
            catch (InvalidBookException ex)
            {
                response.TransactionMessage = "Book deletion failed";
                response.TransactionStatus = false;
                LoggingFactory.GetLogger().Log(ex.Message.ToString());
            }

            return response;
        }

    }
}
