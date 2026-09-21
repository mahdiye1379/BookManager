using BookManager.Data;
using Microsoft.AspNetCore.Mvc;

namespace BookManager.Api.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        BookManager_DbContext _dbContext;
        public BookController(BookManager_DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var ListBooks = _dbContext.book.ToList();
            return Ok(ListBooks);

        }
    }
}
