using Amazon.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Amazon.Controllers
{
    [Authorize]
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

        [HttpPost]
        public IActionResult Delete(Guid bookId)
        {
            Book deletedBook = repository.DeleteBook(bookId);
            if (deletedBook != null)
            {
                TempData["message"] = $"{deletedBook.Title} was deleted";
            }
            return RedirectToAction("Index");
        }
        public ViewResult Create() {
            return View("Edit", new Book());
        }

    }
}