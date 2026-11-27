using BookManager.Domain.Model.Book;
using Microsoft.AspNetCore.Components;

namespace BookManager.Client.Pages
{
    public partial class Library :ComponentBase
    {
        public Guid Id { get; set; }
        private List<Book>? books;
        public string DeleteMessage { get; set; }
        private string? searchError;
        private bool isSearching;
        public string SearchText { get; set; } = "";

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

        private async Task SearchBooks()
        {
            if (isSearching)
                return;

            isSearching = true;
            searchError = null;

            try
            {
                books = await bookRepository.SearchTitle(SearchText.Trim()) ?? new();
            }
            catch (HttpRequestException)
            {
                searchError = "Couldn't reach the book service. Please try again.";
            }
            catch (System.Text.Json.JsonException)
            {
                searchError = "The book service returned an invalid response. Please try again.";
            }
            catch (TaskCanceledException)
            {
                searchError = "The search timed out. Please try again.";
            }
            finally
            {
                isSearching = false;
            }
        }
    }
}