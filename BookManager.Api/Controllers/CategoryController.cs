using BookManager.Core.EfRepository;
using BookManager.Data;
using Microsoft.AspNetCore.Mvc;

namespace BookManager.Api.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        EfCategoryRepository efCategoryRepository;
        public CategoryController(BookManager_DbContext dbContext)
        {
            efCategoryRepository = new EfCategoryRepository(dbContext);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var ListCategory = efCategoryRepository.GetCategory();
            return Ok(ListCategory);

        }
    }
}
