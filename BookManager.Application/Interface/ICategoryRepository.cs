
using BookManager.Domain.Model;

namespace BookManager.Application.Interface
{
    public interface ICategoryRepository
    {
        public Task<List<Category>?> GetAll();
        
    }
}
