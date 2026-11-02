using BookManager.Application.Interface;
using BookManager.Domain.Model;
using System.Net;
using System.Net.Http.Json;

namespace BookManager.Infrastructure.Repository.RestRepository
{
    public class RestAuthorRepository : IAuthorRepository
    {
        HttpClient Client = new HttpClient();

        public RestAuthorRepository()
        {
            Client.BaseAddress = new Uri(Config.ApiBaseUrl);
        }

        public async Task<(bool, string)> SaveAuthor(Author author)
        {
            HttpResponseMessage result = await Client.PostAsJsonAsync($"Author/Save",author);
            string Message = await result.Content.ReadAsStringAsync();

            if (result.StatusCode == HttpStatusCode.OK)
            {
                return (true, Message);
            }
            else
            {
                return (false, Message);
            }
        }

        public async Task<List<Author>?> GetAuthors()
        {
            HttpResponseMessage result = await Client.GetAsync("Author/Get");
            List<Author>? Authors = await result.Content.ReadFromJsonAsync<List<Author>>();
            return Authors;
        }

        public async Task<Author?> GetOne(Guid Id)
        {
            HttpResponseMessage result = await Client.GetAsync($"Author/GetOne/{Id}");
            Author? Author = await result.Content.ReadFromJsonAsync<Author>();

            if (result.StatusCode == System.Net.HttpStatusCode.NotFound)
                return null;

            return Author;
        }

    }
}
