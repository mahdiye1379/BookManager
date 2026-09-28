using BookManager.Core.EfRepository;
using BookManager.Data;
using Microsoft.AspNetCore.Mvc;

namespace BookManager.Api.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        EfAuthorRepository efAuthorRepository;
        public AuthorController(BookManager_DbContext dbContext)
        {
            efAuthorRepository = new EfAuthorRepository(dbContext);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var ListAuthor = await efAuthorRepository.GetAuthors();
            return Ok(ListAuthor);

        }
    }
}
