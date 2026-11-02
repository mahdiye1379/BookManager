using BookManager.Domain.Model;

namespace BookManager.Application.Interface
{
    public interface IAuthorRepository
    {
        public Task<List<Author?>> GetAuthors();
        public Task<(bool, string)> SaveAuthor(Author author);
        public Task<Author?> GetOne(Guid Id);
    }
}
