
using BookManager.Application.Interface;
using BookManager.Domain.Model;
using System.Net.Http.Json;

namespace BookManager.Infrastructure.Repository.RestRepository
{
    public class RestCategoryRepository : ICategoryRepository
    {
        HttpClient http = new HttpClient();

        public RestCategoryRepository()
        {
            http.BaseAddress = new Uri(Config.ApiBaseUrl);
        }

        public async Task<List<Category>?> GetAll()
        {
            HttpResponseMessage result = await http.GetAsync("Category/Get");
            List<Category>? Categories = await result.Content.ReadFromJsonAsync<List<Category>>();
            return Categories;
        }
    }
}
