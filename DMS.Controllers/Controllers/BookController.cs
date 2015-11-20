using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using DMS.Books.Services.Interfaces;

namespace DMS.Controllers.Controllers
{
    public class BookController:Controller
    {
        private readonly IBookFacade _bookFacade;

        public BookController(IBookFacade bookFacade)
        {
            _bookFacade = bookFacade;
        }

        public ActionResult Index()
        {
            var books = _bookFacade.GetAllBooks();
            return View(books);
        }
    }
}
