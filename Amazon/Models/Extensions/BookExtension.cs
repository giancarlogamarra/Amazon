using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amazon.Models.Extensions
{
    public static class BookExtension
    {
        public static decimal TotalPriceExtension(this IEnumerable<BookResponse> books)
        {
            return books.Sum(b => b?.Price ?? 0);
        }

        public static IEnumerable<BookResponse> FilterByNroPagesGreaterThan(this IEnumerable<BookResponse> books, int nroPages)
        {
            return books.Where(b => b != null && b.NroPages > nroPages);
        }
    }
}
