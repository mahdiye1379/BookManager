using BookManager.Domain.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;


namespace BookManager.Client.Pages
{
    public partial class AddAuthor : ComponentBase
    {
        public Author Author = new Author();
        private string FormMessage = "";
        private string SaveButtonText = "";
        private bool IsSuccess;

        [Inject]
        public IJSRuntime JS { get; set; } = default!;

        [Parameter]
        public Guid? Id { get; set; }

        long maxFileSize = 104857600;


        protected override async Task OnParametersSetAsync()
        {
            if (Id != null)
                await GetAuthor();

            SaveButtonText = Id != null ? "Update Author" : "Save Author";
        }
        
          
         private async Task GetAuthor() {

            Author? author = await AuthorRepository.GetOne(Id.Value);

            if (author == null)
                return;

            if(author != null)
                Author = author;
         }
        
        
        private async Task UploadAuthorImage(InputFileChangeEventArgs e)
        {
            IBrowserFile file = e.File;

            MultipartFormDataContent Content = new MultipartFormDataContent();
            StreamContent streamContent = new StreamContent(file.OpenReadStream(maxFileSize));

            streamContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(file.ContentType);
            Content.Add(streamContent, "form" , file.Name);

            string FileUrl = await FileRepository.Upload(Content);
            Author.Image = FileUrl;
        }

        private async Task SaveAuthor() {

            (bool status, string message) = await AuthorRepository.SaveAuthor(Author);

            IsSuccess = status;
            FormMessage = message;

            await JS.InvokeVoidAsync("window.scrollTo",new { top = 0, behavior = "smooth" });

            Author.Bio = "";
            Author.Name = "";
            Author.Image = "";
            Author.Country = "";

        }

    }
}
