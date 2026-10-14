using BookManager.Application.Interface;
using BookManager.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace BookManager.Infrastructure.Repository.EfRepository
{
    public class EfBookRepository : IBookRepository
    {
        public string ResultMsg { set; get; }

        private BookManager_DbContext _dbContext;

        public EfBookRepository(BookManager_DbContext DbContext)
        {
            _dbContext = DbContext;
        }

        public async Task<List<Book>?> GetAll(){

            List<Book> Books = await _dbContext.Books.ToListAsync();
            return Books;

        }
        public async Task<Book?> GetOne(Guid id)
        {

            Book? book = await _dbContext.Books.AsNoTracking().FirstOrDefaultAsync(x=>x.ID == id);
            return book;

        }

        public async Task<(string,bool)> Delete(Guid? Id)
        {
            Book? book = await GetOne(Id.Value);

            if (book is not null)
            {
                try
                {

                    _dbContext.Books.Remove(book);
                    await _dbContext.SaveChangesAsync();
                    return ("با موفقیت حذف شد",true);

                }
                catch (Exception ex)
                {

#if DEBUG
                    Exception exi = ex.InnerException;
                    return (exi is not null ? exi.Message : ex.Message,false);
#else
                    return ("خطای در حذف کتاب بوجود امده است",false);
#endif
                }
            }
            else
            {
                return ("کتابی موجود نیست",false);
            }

        }

        public async Task<(bool, string)> Save(Book book)
        {
            try
            {
               Book? DbBook = await GetOne(book.ID);

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

