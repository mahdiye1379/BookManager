using BookManager.Data.Model;
using BookManager.Data.Repository.RestRepository;
using Microsoft.AspNetCore.Components;

namespace BookManager.Client.Pages
{
    public partial class Library :ComponentBase
    {
        public Guid Id { get; set; }
        private List<Book>? books;
        public string DeleteMessage { get; set; }
        RestBookRepository restBookRepository = new RestBookRepository();

        protected override async Task OnInitializedAsync()
        {
            await LoadBooks();
        }

        private async Task LoadBooks()
        {
            books = await restBookRepository.GetBook();
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
            var msg = await restBookRepository.SendRemoveBook(Id);
            DeleteMessage = msg;
            await LoadBooks();
        }
    }
}
