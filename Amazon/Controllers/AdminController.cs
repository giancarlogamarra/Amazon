using Amazon.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Amazon.Controllers
{
    public class AdminController : Controller
    {
        private IBookRepository repository;
        public AdminController(IBookRepository repo)
        {
            repository = repo;
        }
        public ViewResult Index() => View(repository.Books);

        public ViewResult Edit(Guid bookId) =>
        View(repository.Books
        .FirstOrDefault(p => p.BookId == bookId));

        [HttpPost]
        public IActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                repository.SaveBook(book);
                TempData["message"] = $"{book.Title} has been saved";
                return RedirectToAction("Index");
            }
            else
            {
                // there is something wrong with the data values
                return View(book);
            }
        }

    }
}