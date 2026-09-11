using CatFactApp.Services;
using CatFactApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CatFactApp.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly ICatFactService _catFactService;
    public CatFact? CatFact { get; set; }

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
        CatFact = await _catFactService.GetFactAsync();
    }
}

