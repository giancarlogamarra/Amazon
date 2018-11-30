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
            int hour = DateTime.Now.Hour;
            ViewBag.Greeting = hour < 12 ? "Goog Morning" : "Good Afternoon";
            Repository.FillBooks();
            return View("Index");
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
                Repository.AddResponse(bookResponse);
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
           
            IEnumerable<BookResponse> responses = Repository.FilterBookByPagesRatherThan(250);
            decimal TotalPrice = responses.TotalPriceExtension();
            ViewBag.TotalPrice = TotalPrice;
            return View(responses);
        }
    }
}


