using BookManager.Application.Interface;

namespace BookManager.Infrastructure.Repository.RestRepository
{

    public class RestFileRepository : IFileRepository
    {
        HttpClient Client = new HttpClient();

        public RestFileRepository()
        {
            Client.BaseAddress = new Uri(Config.ApiBaseUrl);
        }

        public async Task<string> Upload(MultipartFormDataContent? fileContent)
        {
            HttpResponseMessage httpResponseMessage = await Client.PostAsync("Files/Upload", fileContent);
            string serverFilePath = await httpResponseMessage.Content.ReadAsStringAsync();
            return serverFilePath;

        }
    }
}

