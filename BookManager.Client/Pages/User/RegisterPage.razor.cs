using BookManager.Data.DTO;
using BookManager.Data.Repository.RestRepository;
using Microsoft.AspNetCore.Components;

namespace BookManager.Client.Pages.User
{
    public partial class RegisterPage :ComponentBase
    {
        private RegisterDTO registerDTO = new();
        RestUserRepository restUserRepository = new RestUserRepository();

        private string? Message;

        private async Task RegisterUser()
        {
            Message = await restUserRepository.SendSaveRegister(registerDTO);
        } 

    }
}
