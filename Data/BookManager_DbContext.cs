using BookManager.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace BookManager.Infrastructure
{
    public class BookManager_DbContext : DbContext
    {
        
        public BookManager_DbContext(DbContextOptions options) :base(options)
        {

        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
