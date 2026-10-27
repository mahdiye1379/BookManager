
using BookManager.Application.Interface;
using BookManager.Domain.Model;
using System.Net;
using System.Net.Http.Json;

namespace BookManager.Infrastructure.Repository.RestRepository
{
    public class RestBookRepository : IBookRepository
    {
        HttpClient Client = new HttpClient();

        public RestBookRepository()
        {
            Client.BaseAddress = new Uri(Config.ApiBaseUrl);
        }

        public async Task<List<Book>?> GetAll()
        {
           
            HttpResponseMessage result = await Client.GetAsync("Book/Get");

            List<Book>? Books = await result.Content.ReadFromJsonAsync<List<Book>>();

            return Books;
        }

        public async Task<int> GetBookCount()
        {
            HttpResponseMessage result = await Client.GetAsync("Book/TotalPage");
            int Count = await result.Content.ReadFromJsonAsync<int>();
            return Count;
        }
        
        public async Task<List<Book>?> GetAll(int Page, int Count)
        {

            HttpResponseMessage result = await Client.GetAsync($"Book/Get/{Page}/{Count}");

            List<Book>? Books = await result.Content.ReadFromJsonAsync<List<Book>>();

            return Books;
        }
        public async Task<List<Book>?> Search(int Page, int Count,string SearchText)
        {

            HttpResponseMessage result = await Client.GetAsync($"Book/Search/{Page}/{Count}/{SearchText}");

            List<Book>? Books = await result.Content.ReadFromJsonAsync<List<Book>>();

            return Books;
        }

        public async Task<Book?> GetOne(Guid id)
        {
      
            HttpResponseMessage result = await Client.GetAsync($"Book/Find/{id}");

            Book? book = await result.Content.ReadFromJsonAsync<Book>();

            return book;
        }

        public async Task<(string,bool)> Delete(Guid? id)
        {
            HttpResponseMessage result = await Client.DeleteAsync($"Book/Delete/{id}");
            string msg = await result.Content.ReadAsStringAsync();

            if (result.StatusCode == HttpStatusCode.OK)
            {
                return (msg,true);
            }
            return (msg,false);
        }

        public async Task<(bool,string)> Save(Book book)
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
