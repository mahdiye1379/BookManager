using BookManager.Application.Interface;
using BookManager.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace BookManager.Infrastructure.Repository.EfRepository
{
    public class EfCategoryRepository : ICategoryRepository
    {
        private BookManager_DbContext _dbContext;

        public EfCategoryRepository(BookManager_DbContext DbContext)
        {
            _dbContext = DbContext;
        }

        public async Task<List<Category>?> GetAll() {
            List<Category>? categories = await _dbContext.Categories.ToListAsync();
            return categories;
        }
    }
}
