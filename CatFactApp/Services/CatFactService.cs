using CatFactApp.Models;
using System.Text.Json;

namespace CatFactApp.Services
{
    public class CatFactService : ICatFactService
    {
        private readonly HttpClient _httpClient;
        private readonly IFileService _fileService;
  
        public CatFactService(HttpClient httpClient, IFileService fileService)
        {
            _httpClient = httpClient;
            _fileService = fileService;
        }

        public async Task<CatFact?> GetFactAsync()
        {
            var response =
           await _httpClient.GetAsync("fact");

            response.EnsureSuccessStatusCode();

            string json =
                await response.Content.ReadAsStringAsync();

            CatFact? catFact =
                JsonSerializer.Deserialize<CatFact>(json);

            if (catFact != null)
            {
                string line =
                    $"{catFact.Fact} | Length: {catFact.Length}";

                await _fileService.SaveAsync(line);
            }



            return catFact;
        }
    }
}
