namespace BookManager.Application.Interface
{
    public interface IFileRepository
    {
        public Task<string> Upload(MultipartFormDataContent? fileContent); 
    }
}
