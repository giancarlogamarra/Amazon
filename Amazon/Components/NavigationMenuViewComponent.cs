using Amazon.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Amazon.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private IBookRepository repository;
        public NavigationMenuViewComponent(IBookRepository repo)
        {
            repository = repo;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            var result = repository.Books
            .Select(x => x.Category)
            .Distinct()
            .OrderBy(x => x);
            return View(result);
        }
    }
}
