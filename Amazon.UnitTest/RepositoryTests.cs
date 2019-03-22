using Amazon.Models;
using System;
using Xunit;
using System.Linq;
namespace Amazon.UnitTest
{
    public class RepositoryTests
    {

        [Fact]
        public void NewBook_ShouldBeAdded()
        {
            //Arrange
            Book newBook = new Book() {
                Title = "Title 1",Author ="Author1",ISBN ="ISBN1",NroPages =200, Price = 100
            };
            //Act
            Repository.AddResponse(newBook);
            //Assert
            Assert.Equal("Title 1", Repository.Books.FirstOrDefault().Title);
        }
    }
}
