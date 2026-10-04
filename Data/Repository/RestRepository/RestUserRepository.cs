using BookManager.Data.DTO;
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


        public async Task<string> SendSaveRegister(RegisterDTO registerDTO)
        {
            HttpResponseMessage responseMessage = await client.PostAsJsonAsync("User/Save", registerDTO);
            return await responseMessage.Content.ReadAsStringAsync();
        }

    }
}
