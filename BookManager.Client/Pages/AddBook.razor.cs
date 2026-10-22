using BookManager.Domain.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace BookManager.Client.Pages
{

    public partial class AddBook : ComponentBase
    {
        [Parameter]
        public Guid? id { get; set; }

        public bool IsEdit => id is null ? false : true;

        public string Message { get; set; }
        public Book UiBook { get; set; } = new();

        private bool IsUploadingPdf, IsUploadingCover;

        public List<Author>? Authors { get; set; } = new();

        public List<Category>? Categories { get; set; } = new();

        long maxFileSize = 104857600;

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

    private async Task<string> Upload(InputFileChangeEventArgs e)
    {
        IBrowserFile? file = e.File;
        if (file is null) 
            return "";

        using MultipartFormDataContent? content = new MultipartFormDataContent();
        using StreamContent? streamContent = new StreamContent(file.OpenReadStream(maxFileSize));

        streamContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(file.ContentType);
        content.Add(streamContent, "form", file.Name);

        string filePathOnServer = await FileRepository.Upload(content);
        return filePathOnServer;
    }

    private async Task UploadCoverImage(InputFileChangeEventArgs e)
     {

            Console.WriteLine("UploadCoverImage started");

            string ImagePathOnServer = await Upload(e);

            Console.WriteLine($"Upload finished: {ImagePathOnServer}");

            UiBook.Cover = ImagePathOnServer;

    }
        private async Task UploadFilePdf(InputFileChangeEventArgs e)
        {

            string PdfPathOnServer = await Upload(e);
            UiBook.FilePath = PdfPathOnServer;

        }
    }
}

  
