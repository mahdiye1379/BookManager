
using BookManager.Data;
using BookManager.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace BookManager.Data.Repository.EfRepository
{
    public class EfCategoryRepository
    {
        private BookManager_DbContext _dbContext;

        public EfCategoryRepository(BookManager_DbContext DbContext)
        {
            _dbContext = DbContext;
        }

        public async Task<List<Category>> GetCategory() {
            List<Category> categories = await _dbContext.Categories.ToListAsync();
            return categories;
        }
    }
}
