using BookManager.Application.Interface;
using BookManager.Domain.Model;
using System.Net.Http.Json;

namespace BookManager.Infrastructure.Repository.RestRepository
{
    public class RestAuthorRepository : IAuthorRepository
    {
        HttpClient http = new HttpClient();

        public RestAuthorRepository()
        {
            http.BaseAddress = new Uri(Config.ApiBaseUrl);
        }

        public async Task<List<Author>?> GetAuthors()
        {
            HttpResponseMessage result = await http.GetAsync("Author/Get");
            List<Author>? Authors = await result.Content.ReadFromJsonAsync<List<Author>>();
            return Authors;
        }

    }
}
