using BookManager.Domain.Model;
using Microsoft.AspNetCore.Components;
using CategoryModel = BookManager.Domain.Model.Category;

namespace BookManager.Client.Pages
{
    public partial class Category : ComponentBase
    {

        private List<Book>? books;
        private List<CategoryModel>? categories = new();

        private List<Book>? selectedBooks = new();
        private CategoryModel? selectedCategory;

        private string? errorMessage;
        private bool isLoading = true;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                categories = await CategoryRepository.GetAll() ?? new();
                books = await BookRepository.GetAll() ?? new();
            }
            catch
            {
                errorMessage = "Please refresh the page and try again.";
            }
            finally
            {
                isLoading = false;
            }
        }

        public void SelectCategory(CategoryModel category)
        {
            selectedCategory = category;

            selectedBooks = books
             .Where(book => book.CategoryId == category.ID)
             .OrderByDescending(book => book.LastUpdate)
             .ToList();
        }

  
    }
}
