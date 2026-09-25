using BookManager.Client.Data;
using System.Net.Http.Json;

namespace BookManager.Client.Repository.RestRepository
{
    public class RestBookRepository
    {
        HttpClient http = new HttpClient();

        public RestBookRepository()
        {
            http.BaseAddress = new Uri(Config.ApiBaseUrl);
        }

        public async Task<List<Book>?> GetBook()
        {
            HttpResponseMessage result = await http.GetAsync("Book/Get");                       
            List<Book>? Books = await result.Content.ReadFromJsonAsync<List<Book>>();
            return Books;
        }

    }
}
