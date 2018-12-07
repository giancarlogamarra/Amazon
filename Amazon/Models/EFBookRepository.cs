using System.Linq;

namespace Amazon.Models
{
    public class EFBookRepository : IBookRepository
    {
        private ApplicationDbContext context;
        public EFBookRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Book> Books => context.Books;
    }
}
