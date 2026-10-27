using BookManager.Domain.Model;

namespace BookManager.Application.Interface
{
    public interface IBookRepository
    {
        public Task<List<Book>?> GetAll();
        public Task<int> GetBookCount();
        public Task<List<Book>?> GetAll(int Page,int Count); 
        public Task<List<Book>?> Search(int Page, int Count,string SearchText);
        public Task<Book?> GetOne(Guid id);
        public Task<(string, bool)> Delete(Guid? Id);
        public Task<(bool, string)> Save(Book book);
    }
}