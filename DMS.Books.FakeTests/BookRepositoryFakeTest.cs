using System;
using System.Collections.Generic;
using System.Linq;
using DMS.Books.Fakes;
using DMS.Books.Models.PocoModels;
using DMS.Books.Repositories;
using DMS.SharedKernel.Infrastructure.Querying;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DMS.Books.FakeTests
{
    [TestClass]
    public class BookRepositoryFakeTest
    {
        //Initialization
        private IBookDbContext _context;
        private IBookRepository _bookRepository;
        private IBookUnitOfWork _bookUnitOfWork;


        private void Setup()
        {
            _context = new FakeBookContext();

            _context.Books.Add(new Book
            {
                Id = 1,
                TitleB = "Bengali Book1",
                TitleE = "Englishi Book1",
                IsActive = 1,
                Price = 1,
                CreationDate = DateTime.Today,
                PublishedDate = DateTime.Today,
                
            });

            _context.Books.Add(new Book
            {
                Id = 2,
                TitleB = "Bengali Book2",
                TitleE = "Englishi Book2",
                IsActive = 1,
                Price = 1,
                CreationDate = DateTime.Today,
                PublishedDate = DateTime.Today,
            });

            _context.Books.Add(new Book
            {
                Id = 3,
                TitleB = "Bengali Book3",
                TitleE = "Englishi Book3",
                IsActive = 1,
                Price = 1,
                CreationDate = DateTime.Today,
                PublishedDate = DateTime.Today,
                
            });

            _bookUnitOfWork = new BookUnitOfWork(_context);
            _bookRepository = new BookRepository(_bookUnitOfWork);
        }


        [TestMethod]
        public void GetAll_Test()
        {
            //-- Arrange
            Setup();

            //-- Act
            var response = _bookRepository.GetAll();

            //-- Assert
            Assert.IsInstanceOfType(response, typeof(IEnumerable<Book>));

            var enumerable = response as Book[] ?? response.ToArray();
            Assert.IsTrue(enumerable.Any());
            Assert.AreEqual("Bengali Book1", enumerable.ElementAt(0).TitleB);
        }

        [TestMethod]
        public void GetById_Test()
        {
            Setup();
            const int id = 1;
            var response = _bookRepository.GetById(id);

            Assert.IsNotNull(response);
            Assert.IsInstanceOfType(response, typeof(Book));
            Assert.AreEqual("Bengali Book1", response.TitleB);

        }

        [TestMethod]
        public void Get_Test()
        {
            Setup();
            var where = PredicateBuilder.Create<Book>(x => x.Id == 1);
            var response = _bookRepository.Get(where);

            Assert.IsNotNull(response);
            Assert.IsInstanceOfType(response, typeof(Book));
            Assert.AreEqual("Bengali Book1", response.TitleB);

        }

        [TestMethod]
        public void GetMany_Test()
        {
            Setup();
            var where = PredicateBuilder.Create<Book>(x => x.Id == 1);
            var response = _bookRepository.Get(where);

            Assert.IsNotNull(response);
            Assert.IsInstanceOfType(response, typeof(Book));
            Assert.AreEqual("Bengali Book1", response.TitleB);
        }
    }
}
