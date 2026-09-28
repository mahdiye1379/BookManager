using BookManager.Data;
using BookManager.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace BookManager.Core.EfRepository
{
    public class EfBookRepository
    {
        private BookManager_DbContext _dbContext;

        public EfBookRepository(BookManager_DbContext DbContext)
        {
            _dbContext = DbContext;
        }

        public async Task<List<Book>> GetBooks(){

            List<Book> Books = await _dbContext.Books.ToListAsync();
            return Books;

        }


        public async Task<(bool, string)> Save(Book book)
        {
            try
            {
                _dbContext.Add(book);
                await _dbContext.SaveChangesAsync();

                return (true, "Saved!");            
            }
            catch (Exception ex)
            {                               
                return (false, ex.InnerException.Message);
            }
        }   

    }
}

