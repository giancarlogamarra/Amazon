using System.Collections.Generic;
using System.Linq;

namespace Amazon.Models
{
    public interface IBookRepository
    {
        IQueryable<Book> Books { get; }
    }
}
