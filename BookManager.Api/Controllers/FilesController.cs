using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookManager.Api.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        IWebHostEnvironment _envieronment;
        public FilesController(IWebHostEnvironment envieronment)
        {
            _envieronment = envieronment;
        }

        [HttpPost]
        public async Task<IActionResult> Upload([FromForm]IFormFile form)
        {
            try
            {
                string Serverhard_ApiFolder = _envieronment.ContentRootPath + "\\wwwroot\\uploads";

                if(Directory.Exists(Serverhard_ApiFolder) == false)
                    Directory.CreateDirectory(Serverhard_ApiFolder);

                string FileName = Guid.NewGuid().ToString();
                string FileExtension = Path.GetExtension(form.FileName);

                // آدرس ذخیره فایل رو سرور
                string FilePath = Path.Combine(Serverhard_ApiFolder,FileName + FileExtension);

                // ساخت فایل خالی در سرور
                await using var EmptyFile = System.IO.File.Create(FilePath);

                // قرار دادن محتوای فایل دریافتی در فایل ایجاد شده در سرور
                await form.CopyToAsync(EmptyFile);

                string FileUrl = $"{Request.Scheme}://{Request.Host}/uploads/{FileName}{FileExtension}";

                return Ok(FileUrl);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException == null ? ex.Message : ex.InnerException);
            }
        }
    }
}
