using BookManager.Data.DTO;
using System.Net;
using System.Net.Http.Json;

namespace BookManager.Data.Repository.RestRepository
{
    public class RestUserRepository
    {
        HttpClient client = new HttpClient();

        public RestUserRepository()
        {
            client.BaseAddress = new Uri(Config.ApiBaseUrl);
        }

        public async Task<(bool, string)> SendLoginRequest(LoginDto loginDto)
        {
            HttpResponseMessage httpMessage = await client.PostAsJsonAsync("User/Login",loginDto);
            string Message = await httpMessage.Content.ReadAsStringAsync();

            if(httpMessage.StatusCode == HttpStatusCode.OK)
            {
                return (true,Message);
            }
            return (false, Message);
        }

        public async Task<string> SendSaveRegister(RegisterDTO registerDTO)
        {
            HttpResponseMessage responseMessage = await client.PostAsJsonAsync("User/Save", registerDTO);
            return await responseMessage.Content.ReadAsStringAsync();
        }

    }
}
