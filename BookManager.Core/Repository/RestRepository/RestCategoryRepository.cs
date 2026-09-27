
using BookManager.Core;
using BookManager.Data.Model;
using System.Net.Http.Json;

namespace BookManager.Client.Repository.RestRepository
{
    public class RestCategoryRepository
    {
        HttpClient http = new HttpClient();

        public RestCategoryRepository()
        {
            http.BaseAddress = new Uri(Config.ApiBaseUrl);
        }

        public async Task<List<Category>?> GetCategory()
        {
            HttpResponseMessage result = await http.GetAsync("Category/Get");
            List<Category>? Categories = await result.Content.ReadFromJsonAsync<List<Category>>();
            return Categories;
        }
    }
}
