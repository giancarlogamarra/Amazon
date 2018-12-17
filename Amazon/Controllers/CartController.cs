using Amazon.Infrastructure;
using Amazon.Models;
using Amazon.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
 
namespace Amazon.Controllers
{
    public class CartController : Controller
    {
        private IBookRepository repository;
        public CartController(IBookRepository repo)
        {
            repository = repo;
        }
        public ViewResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = GetCart(),
                ReturnUrl = returnUrl
            });
        }
        public RedirectToActionResult AddToCart(Guid bookId, string returnUrl)
        {
            Book book = repository.Books
            .FirstOrDefault(p => p.BookId == bookId);
            if (book != null)
            {
                Cart cart = GetCart();
                cart.AddItem(book, 1);
                SaveCart(cart);
            }
            return RedirectToAction("Index", new
            {
                returnUrl
            });
        }
        public RedirectToActionResult RemoveFromCart(Guid bookId,string returnUrl)
        {
            Book book = repository.Books
            .FirstOrDefault(p => p.BookId == bookId);
            if (book != null)
            {
                Cart cart = GetCart();
                cart.RemoveLine(book);
                SaveCart(cart);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        private Cart GetCart()
        {
            Cart cart = HttpContext.Session.GetJson<Cart>("Cart") ?? new Cart();
            return cart;
        }
        private void SaveCart(Cart cart)
        {
            HttpContext.Session.SetJson("Cart", cart);
        }
    }
}
