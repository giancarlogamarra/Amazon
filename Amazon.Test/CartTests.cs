using Amazon.Models;
using System;
using System.Linq;
using Xunit;

namespace Amazon.Test
{
    public class CartTests
    {
        [Fact]
        public void Can_Add_New_Lines()
        {
            // Arrange - create some test books
            Book b1 = new Book { BookId = Guid.NewGuid(), Title = "B1" };
            Book b2 = new Book { BookId = Guid.NewGuid(), Title = "B2" };
            // Arrange - create a new cart
            Cart target = new Cart();
            // Act
            target.AddItem(b1, 1);
            target.AddItem(b2, 1);
            CartLine[] results = target.Lines.ToArray();
            // Assert
            Assert.Equal(2, results.Length);
            Assert.Equal(b1, results[0].Book);
            Assert.Equal(b2, results[1].Book);
        }

        [Fact]
        public void Can_Add_Quantity_For_Existing_Lines()
        {
            // Arrange - create some test products
            Book b1 = new Book { BookId = Guid.NewGuid(), Title = "B1" };
            Book b2 = new Book { BookId = Guid.NewGuid(), Title = "B2" };
            // Arrange - create a new cart
            Cart target = new Cart();
            // Act
            target.AddItem(b1, 1);
            target.AddItem(b2, 1);
            target.AddItem(b1, 10);
            CartLine[] results = target.Lines
            .OrderBy(c => c.Book.BookId).ToArray();
            // Assert
            Assert.Equal(2, results.Length);
            Assert.Equal(11, results[0].Quantity);
            Assert.Equal(1, results[1].Quantity);
        }

        [Fact]
        public void Can_Remove_Line()
        {
            // Arrange - create some test products
            Book b1 = new Book { BookId = Guid.NewGuid(), Title = "T1" };
            Book b2 = new Book { BookId = Guid.NewGuid(), Title = "T2" };
            Book b3 = new Book { BookId = Guid.NewGuid(), Title = "T3" };
            // Arrange - create a new cart
            Cart target = new Cart();
            // Arrange - add some products to the cart
            target.AddItem(b1, 1);
            target.AddItem(b2, 3);
            target.AddItem(b3, 5);
            target.AddItem(b2, 1);
            // Act
            target.RemoveLine(b2);
            // Assert
            Assert.Empty(target.Lines.Where(c => c.Book == b2));
            Assert.Equal(2, target.Lines.Count());
        }

        [Fact]
        public void Calculate_Cart_Total()
        {
            // Arrange - create some test books
            Book b1 = new Book { BookId = Guid.NewGuid(), Title = "B1", Price = 100 };
            Book b2 = new Book { BookId = Guid.NewGuid(), Title = "B2", Price = 50 };
            // Arrange - create a new cart
            Cart target = new Cart();
            // Act
            target.AddItem(b1, 1);
            target.AddItem(b2, 1);
            target.AddItem(b1, 3);
            decimal? result = target.ComputeTotalValue();
            // Assert
            Assert.Equal(450, result);
        }

        [Fact]
        public void Can_Clear_Contents()
        {
            // Arrange - create some test products
            Book b1 = new Book { BookId = Guid.NewGuid(), Title = "T1", Price = 100 };
            Book b2 = new Book { BookId = Guid.NewGuid(), Title = "T2", Price = 50 };
            // Arrange - create a new cart
            Cart target = new Cart();
            // Arrange - add some items
            target.AddItem(b1, 1);
            target.AddItem(b2, 1);
            // Act - reset the cart
            target.Clear();
            // Assert
            Assert.Equal(0, target.Lines.Count());
        }
 
    }
}
