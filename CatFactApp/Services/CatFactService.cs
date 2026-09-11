using CatFactApp.Models;
using System.Text.Json;

namespace CatFactApp.Services
{
    public class CatFactService : ICatFactService
    {
        private readonly HttpClient _httpClient;
  
        public CatFactService(HttpClient httpClient)
        {
            _httpClient = httpClient;
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

            return catFact;
        }
    }
}
