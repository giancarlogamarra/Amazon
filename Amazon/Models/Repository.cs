
using System.Collections.Generic;
using Amazon.Models.Extensions;
namespace Amazon.Models
{
    public class Repository : IRepository
    {
        private static Repository sharedRepository = new Repository();
        public static Repository SharedRepository => sharedRepository;
        public List<BookResponse> books = new List<BookResponse>();

        public Repository()
        {
            if (books.Count == 0)
            {
                BookResponse book1 = new BookResponse()
                {
                    ISBN = "123456789",
                    Author = "Giancarlo G",
                    NroPages = 210,
                    Price = 270,
                    Title = "How to Program ASP.NET MVC"
                };
                BookResponse book2 = new BookResponse()
                {
                    ISBN = "521648597",
                    Author = "Giancarlo G",
                    NroPages = 3200,
                    Price = 3000,
                    Title = "How to Program C#"
                };
                BookResponse book3 = new BookResponse()
                {
                    ISBN = "258456",
                    Author = "Giancarlo G",
                    NroPages = 500,
                    Price = 200,
                    Title = "How to Program Java",
                    LevelStock = LevelStock.SoldOut
                };

                books.Add(book1);
                books.Add(book2);
                books.Add(book3);
                books.Add(null);
            }
        }

        public IEnumerable<BookResponse> Books => books;
        public void AddBook(BookResponse b)
        {
            books.Add(b);
        }
    }

}
