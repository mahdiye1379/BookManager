using BookManager.Domain.DTO;
using Microsoft.AspNetCore.Components;

namespace BookManager.Client.Pages.User
{
    public partial class RegisterPage :ComponentBase
    {
        private RegisterDTO registerDTO = new();

        private string? Message;

        private async Task RegisterUser()
        {
            (string msg, bool state) = await userRepository.Register(registerDTO);
            Message = msg;
        } 

    }
}
