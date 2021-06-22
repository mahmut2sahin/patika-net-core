using bookstore_api.Database;
using System;
using System.Linq;

namespace bookstore_api.Operations.BookOperations.DeleteBook
{
    public class DeleteBookService
    {
        private readonly BookStoreDbContext context;
        public int BookId { get; }

        public DeleteBookService(BookStoreDbContext context, int id)
        {
            this.context = context;
            this.BookId = id;
        }

        public void Handle()
        {
            var book = context.Books.FirstOrDefault(i => i.Id == BookId);
            if (book is null)
            {
                throw new InvalidOperationException("Kitap bulunamadı!");
            }
            context.Remove(book);
            context.SaveChanges();
        }
    }
}