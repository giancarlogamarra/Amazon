using Amazon.Models;
using Amazon.Models.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Amazon.Controllers
{
    public class HomeController : Controller
    {
        public IRepository repository = Repository.SharedRepository;
        public ViewResult Index()
        {
            return View("Index", repository.Books.FilterByNroPagesGreaterThan(300).ToList());
        }

        [HttpGet]
        public ViewResult RegBookForm() {
            return View();
        }

        [HttpPost]
        public ViewResult RegBookForm(BookResponse bookResponse)
        {
            if (ModelState.IsValid)
            {
                repository.AddBook(bookResponse);
                return View("Thanks", bookResponse);
            }
            else {
                // Hay un error de validacion y retornamos una vista en blanco. 
                return View();
            }
        }

        [HttpGet]
        public ViewResult ListResponses()
        {
            IEnumerable<BookResponse> responses = repository.Books.FilterByNroPagesGreaterThan(0);
            decimal TotalPrice = responses.TotalPriceExtension();
            ViewBag.TotalPrice = TotalPrice;
            return View(responses);
        }
    }
}


