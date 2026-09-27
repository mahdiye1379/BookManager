using BookManager.Core.EfRepository;
using Microsoft.AspNetCore.Mvc;

namespace BookManager.Api.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        EfBookRepository _efBookRepository;

        public BookController(EfBookRepository efBookRepository)
        {
            _efBookRepository = efBookRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var ListBooks = _efBookRepository.GetBooks();
            return Ok(ListBooks);
        }

    }
}
