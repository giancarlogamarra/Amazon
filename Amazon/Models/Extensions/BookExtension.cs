using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amazon.Models.Extensions
{
    public static class BookExtension
    {
        public static decimal TotalPriceExtension(this IEnumerable<Book> books)
        {
            return books.Sum(b => b?.Price ?? 0);
        }

        public static IEnumerable<Book> FilterByNroPagesGreaterThan(this IEnumerable<Book> books, int nroPages)
        {
            return books.Where(b => b != null && b.NroPages > nroPages);
        }
    }
}
