
using BookManager.Data.Model;
using System.Net;
using System.Net.Http.Json;

namespace BookManager.Data.Repository.RestRepository
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

        public async Task<Book?> SendGetBookRequest(Guid? id)
        {
      
            HttpResponseMessage result = await http.GetAsync($"Book/Find/{id}");

            Book? book = await result.Content.ReadFromJsonAsync<Book>();

            return book;
        }

        public async Task<(bool,string)> SendSave(Book book)
        {
            HttpResponseMessage result = await http.PostAsJsonAsync<Book>("Book/SendSaveRequest", book);

            string ResultMessage = await result.Content.ReadAsStringAsync();

            if (result.StatusCode == HttpStatusCode.OK)
            {
                return (true, ResultMessage);
            }

            return (false, ResultMessage);
        }

    }
}
