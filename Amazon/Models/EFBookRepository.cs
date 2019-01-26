using System;
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

        public void SaveBook(Book book)
        {
            if (book.BookId == Guid.Empty)
            {
                context.Books.Add(book);
            }
            else
            {
                Book dbEntry = context.Books
                .FirstOrDefault(p => p.BookId == book.BookId);
                if (dbEntry != null)
                {
                    dbEntry.Title = book.Title;
                    dbEntry.ISBN = book.ISBN;
                    dbEntry.Author = book.Author;
                    dbEntry.Price = book.Price;
                    dbEntry.Category = book.Category;
                    dbEntry.NroPages = book.NroPages;
                }
            }
            context.SaveChanges();
        }
        public Book DeleteBook(Guid bookID)
        {
            Book dbEntry = context.Books
            .FirstOrDefault(p => p.BookId == bookID);
            if (dbEntry != null )
            {
                context.Books.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
