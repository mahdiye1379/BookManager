using BookManager.Application.Interface;
using BookManager.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace BookManager.Infrastructure.Repository.EfRepository
{
    public class EfAuthorRepository : IAuthorRepository
    {
        private BookManager_DbContext _dbContext;

        public EfAuthorRepository(BookManager_DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Author?>> GetAuthors()
        {
            List<Author> authors = await _dbContext.Authors.ToListAsync();
            return authors;
        }
    }
}
