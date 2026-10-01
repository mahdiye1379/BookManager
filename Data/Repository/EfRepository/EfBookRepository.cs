using BookManager.Data;
using BookManager.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace BookManager.Data.Repository.EfRepository
{
    public class EfBookRepository
    {
        private BookManager_DbContext _dbContext;
        public string ResultMsg { set; get; }

        public EfBookRepository(BookManager_DbContext DbContext)
        {
            _dbContext = DbContext;
        }

        public async Task<List<Book>> GetBooks(){

            List<Book> Books = await _dbContext.Books.ToListAsync();
            return Books;

        }
        public async Task<Book?> GetOneBookFromServer(Guid id)
        {

            Book? book = await _dbContext.Books.AsNoTracking().FirstOrDefaultAsync(x=>x.ID == id);
            return book;

        }

        //public async Task<string> DeleteBook(Guid Id)
        //{
        //   Book book = await GetOneBookFromServer(Id);

        //    if(book is not null)
        //        await _dbContext.Books.RemoveAsync(Id);
        //        return ResultMsg = "با موفقیت حذف شد";

        //}

        public async Task<(bool, string)> Save(Book book)
        {
            try
            {
               Book? DbBook = await GetOneBookFromServer(book.ID);

                if (DbBook is null)
                {
                    _dbContext.Add(book);
                }
                else
                {
                    _dbContext.Update(book);
                }

                await _dbContext.SaveChangesAsync();

                return (true, "Saved!");            
            }
            catch (Exception ex)
            {
                var exn = ex.InnerException;
                return (false, exn is null ? ex.Message : exn.Message);
            }
        }   

    }
}

