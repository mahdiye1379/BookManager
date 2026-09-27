using BookManager.Client.Repository.RestRepository;
using BookManager.Data.Model;
using Microsoft.AspNetCore.Components;


namespace BookManager.Client.Pages
{

    public partial class AddBook : ComponentBase
    {
        public Book Book { get; set; } = new();

        public List<Author>? Authors { get; set; } = new();

        public List<Category>? Categories { get; set; } = new();

        RestAuthorRepository restAuthorRepository = new RestAuthorRepository();
        RestCategoryRepository restCategoryRepository = new RestCategoryRepository();


        protected override async Task OnInitializedAsync()
        {
            Authors = await restAuthorRepository.GetAuthor();

            Categories = await restCategoryRepository.GetCategory();
        }

        private void SaveForm()
        {

        }
    }
}

  
