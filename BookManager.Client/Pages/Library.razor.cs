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

        private void AddBook()
        {
            Navigation.NavigateTo("/book/add");
        }

        private void EditBook(Guid? id)
        {
            Navigation.NavigateTo($"/book/edit/{id}");
        }

        //private async Task DeleteBook(Guid Id)
        //{
        //    var msg = await restBookRepository.DeleteBook(Id);
        //    DeleteMessage = msg;
        //}
    }
}
