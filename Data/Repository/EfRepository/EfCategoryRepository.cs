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

        public async Task<Category?> GetOne(Guid? Id)
        {
            Category? category = await _dbContext.Categories.FirstOrDefaultAsync(x=>x.ID == Id);
            return category;
        }

        public async Task<List<Category>?> GetAll() {
            List<Category>? categories = await _dbContext.Categories.ToListAsync();
            return categories;
        }

        public async Task<(bool, string)> Save(Category category) 
        {
            Category? FindCategory = _dbContext.Categories.FirstOrDefault(x => x.ID == category.ID);
            bool isNew = FindCategory is null;

            try
            {
                if (FindCategory == null)
                {
                    _dbContext.Categories.Add(category);

                }
                else
                {
                    FindCategory.Name = category.Name;
                    _dbContext.Categories.Update(FindCategory);

                }

                await _dbContext.SaveChangesAsync();
                return (true, isNew ? "Saved" : "Updated");

            }
            catch (Exception ex)
            {

#if DEBUG

                return (false, ex.InnerException == null ? ex.Message : ex.Message);
#else
                return (false, "There is a problem saving the Category...");
#endif

            }
        }

    }
}
