
namespace CatFactApp.Services
{
    public class FileService : IFileService
    {
        private readonly string _filePath;

        public FileService(IWebHostEnvironment environment)
        {
            string dataDirectory =
                Path.Combine(environment.ContentRootPath, "Data");

            Directory.CreateDirectory(dataDirectory);

            _filePath =
                Path.Combine(dataDirectory, "fact.txt");
        }

        public async Task SaveAsync(string text)
        {
            await File.AppendAllTextAsync(
                _filePath,
                text + Environment.NewLine
            );
        }
    }
}
