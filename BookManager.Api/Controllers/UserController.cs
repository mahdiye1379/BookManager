using BookManager.Data.DTO;
using BookManager.Data.Repository.EfRepository;
using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;

namespace BookManager.Api.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        EfUserRepository _efUserRepository;

        public UserController(EfUserRepository efUserRepository)
        {
            _efUserRepository = efUserRepository;
        }


        [HttpPost]
        public async Task<IActionResult> Save(RegisterDTO registerDTO)
        {
            (string Message, bool Status) result = await _efUserRepository.Save(registerDTO);

            if (result.Status is true)
            {
                return Ok(result.Message);
            }
            else
            {
                return BadRequest(result.Message);
            }

        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDTO)
        {
            (bool State, string Message) result = await _efUserRepository.Login(loginDTO);

            if (result.State == true)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
    }
}
