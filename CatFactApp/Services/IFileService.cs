namespace CatFactApp.Services
{
    public interface IFileService
    {
        Task SaveAsync(string text);
    }
}
