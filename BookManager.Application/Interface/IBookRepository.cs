using BookManager.Domain.Model;

namespace BookManager.Application.Interface
{
    public interface IBookRepository
    {
        public Task<List<Book>?> GetAll();
        public Task<Book?> GetOne(Guid id);
        public Task<(string, bool)> Delete(Guid? Id);
        public Task<(bool, string)> Save(Book book);
    }
}