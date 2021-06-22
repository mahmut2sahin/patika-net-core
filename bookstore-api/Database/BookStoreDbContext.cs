using bookstore_api.Entities;
using Microsoft.EntityFrameworkCore;

namespace bookstore_api.Database
{
    public class BookStoreDbContext : DbContext
    {
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
    }
}