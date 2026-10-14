using BookManager.Domain.Model;
using Microsoft.AspNetCore.Components;


namespace BookManager.Client.Pages
{

    public partial class BookDetailes : ComponentBase
    {
        [Parameter]
        public Guid Id { get; set; }
        public Book? book { get; set; }

        private float progressPercent;
        private int remainingPages;
        private bool isLoading;
        private string? errorMessage;

        protected override async Task OnParametersSetAsync()
        {

           book = await bookRepository.GetOne(Id);

            if (book != null)
            {
                progressPercent = book.CurrentReadingPage * 100 / book.TotalPage;
                remainingPages = book.TotalPage - book.CurrentReadingPage;
            }

        }

    }
}
