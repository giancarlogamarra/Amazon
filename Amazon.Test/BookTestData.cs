using Amazon.Models;
using System.Collections;
using System.Collections.Generic;

namespace Amazon.Test
{
    public class BookTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { GetNroPagesUnder300() };
            yield return new object[] { GetNroPagesOver300 };
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        //METODO
        private IEnumerable<BookResponse> GetNroPagesUnder300()
        {

            int[] nroPages = new int[] { 250, 180, 250, 290 };
            for (int i = 0; i < nroPages.Length; i++)
            {
                yield return new BookResponse
                {
                    Title = $"P{i + 1}",
                    NroPages = nroPages[i]
                };
            }
        }
        //PROPIEDAD
        private IEnumerable<BookResponse> GetNroPagesOver300 => new List<BookResponse> {
        new BookResponse { Title = "P1", NroPages = 320 },
        new BookResponse { Title = "P2", NroPages = 310},
        new BookResponse { Title = "P3", NroPages = 400},
        new BookResponse { Title = "P4", NroPages = 500}};
    }
}

