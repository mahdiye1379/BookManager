using BookManager.Application.Interface;
using BookManager.Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace BookManager.Api.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var ListCategory = await _categoryRepository.GetAll();
            return Ok(ListCategory);

        }

        [HttpPost]
        public async Task<IActionResult> Save([FromBody] Category category)
        {
            (bool state, string message) = await _categoryRepository.Save(category);
            if (state is true)
            {
                return Ok(message);
            }
            else
            {
                return BadRequest(message);
            }
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetOne([FromRoute] Guid? Id)
        {
            var Category = await _categoryRepository.GetOne(Id);
            return Ok(Category);
        }
    }
}
