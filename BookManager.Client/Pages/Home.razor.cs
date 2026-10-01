
using BookManager.Data.Model;
using BookManager.Data.Repository.RestRepository;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using InjectAttribute = Microsoft.AspNetCore.Components.InjectAttribute;
                
namespace BookManager.Client.Pages
{
    public partial class Home : ComponentBase
    {
                                                    
        public static List<Book>? Books = new List<Book>();

        [Inject]
        private NavigationManager Navigation { get; set; } = default;

      RestBookRepository restBookRepository = new RestBookRepository();

        protected override async Task OnInitializedAsync()
        {
            Books = await restBookRepository.GetBook();
        }

 
       
    }

}