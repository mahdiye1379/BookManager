using BookManager.Domain.Model;

namespace BookManager.Application.Interface
{
    public interface IAuthorRepository
    {
        public Task<List<Author?>> GetAuthors();
    }
}
