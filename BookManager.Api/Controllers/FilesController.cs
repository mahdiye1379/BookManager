using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        IWebHostEnvironment _envieronment;
        public FilesController(IWebHostEnvironment envieronment)
        {
            _envieronment = envieronment;
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Upload([FromForm]IFormFile form)
        {
            try
            {
                string Serverhard_ApiFolder = _envieronment.ContentRootPath;
                string FileName = Guid.NewGuid().ToString();
                string FileAttechment = Path.GetExtension(form.FileName);


                string FilePath = Serverhard_ApiFolder + "/" + FileName + FileAttechment;

                await using var EmptyFile = System.IO.File.Create(FilePath);

                await form.CopyToAsync(EmptyFile);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException == null ? ex.Message : ex.InnerException);
            }
        }
    }
}
