
using BookManager.Application.Interface;
using BookManager.Domain.Model;
using System.Net;
using System.Net.Http.Json;

namespace BookManager.Infrastructure.Repository.RestRepository
{
    public class RestCategoryRepository : ICategoryRepository
    {
        HttpClient Client = new HttpClient();

        public RestCategoryRepository()
        {
            Client.BaseAddress = new Uri(Config.ApiBaseUrl);
        }

        public async Task<Category?> GetOne(Guid? Id)
        {
            HttpResponseMessage result = await Client.GetAsync($"Category/GetOne/{Id}");
            Category? Category = await result.Content.ReadFromJsonAsync<Category>();
            return Category;
        }

        public async Task<List<Category>?> GetAll()
        {
            HttpResponseMessage result = await Client.GetAsync("Category/Get");
            List<Category>? Categories = await result.Content.ReadFromJsonAsync<List<Category>>();
            return Categories;
        }

        public async Task<(bool, string)> Save(Category category) 
        {
            HttpResponseMessage result = await Client.PostAsJsonAsync($"Category/Save", category);
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
     
    }
}
