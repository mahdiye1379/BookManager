using BookManager.Domain.Model;
using Microsoft.AspNetCore.Components;

namespace BookManager.Client.Pages
{
    public partial class Home : ComponentBase
    {
        
        public static List<Book>? Books = new List<Book>();
        private string SearchText= "";
        private int BooksPerPage = 20;
        private int TotalPage, CurrentPage=1;
        private bool IsSearchModeOn => SearchText == "" ? false : true;

        [Inject]
        private NavigationManager Navigation { get; set; } = default;

        protected override async Task OnInitializedAsync()
        {
            await FindTotalPage();
            await LoadBooks();
        }
        private async Task<int> FindTotalPage()
        {
            int BooksCount = await bookRepository.GetBookCount();
            double devide = (double)BooksCount / BooksPerPage;
            TotalPage = (int)Math.Ceiling(devide);
            return TotalPage;
        }

        public async Task SearchBooks()
        {
            CurrentPage = 1;
            await LoadBooks();
        }

        private async Task PreviousPage()
        {
            CurrentPage--;
            await LoadBooks();
        }

        private async Task NextPage()
        {
            CurrentPage++;
            await LoadBooks();
        }

        private async Task ChangePage(int pageNumber)
        {
            CurrentPage = pageNumber;
            await LoadBooks();
        }
            
        private async Task LoadBooks()
        {
            if (IsSearchModeOn == true)
            {
                Books = await bookRepository.Search(CurrentPage, BooksPerPage, SearchText);
            }
            else
            {
                Books = await bookRepository.GetAll(CurrentPage, BooksPerPage);
            }
        }
    }

}
