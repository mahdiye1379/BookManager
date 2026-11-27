using BookManager.Domain.Model.Book;

namespace BookManager.Application.Interface
{
    public interface ICategoryRepository
    {
        public Task<List<Category>?> GetAll();
        public Task<(bool,string)> Save(Category category);

        public Task<Category?> GetOne(Guid? Id);

    }
}
