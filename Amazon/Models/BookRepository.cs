
using System.Collections.Generic;

namespace Amazon.Models
{
    public class BookRepository
    {
        private static List<Book> books = new List<Book>();
        public static IEnumerable<Book> Books {
            get {
                return books;
                }
        }

        public static void AddResponse(Book response) {
            books.Add(response);
        }
    }
}
