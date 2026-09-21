using BookManager.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BookManager.Data
{
    public class BookManager_DbContext : DbContext
    {
        
        public BookManager_DbContext(DbContextOptions options) :base(options)
        {

        }

        public DbSet<Author> authors { get; set; }
        public DbSet<Book> book { get; set; }
        public DbSet<Category> categories { get; set; }
    }
}
