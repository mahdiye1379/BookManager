
using BookManager.Application.Interface;
using BookManager.Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace BookManager.Api.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var ListBooks = await _bookRepository.GetAll();
            return Ok(ListBooks);
        }

        [HttpGet]
        public async Task<IActionResult> TotalPage()
        {
            int BooksCount = await _bookRepository.GetBookCount();
            return Ok(BooksCount);
        }

        [HttpGet("{Page}/{Count}")]
        public async Task<IActionResult> Get([FromRoute] int Page, [FromRoute] int Count)
        {
            var ListBooks = await _bookRepository.GetAll(Page , Count);
            return Ok(ListBooks);
        }

        [HttpGet("{Page}/{Count}/{SearchText}")]
        public async Task<IActionResult> Search([FromRoute] int Page, [FromRoute] int Count, [FromRoute] string SearchText)
        {
            List<Book>? ListBooks = await _bookRepository.Search(Page, Count, SearchText);
            return Ok(ListBooks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Find([FromRoute]Guid id)
        {
            var book = await _bookRepository.GetOne(id);
            return Ok(book);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            (string Message, bool State) result = await _bookRepository.Delete(id);
            if(result.State == true)
            {
                return Ok(result.Message);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> SendSaveRequest(Book book)
        {
            (bool status,string message) result = await _bookRepository.Save(book);

            if (result.status is true)
            {
                return Ok(result.message);
            }
                return BadRequest(result.message);
        }
    }
}
