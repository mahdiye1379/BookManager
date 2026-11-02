using BookManager.Application.Interface;
using Microsoft.AspNetCore.Mvc;
using BookManager.Domain.Model;

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

        [HttpPost]
        public async Task<IActionResult> Save([FromBody] Author author)
        {
             (bool state,string message) = await _authorRepository.SaveAuthor(author);
            if(state is true)
            {
                return Ok(message);
            }
            else
            {
                return BadRequest(message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var ListAuthor = await _authorRepository.GetAuthors();
            return Ok(ListAuthor);

        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetOne([FromRoute] Guid Id)
        {
            var OneAuthor = await _authorRepository.GetOne(Id);

            if (OneAuthor is null)
                return NotFound();

            return Ok(OneAuthor);

        }
    }
}
