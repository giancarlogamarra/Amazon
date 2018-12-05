using Amazon.Controllers;
using Amazon.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Xunit;

namespace Amazon.Test
{
    public class IndexControllerTests
    {
            class ModelCompleteFakeRepository : IRepository
            {
                public IEnumerable<BookResponse> Books => new List<BookResponse>{
                new BookResponse(){ Title ="Book1", Price=200,NroPages= 250},
                new BookResponse(){ Title ="Book2", Price=300,NroPages= 180},
                new BookResponse(){ Title ="Book3", Price=150,NroPages= 350},
                new BookResponse(){ Title ="Book4", Price=300,NroPages= 400}};

                public void AddBook(BookResponse p)
                {
                    //no requeridp para el test
                }

                public IEnumerable<BookResponse> FilterByNroPagesGreaterThan(int nroPages)
                {
                    return null;
                    //no requerido para el test
                }

                public decimal SumTotalPrice(int nroPages)
                {
                    return 0;
                    //no requerido para el test
                }
            }

            [Fact]
            public void IndexActionModelIsComplete()
            {
                // Arrange
                var controller = new HomeController();
                controller.repository = new ModelCompleteFakeRepository();
                // Act
                var model = (controller.Index() as ViewResult)?.ViewData.Model
                as IEnumerable<BookResponse>;
                // Assert
                Assert.Equal((controller.repository.Books as List<BookResponse>).Count,
                    (model as List<BookResponse>).Count);
            }

            class ModelCompleteFakeRepositoryPagesGreaterThan300 : IRepository
            {
                public IEnumerable<BookResponse> Books => new List<BookResponse>{
            new BookResponse(){ Title ="Book1", Price=200,NroPages= 320},
            new BookResponse(){ Title ="Book2", Price=280,NroPages= 310},
            new BookResponse(){ Title ="Book3", Price=150,NroPages= 500},
            new BookResponse(){ Title ="Book4", Price=300,NroPages= 800}};

                public void AddBook(BookResponse p)
                { }
            }

            [Fact]
            public void IndexActionModelIsCompletePagesGreaterThan300()
            {
                // Arrange
                var controller = new HomeController();
                controller.repository = new ModelCompleteFakeRepositoryPagesGreaterThan300();
                // Act
                var model = (controller.Index() as ViewResult)?.ViewData.Model
                as IEnumerable<BookResponse>;
                // Assert
                Assert.Equal((controller.repository.Books as List<BookResponse>).Count,
                    (model as List<BookResponse>).Count);
            }

       }
 }
