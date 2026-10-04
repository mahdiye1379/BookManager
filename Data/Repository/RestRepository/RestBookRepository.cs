
using BookManager.Data.Model;
using System.Net;
using System.Net.Http.Json;

namespace BookManager.Data.Repository.RestRepository
{
    public class RestBookRepository
    {
        HttpClient Client = new HttpClient();

        public RestBookRepository()
        {
            Client.BaseAddress = new Uri(Config.ApiBaseUrl);
        }

        public async Task<List<Book>?> GetBook()
        {
           
            HttpResponseMessage result = await Client.GetAsync("Book/Get");

            List<Book>? Books = await result.Content.ReadFromJsonAsync<List<Book>>();

            return Books;
        }

        public async Task<Book?> SendGetBookRequest(Guid? id)
        {
      
            HttpResponseMessage result = await Client.GetAsync($"Book/Find/{id}");

            Book? book = await result.Content.ReadFromJsonAsync<Book>();

            return book;
        }

        public async Task<string> SendRemoveBook(Guid? id)
        {
            HttpResponseMessage result = await Client.DeleteAsync($"Book/Delete/{id}");
            return await result.Content.ReadAsStringAsync();
        }

        public async Task<(bool,string)> SendSave(Book book)
        {
            HttpResponseMessage result = await Client.PostAsJsonAsync<Book>("Book/SendSaveRequest", book);

            string ResultMessage = await result.Content.ReadAsStringAsync();

            if (result.StatusCode == HttpStatusCode.OK)
            {
                return (true, ResultMessage);
            }

            return (false, ResultMessage);
        }

    }
}
