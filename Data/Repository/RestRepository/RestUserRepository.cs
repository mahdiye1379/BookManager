using BookManager.Domain.DTO;
using BookManager.Application.Interface;
using System.Net;
using System.Net.Http.Json;

namespace BookManager.Infrastructure.Repository.RestRepository
{
    public class RestUserRepository : IUserRepository
    {
        HttpClient client = new HttpClient();

        public RestUserRepository()
        {
            client.BaseAddress = new Uri(Config.ApiBaseUrl);
        }

        public async Task<(bool, string)> Login(LoginDto loginDto)
        {
            HttpResponseMessage httpMessage = await client.PostAsJsonAsync("User/Login",loginDto);
            string Message = await httpMessage.Content.ReadAsStringAsync();

            if(httpMessage.StatusCode == HttpStatusCode.OK)
            {
                return (true,Message);
            }
            return (false, Message);
        }

        public async Task<(string,bool)> Register(RegisterDTO registerDTO)
        {
            HttpResponseMessage responseMessage = await client.PostAsJsonAsync("User/Save", registerDTO);
            string msg = await responseMessage.Content.ReadAsStringAsync();
            if (responseMessage.StatusCode == HttpStatusCode.OK)
            {
                return (msg , true);
            }
            return (msg, false);
        }

    }
}
