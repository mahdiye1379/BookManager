using BookManager.Data;
using Microsoft.AspNetCore.Mvc;

namespace BookManager.Api.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        BookManager_DbContext _dbContext;
        public CategoryController(BookManager_DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var ListCategory = _dbContext.Categories.ToList();
            return Ok(ListCategory);

        }
    }
}
