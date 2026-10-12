using BookManager.Client.Authentication;
using BookManager.Data.DTO;
using BookManager.Data.Repository.RestRepository;
using Microsoft.AspNetCore.Components;

namespace BookManager.Client.Pages.User
{
    public partial class Login :ComponentBase
    {

        private LoginDto loginDto = new();
        private string? errorMessage;
        private bool isLoading;
        CustomAuthStatProvider AuthProvider = new CustomAuthStatProvider();
        RestUserRepository restUserRepository = new RestUserRepository();

        private async Task LoginUser()
        {

            (bool s, string m) = await restUserRepository.SendLoginRequest(loginDto);
            errorMessage = m;
            if (s is true)
            {
                Navigation.NavigateTo("/");
                AuthProvider.Login(loginDto.UserName);
            }
            
        }
    }

}
