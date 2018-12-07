using Amazon.Models;
using Microsoft.AspNetCore.Mvc;

namespace Amazon.Controllers
{
    public class BookController : Controller
    {
        private IBookRepository repository;
        public BookController(IBookRepository repo)
        {
            repository = repo;
        }

        public ViewResult List() => View(repository.Books);
       
    }
}


