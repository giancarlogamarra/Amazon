
using System.Collections.Generic;
using Amazon.Models.Extensions;
namespace Amazon.Models
{
    public class Repository
    {
        public static List<BookResponse> responses = new List<BookResponse>();
        public static IEnumerable<BookResponse> Responses {
            get {
                return responses;
                }
        }

        public static void AddResponse(BookResponse response) {
            responses.Add(response);
        }

        public static List<BookResponse> FillBooks()
        {if (responses.Count == 0)
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

                responses.Add(book1);
                responses.Add(book2);
                responses.Add(book3);
                responses.Add(null);
            }
            return responses;
        }

        public static decimal TotalPrice() {
            return responses.TotalPriceExtension();
        }

        public static IEnumerable<BookResponse> FilterBookByPagesRatherThan(int nroPages)
        {
            return responses.FilterByNroPagesGreaterThan(nroPages);
        }
    }
}
