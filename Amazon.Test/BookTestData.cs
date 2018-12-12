using Amazon.Models;
using System.Collections;
using System.Collections.Generic;

namespace Amazon.Test
{
    public class BookTestData : IEnumerable<BookResponse[]>
    {
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new BookResponse[] { GetNroPagesUnder300() };
            yield return new BookResponse[] { GetNroPagesOver300 };
        }
        
        //METODO
        private IEnumerable<BookResponse> GetNroPagesUnder300()
        {
            List<BookResponse> ListBooks = new List<BookResponse>();
            int[] nroPages = new int[] { 250, 180, 250, 290 };
            for (int i = 0; i < nroPages.Length; i++)
            {
                ListBooks.Add(new BookResponse
                {
                    Title = $"P{i + 1}",
                    NroPages = nroPages[i]
                });
            }
            return ListBooks.ToArray();
        }
        //PROPIEDAD
        private IEnumerable<BookResponse> GetNroPagesOver300 => new List<BookResponse> {
        new BookResponse { Title = "P1", NroPages = 320 },
        new BookResponse { Title = "P2", NroPages = 310},
        new BookResponse { Title = "P3", NroPages = 400},
        new BookResponse { Title = "P4", NroPages = 500}};
    }
}

