using BookManager.Data;
using Microsoft.AspNetCore.Mvc;

namespace BookManager.Api.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        BookManager_DbContext _dbContext;
        public AuthorController(BookManager_DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var ListAuthor = _dbContext.Authors.ToList();
            return Ok(ListAuthor);

        }
    }
}
