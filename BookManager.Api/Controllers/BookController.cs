using BookManager.Data.Model;
using BookManager.Data.Repository.EfRepository;
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
        public async Task<IActionResult> Get()
        {
            var ListBooks = await _efBookRepository.GetBooks();
            return Ok(ListBooks);
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> Find([FromRoute]Guid id)
        {
            var book = await _efBookRepository.GetOneBookFromServer(id);
            return Ok(book);
        }

      
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete([FromRoute] Guid id)
        //{
        //    var result = await _efBookRepository.DeleteBook(id);
        //    return Ok(result);
        //}


        [HttpPost]
        public async Task<IActionResult> SendSaveRequest(Book book)
        {
            (bool status,string message) result = await _efBookRepository.Save(book);

            if (result.status is true)
            {
                return Ok(result.message);
            }
                return BadRequest(result.message);
        }
    }
}
