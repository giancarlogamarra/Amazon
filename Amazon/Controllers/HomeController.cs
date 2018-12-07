using Amazon.Models;
using Amazon.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
namespace Amazon.Controllers
{
    public class HomeController : Controller
    {
        private IBookRepository repository;
        public int PageSize = 4;
        public HomeController(IBookRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index(int bookPage = 1)
        {
           var bookListViewModel = new BooksListViewModel
            {
                Books = repository.Books
               .OrderBy(p => p.Price)
               .Skip((bookPage - 1) * PageSize)
               .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = bookPage,
                    ItemsPerPage = PageSize,
                    TotalItems = repository.Books.Count()
                }
            };
           return View(bookListViewModel);
        }
    }
}


