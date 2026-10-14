using BookManager.Application.Interface;
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
    }
}
