using BookManager.Domain.Model;
using Microsoft.AspNetCore.Components;

namespace BookManager.Client.Pages
{
    public partial class Library :ComponentBase
    {
        public Guid Id { get; set; }
        private List<Book>? books;
        public string DeleteMessage { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await LoadBooks();
        }

        private async Task LoadBooks()
        {
            books = await bookRepository.GetAll();
            books = books.OrderByDescending(x => x.LastUpdate).ToList();
        }

        private async Task AddBookAsync()
        {
            Navigation.NavigateTo("/book/add");
            await LoadBooks();
        }

        private async Task EditBookAsync(Guid? id)
        {
            Navigation.NavigateTo($"/book/edit/{id}");
            await LoadBooks();
        }

        private async Task DeleteBook(Guid? Id)
        {
            (string msg, bool state) = await bookRepository.Delete(Id);
            DeleteMessage = msg;
            await LoadBooks();
        }
    }
}
