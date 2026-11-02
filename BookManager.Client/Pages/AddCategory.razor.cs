using BookManager.Domain.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BookManager.Client.Pages
{
    public partial class AddCategory : ComponentBase
    {
        Category Category = new Category();

        private string FormMessage { get; set; } = "";

        [Parameter]
        public Guid? Id { get; set; }

        [Inject]
        public IJSRuntime JS { get; set; } = default!;

        private string SaveButtonText = "";

        private bool IsSuccess;
        private string PreviewName => Category.Name;


        protected override async Task OnParametersSetAsync()
        {
            if (Id != null)
                await GetCategory();

            SaveButtonText = Id != null ? "Update Category" : "Save Category";
        }


        private async Task GetCategory()
        {

            Category? category = await CategoryRepository.GetOne(Id.Value);

            if (category == null)
                return;

            if (category != null)
                Category = category;
        }


        public async Task SaveCategory()
        {
            if (Category.Name == null)
            {
                FormMessage = "Please Add Category Name...";
            }
            else {
                (bool status, string message) = await CategoryRepository.Save(Category);

                IsSuccess = status;
                FormMessage = message;

                await JS.InvokeVoidAsync("window.scrollTo", new { top = 0, behavior = "smooth" });

                Category.Name = "";
            }
        }

        public void ResetForm()
        {
            Category.Name = "";
        }
        
    }

}
