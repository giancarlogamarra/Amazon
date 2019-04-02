using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Amazon.Models;
using Amazon.Models.Extensions;

namespace Amazon.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            BookRepository.FillBooks();
            return View("Index");
        }

        [HttpGet]
        public ViewResult RegBookForm() {
            return View();
        }

        [HttpPost]
        public ViewResult RegBookForm(Book book)
        {
            if (ModelState.IsValid)
            {
                BookRepository.AddResponse(book);
                return View("Thanks", book);
            }
            else
            {
                // Hay un error de validacion y retornamos una vista en blanco. 
                return View();
            }
        } 

        [HttpGet]
        public ViewResult ListResponses()
        {
            IEnumerable<Book> books = BookRepository.FilterBookByPagesRatherThan(250);
            decimal TotalPrice = books.TotalPriceExtension();
            ViewBag.TotalPrice = TotalPrice;
            return View(books);
        }
    }
}


