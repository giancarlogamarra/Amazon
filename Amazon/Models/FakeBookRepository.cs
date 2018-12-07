
using System.Collections.Generic;
using System.Linq;
using Amazon.Models.Extensions;
namespace Amazon.Models
{
    public class FakeBookRepository : IBookRepository
    {

        public IQueryable<Book> Books => new List<Book> {
            new Book {ISBN ="1231486",
                     Title = "Book1",
                     Price = 25 ,
                     Author ="GGamarra",
                     NroPages =200,
                     LevelStock =LevelStock.InStock },
            new Book {ISBN ="4356334",
                      Title = "Book2",
                      Price = 179,
                      Author ="GGamarra",
                      NroPages =300,
                      LevelStock =LevelStock.InStock},
            new Book {ISBN ="7658345",
                      Title = "Book3",
                      Price = 95 ,
                      Author ="GGamarra",
                      NroPages =400,
                      LevelStock =LevelStock.InStock}
            }.AsQueryable<Book>();

    
    }
}
