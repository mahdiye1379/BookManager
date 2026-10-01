using BookManager.Data.Model;
using System.Net.Http.Json;

namespace BookManager.Data.Repository.RestRepository
{
    public class RestAuthorRepository
    {
        HttpClient http = new HttpClient();

        public RestAuthorRepository()
        {
            http.BaseAddress = new Uri(Config.ApiBaseUrl);
        }

        public async Task<List<Author>?> GetAuthor()
        {
            HttpResponseMessage result = await http.GetAsync("Author/Get");
            List<Author>? Authors = await result.Content.ReadFromJsonAsync<List<Author>>();
            return Authors;
        }

    }
}
