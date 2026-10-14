using BookManager.Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace BookManager.Api.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        IAuthorRepository _authorRepository;
        public AuthorController(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var ListAuthor = await _authorRepository.GetAuthors();
            return Ok(ListAuthor);

        }
    }
}
