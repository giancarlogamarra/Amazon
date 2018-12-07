using Amazon.Controllers;
using Amazon.Models;
using Amazon.Models.ViewModels;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Amazon.Test
{
    public class BookControllerTests
    {
        [Fact]
        public void Can_Send_Pagination_View_Model()
        {
            // Arrange
            Mock<IBookRepository> mock = new Mock<IBookRepository>();
            mock.Setup(m => m.Books).Returns((new Book[] {
            new Book {BookId = Guid.NewGuid(), Title = "B1", Author="GG",ISBN="21542", Price = 100},
            new Book {BookId = Guid.NewGuid(), Title = "B2", Author="GG",ISBN="43543", Price = 200},
            new Book {BookId = Guid.NewGuid(), Title = "B3", Author="GG",ISBN="65432", Price = 300},
            new Book {BookId = Guid.NewGuid(), Title = "B4", Author="GG",ISBN="76532", Price = 400},
            new Book {BookId = Guid.NewGuid(), Title = "B5", Author="GG",ISBN="76533", Price = 500},
            }).AsQueryable<Book>());
            // Arrange
            BookController controller =
            new BookController(mock.Object) { PageSize = 3 };
            // Act
            BooksListViewModel result = controller.List(2).ViewData.Model as BooksListViewModel;
            // Assert
            PagingInfo pageInfo = result.PagingInfo;
            Assert.Equal(2, pageInfo.CurrentPage);
            Assert.Equal(3, pageInfo.ItemsPerPage);
            Assert.Equal(5, pageInfo.TotalItems);
            Assert.Equal(2, pageInfo.TotalPages);
        }

        [Fact]
        public void Can_Paginate()
        {
            // Arrange
            Mock<IBookRepository> mock = new Mock<IBookRepository>();
            mock.Setup(m => m.Books).Returns((new Book[] {
            new Book {BookId = Guid.NewGuid(), Title = "B1", Author="GG",ISBN="21542", Price = 100},
            new Book {BookId = Guid.NewGuid(), Title = "B2", Author="GG",ISBN="43543", Price = 200},
            new Book {BookId = Guid.NewGuid(), Title = "B3", Author="GG",ISBN="65432", Price = 300},
            new Book {BookId = Guid.NewGuid(), Title = "B4", Author="GG",ISBN="76532", Price = 400},
            new Book {BookId = Guid.NewGuid(), Title = "B5", Author="GG",ISBN="76533", Price = 500},
            }).AsQueryable<Book>());
            BookController controller = new BookController(mock.Object);
            controller.PageSize = 3;
            // Act
            BooksListViewModel result = controller.List(2).ViewData.Model as BooksListViewModel; 
            // Assert
            Book[] bookArray = result.Books.ToArray();
            Assert.True(bookArray.Length == 2);
            Assert.Equal("B4", bookArray[0].Title);
            Assert.Equal("B5", bookArray[1].Title);
        }
    }
}
