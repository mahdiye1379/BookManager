using BookManager.Domain.Model;
using Microsoft.AspNetCore.Components;

namespace BookManager.Client.Pages
{
    public partial class Home : ComponentBase
    {
                                                    
        public static List<Book>? Books = new List<Book>();

        [Inject]
        private NavigationManager Navigation { get; set; } = default;

        protected override async Task OnInitializedAsync()
        {
            Books = await bookRepository.GetAll();
        }

 
       
    }

}