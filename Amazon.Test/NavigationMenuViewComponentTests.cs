using Amazon.Components;
using Amazon.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Routing;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Amazon.Test
{
    public class NavigationMenuViewComponentTests
    {
        [Fact]
        public void Can_Select_Categories()
        {
            // Arrange
            Mock<IBookRepository> mock = new Mock<IBookRepository>();
            mock.Setup(m => m.Books).Returns((new Book[] {
            new Book {Title = "T1", Category = "Apples"},
            new Book {Title = "T2", Category = "Apples"},
            new Book {Title = "T3", Category = "Plums"},
            new Book {Title = "T4", Category = "Oranges"},
            }).AsQueryable<Book>());
            NavigationMenuViewComponent target =
            new NavigationMenuViewComponent(mock.Object);
            // Act = get the set of categories
            string[] results = ((IEnumerable<string>)(target.Invoke()
            as ViewViewComponentResult).ViewData.Model).ToArray();
            // Assert
            Assert.True(Enumerable.SequenceEqual(new string[] { "Apples","Oranges", "Plums" },
                results));
        }

        [Fact]
        public void Indicates_Selected_Category()
        {
            // Arrange
            string categoryToSelect = "Oranges";
            Mock<IBookRepository> mock = new Mock<IBookRepository>();
            mock.Setup(m => m.Books).Returns((new Book[] {
            new Book {Title = "T1", Category = "Apples"},
            new Book {Title = "T2", Category = "Oranges"},
             new Book{Title = "T3", Category = "Grapes"},
            }).AsQueryable<Book>());
            NavigationMenuViewComponent target =
            new NavigationMenuViewComponent(mock.Object);
            target.ViewComponentContext = new ViewComponentContext
            {
                ViewContext = new ViewContext
                {
                    RouteData = new RouteData()
                }
            };
            target.RouteData.Values["category"] = categoryToSelect;
            // Action
            string result = (string)(target.Invoke() as
            ViewViewComponentResult).ViewData["SelectedCategory"];
            // Assert
            Assert.Equal(categoryToSelect, result);
        }
    }

}
