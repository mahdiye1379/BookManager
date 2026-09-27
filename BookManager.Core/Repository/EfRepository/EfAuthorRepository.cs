using BookManager.Data;
using BookManager.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace BookManager.Core.EfRepository
{
    public class EfAuthorRepository
    {
        private BookManager_DbContext _dbContext;

        public EfAuthorRepository(BookManager_DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Author>> GetAuthors()
        {
            List<Author> authors = await _dbContext.Authors.ToListAsync();
            return authors;
        }
    }
}
