using CatFactApp.Models;
using CatFactApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace CatFactApp.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly ICatFactService _catFactService;
    public CatFact? CatFact { get; set; }
    public string? ErrorMessage { get; set; }

    public IndexModel(ILogger<IndexModel> logger, ICatFactService catFactService)
    {
        _logger = logger;
        _catFactService = catFactService;

    }

    public void OnGet()
    {

    }

    public async Task OnPostAsync()
    {
        try
        {
            CatFact = await _catFactService.GetFactAsync();
        }
        catch (HttpRequestException ex)
        {
            _logger.LogError(ex, "Error while retrieving cat fact from API.");
            ErrorMessage = "Nie uda³o siê pobraæ faktu z API. Spróbuj ponownie.";
        }
        catch (JsonException ex)
        {
            _logger.LogError(ex, "Error while deserializing API response.");
            ErrorMessage = "Otrzymano nieprawid³owe dane z API.";
        }
        catch (IOException ex)
        {
            _logger.LogError(ex, "Error while saving cat fact to file.");
            ErrorMessage = "Nie uda³o siê zapisaæ faktu do pliku.";
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unexpected error while processing cat fact.");
            ErrorMessage = "Wyst¹pi³ nieoczekiwany b³¹d.";
        }

    }
}

