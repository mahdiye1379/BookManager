using BookManager.Client.Data;
using Microsoft.AspNetCore.Components;
using Ninject;
using System.Net.Http.Json;
using InjectAttribute = Microsoft.AspNetCore.Components.InjectAttribute;

namespace BookManager.Client.Pages
{
    public partial class Home : ComponentBase
    {

        public static List<Book> Books = new List<Book>();

        [Inject]
        private NavigationManager Navigation { get; set; } = default;


        HttpClient http = new HttpClient();


        protected override async Task OnInitializedAsync()
        {
            http.BaseAddress = new Uri("http://192.168.41.62:8033/api/");
            HttpResponseMessage result = await http.GetAsync("Book/Get");
            Books = await result.Content.ReadFromJsonAsync<List<Book>>();
        }

        public void AddBook()
        {
            Navigation.NavigateTo("/book/add/");
        }
       
    }

}
