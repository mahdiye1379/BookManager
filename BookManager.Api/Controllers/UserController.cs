using BookManager.Application.Interface;
using BookManager.Domain.DTO;
using Microsoft.AspNetCore.Mvc;

namespace BookManager.Api.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        [HttpPost]
        public async Task<IActionResult> Save(RegisterDTO registerDTO)
        {
            (string Message, bool Status) result = await _userRepository.Register(registerDTO);

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
            (bool State, string Message) result = await _userRepository.Login(loginDTO);

            if (result.State == true)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
    }
}
