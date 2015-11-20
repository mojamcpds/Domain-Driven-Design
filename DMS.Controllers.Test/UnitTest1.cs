using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using DMS.Books.Services.Interfaces;
using DMS.Books.Services.Messaging;
using DMS.Books.Services.Viewmodels;
using DMS.Controllers.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DMS.Controllers.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var facade = new Mock<IBookFacade>();
            var books = new GetAllBookResponse();
            facade.Setup(x => x.GetAllBooks()).Returns(books);
            var controller = new BookController(facade.Object);
            
            
            var response = (ViewResult) controller.Index();
            
            facade.Verify();
            

        }
    }
}
