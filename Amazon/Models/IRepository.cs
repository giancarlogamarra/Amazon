using System.Collections.Generic;

namespace Amazon.Models
{
    public interface IRepository
    {
        IEnumerable<BookResponse> Books { get; }
        void AddBook(BookResponse p);

    }
}
