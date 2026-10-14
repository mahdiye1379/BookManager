using BookManager.Domain.Model;
using Microsoft.AspNetCore.Components;

namespace BookManager.Client.Pages
{

    public partial class AddBook : ComponentBase
    {
        [Parameter]
        public Guid? id { get; set; }

        public bool IsEdit => id is null ? false : true;

        public string Message { get; set; }
        public Book UiBook { get; set; } = new();

        public List<Author>? Authors { get; set; } = new();

        public List<Category>? Categories { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            Authors = await authorRepository.GetAuthors();
            Categories = await categoryRepository.GetAll ();

            if(IsEdit is true)
            {
               Book? ServerBook = await bookRepository.GetOne(id.Value);

                UiBook.AuthorId = ServerBook.AuthorId;
                UiBook.Summery = ServerBook.Summery;
                UiBook.CurrentReadingPage = ServerBook.CurrentReadingPage;
                UiBook.FilePath = ServerBook.FilePath;
                UiBook.TotalPage = ServerBook.TotalPage;
                UiBook.CategoryId = ServerBook.CategoryId;
                UiBook.Cover = ServerBook.Cover;
                UiBook.ID = ServerBook.ID;
                UiBook.LastUpdate = ServerBook.LastUpdate;
                UiBook.Title = ServerBook.Title;
                UiBook.RegDate = ServerBook.RegDate;

            }
        }

        private async Task SaveForm()
        {
            UiBook.LastUpdate = DateTime.Now;
           (bool status,string message) result = await bookRepository.Save(UiBook);

            if(result.status is true)
            {
                Navigation.NavigateTo("/library");
            }
            else
            {

#if DEBUG

                Message = result.message;

#elif RELEASE

                Message = "با خطا مواجه شدید!";
#endif
            }


        }
    }
}

  
