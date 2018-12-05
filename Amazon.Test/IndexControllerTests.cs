using Amazon.Controllers;
using Amazon.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using Xunit;
namespace Amazon.Test
{
    public class IndexControllerTests
    {
       

        [Theory]
        [ClassData(typeof(BookTestData))]
        public void IndexActionModelIsComplete(IEnumerable<BookResponse> books)
        {
            // Arrange
            var mock = new Mock<IRepository>();
            mock.SetupGet(m => m.Books).Returns(books);
            var controller = new HomeController { repository = mock.Object };
            // Act
            var model = (controller.Index() as ViewResult)?.ViewData.Model
            as IEnumerable<BookResponse>;
            // Assert
            Assert.Equal(controller.repository.Books, model,
            Comparer.Get<BookResponse>((p1, p2) => p1.Title == p2.Title
            && p1.NroPages == p2.NroPages));
        }
    }
   
}
