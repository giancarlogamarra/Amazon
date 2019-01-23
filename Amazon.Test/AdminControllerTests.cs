using Amazon.Controllers;
using Amazon.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Amazon.Test
{
    public  class AdminControllerTests
    {
        [Fact]
        public void Index_Contains_All_Books()
        {
            // Arrange - create the mock repository
            Mock<IBookRepository> mock = new Mock<IBookRepository>();
            mock.Setup(m => m.Books).Returns(new Book[] {
                new Book {Title = "B1"},
                new Book {Title = "B2"},
                new Book {Title = "B3"},
                }.AsQueryable<Book>());
            // Arrange - create a controller
            AdminController target = new AdminController(mock.Object);
            // Action
            Book[] result = GetViewModel<IEnumerable<Book>>(target.Index())?.ToArray();
            // Assert
            Assert.Equal(3, result.Length);
            Assert.Equal("B1", result[0].Title);
            Assert.Equal("B2", result[1].Title);
            Assert.Equal("B3", result[2].Title);
        }
        [Fact]
        public void Can_Edit_Book()
        {
            Guid IDBook1 = Guid.NewGuid();
            Guid IDBook2 = Guid.NewGuid();
            Guid IDBook3 = Guid.NewGuid();
            // Arrange - create the mock repository
            Mock<IBookRepository> mock = new Mock<IBookRepository>();
            mock.Setup(m => m.Books).Returns(new Book[] {
            new Book {BookId = IDBook1, Title = "B1"},
            new Book {BookId = IDBook2, Title = "B2"},
            new Book {BookId = IDBook3, Title = "B3"},
            }.AsQueryable<Book>());
            // Arrange - create the controller
            AdminController target = new AdminController(mock.Object);
            // Act
            Book b1 = GetViewModel<Book>(target.Edit(IDBook1));
            Book b2 = GetViewModel<Book>(target.Edit(IDBook2));
            Book b3 = GetViewModel<Book>(target.Edit(IDBook3));
            // Assert
            Assert.Equal(IDBook1, b1.BookId);
            Assert.Equal(IDBook2, b2.BookId);
            Assert.Equal(IDBook3, b3.BookId);
        }

        [Fact]
        public void Cannot_Edit_Nonexistent_Book()
        {
            // Arrange - create the mock repository
            Mock<IBookRepository> mock = new Mock<IBookRepository>();
            mock.Setup(m => m.Books).Returns(new Book[] {
            new Book {BookId = Guid.NewGuid(), Title = "B1"},
            new Book {BookId = Guid.NewGuid(), Title = "B2"},
            new Book {BookId = Guid.NewGuid(), Title = "B3"},
            }.AsQueryable<Book>());
            // Arrange - create the controller
            AdminController target = new AdminController(mock.Object);
            // Act
            Book result = GetViewModel<Book>(target.Edit(Guid.NewGuid()));
            // Assert
            Assert.Null(result);
        }
        private T GetViewModel<T>(IActionResult result) where T : class
        {
            return (result as ViewResult)?.ViewData.Model as T;
        }
    }
}
