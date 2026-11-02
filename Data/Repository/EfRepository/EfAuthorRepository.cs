using BookManager.Application.Interface;
using BookManager.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace BookManager.Infrastructure.Repository.EfRepository
{
    public class EfAuthorRepository : IAuthorRepository
    {
        private BookManager_DbContext _dbContext;

        public EfAuthorRepository(BookManager_DbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<(bool,string)> SaveAuthor(Author author)
        {
            Author? FindAuthor = _dbContext.Authors.FirstOrDefault(x => x.ID == author.ID);
            bool isNew = FindAuthor is null;

                try
                {
                    if (FindAuthor == null)
                    {                    
                        _dbContext.Authors.Add(author);
                        
                    }
                    else
                    {
                        FindAuthor.Name = author.Name;
                        FindAuthor.Bio = author.Bio;
                        FindAuthor.Country = author.Country;
                        FindAuthor.Image = author.Image;

                        _dbContext.Authors.Update(FindAuthor);

                    }

                    await _dbContext.SaveChangesAsync();
                    return (true, isNew ? "Saved" : "Updated");
            }
                catch (Exception ex)
                {

#if DEBUG

                    return (false, ex.InnerException == null ? ex.Message : ex.Message);
#else
                return (false, "There is a problem saving the author...");
#endif

                }
            }


        public async Task<List<Author?>> GetAuthors()
        {
            List<Author> authors = await _dbContext.Authors.ToListAsync();
            return authors;
        }

        public async Task<Author?> GetOne(Guid Id)
        {
            Author? author = await _dbContext.Authors.FirstOrDefaultAsync(x => x.ID == Id);

            return author;
        }
        
    }
}
