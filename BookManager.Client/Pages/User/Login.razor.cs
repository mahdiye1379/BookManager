using BookManager.Domain.DTO;
using BookManager.Infrastructure.Repository.RestRepository;
using Microsoft.AspNetCore.Components;

namespace BookManager.Client.Pages.User
{
    public partial class Login :ComponentBase
    {

        private LoginDto loginDto = new();
        private string? errorMessage;
        private bool isLoading;

        private async Task LoginUser()
        {

            (bool s, string m) = await userRepository.Login(loginDto);
            errorMessage = m;
            if (s is true)
            {
                AuthProvider.Login(loginDto.UserName);
                Navigation.NavigateTo("/");
            }
            
        }
    }

}
