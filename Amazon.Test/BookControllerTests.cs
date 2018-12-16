using Amazon.Controllers;
using Amazon.Models;
using Amazon.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
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
            BooksListViewModel result = controller.List(null,2).ViewData.Model as BooksListViewModel;
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
            BooksListViewModel result = controller.List(null, 2).ViewData.Model as BooksListViewModel; 
            // Assert
            Book[] bookArray = result.Books.ToArray();
            Assert.True(bookArray.Length == 2);
            Assert.Equal("B4", bookArray[0].Title);
            Assert.Equal("B5", bookArray[1].Title);
        }

        [Fact]
        public void Can_Filter_Products()
        {
            // Arrange
            // - create the mock repository
            Mock<IBookRepository> mock = new Mock<IBookRepository>();
            mock.Setup(m => m.Books).Returns((new Book[] {
            new Book {Title = "B1", Category = "Cat1"},
            new Book {Title = "B2", Category = "Cat2"},
            new Book {Title = "B3", Category = "Cat1"},
            new Book {Title = "B4", Category = "Cat2"},
            new Book {Title = "B5", Category = "Cat3"}
            }).AsQueryable<Book>());
            // Arrange - create a controller and make the page size 3 items
            BookController controller = new BookController(mock.Object);
            controller.PageSize = 3;
            // Action
            Book[] result =
            (controller.List("Cat2", 1).ViewData.Model as BooksListViewModel)
            .Books.ToArray();
            // Assert
            Assert.Equal(2, result.Length);
            Assert.True(result[0].Title == "B2" && result[0].Category == "Cat2");
            Assert.True(result[1].Title == "B4" && result[1].Category == "Cat2");
        }

        [Fact]
        public void Generate_Category_Specific_Product_Count()
        {
            // Arrange
            Mock<IBookRepository> mock = new Mock<IBookRepository>();
            mock.Setup(m => m.Books).Returns((new Book[] {
            new Book {Title = "B1", Category = "Cat1"},
            new Book {Title = "B2", Category = "Cat2"},
            new Book {Title = "B3", Category = "Cat1"},
            new Book {Title = "B4", Category = "Cat2"},
            new Book {Title = "B5", Category = "Cat3"}
            }).AsQueryable<Book>());
            BookController target = new BookController(mock.Object);
            target.PageSize = 3;
            
            // Action
            int? res1 = ((target.List("Cat1") as ViewResult).Model as BooksListViewModel).PagingInfo.TotalItems;
            int? res2 = ((target.List("Cat1") as ViewResult).Model as BooksListViewModel).PagingInfo.TotalItems;
            int? res3 = ((target.List("Cat1") as ViewResult).Model as BooksListViewModel).PagingInfo.TotalItems;
            int? resAll = ((target.List("Cat1") as ViewResult).Model as BooksListViewModel).PagingInfo.TotalItems;

            // Assert
            Assert.Equal(2, res1);
            Assert.Equal(2, res2);
            Assert.Equal(1, res3);
            Assert.Equal(5, resAll);
        }
    }
}
