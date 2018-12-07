using Amazon.Models;
using Microsoft.AspNetCore.Mvc;

namespace Amazon.Controllers
{
    public class HomeController : Controller
    {
        private IBookRepository repository;
        public HomeController(IBookRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index() => View(repository.Books);
       
    }
}


