using BookManager.Client.Data;
using Microsoft.AspNetCore.Components;

namespace BookManager.Client.Pages
{
    public partial class AddBook : ComponentBase
    {
        public Book Book { get; set; } = new();

        public List<Author> Authors { get; set; } = new();

        public List<Category> Categories { get; set; } = new();


        protected override async Task OnInitializedAsync()
        {
            
        }
        private void SaveForm()
        {

        }
    }
}

  
