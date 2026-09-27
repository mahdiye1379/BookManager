using System.Text.Json;
using BookManager.Core;
using BookManager.Data.Model;
using System.Net.Http.Json;
using System.Text.Json;

namespace BookManager.Client.Repository.RestRepository
{
    public class RestBookRepository
    {
        HttpClient http = new HttpClient();

        public RestBookRepository()
        {
            http.BaseAddress = new Uri(Config.ApiBaseUrl);
        }

        //public async Task<List<Book>?> GetBook()
        //{
        //    HttpResponseMessage result = await http.GetAsync("Book/Get");                       
        //    List<Book>? Books = await result.Content.ReadFromJsonAsync<List<Book>>();
        //    return Books;
        //}
        public async Task<List<Book>?> GetBook()
        {
            HttpResponseMessage result = await http.GetAsync("Book/Get");

            string content = await result.Content.ReadAsStringAsync();

            Console.WriteLine($"Status Code: {result.StatusCode}");
            Console.WriteLine($"Response: {content}");

            if (!result.IsSuccessStatusCode)
            {
                return null;
            }

            if (string.IsNullOrWhiteSpace(content))
            {
                return null;
            }

            List<Book>? Books =
                JsonSerializer.Deserialize<List<Book>>(content);

            return Books;
        }

    }
}
