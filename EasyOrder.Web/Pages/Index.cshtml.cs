using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;

namespace EasyOrder.Web.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    public AppSettings AppSettings { get;  }

    public IndexModel(ILogger<IndexModel> logger, IOptions<AppSettings> appSettigns)
    {
        _logger = logger;
        AppSettings = appSettigns.Value;
    }

    public void OnGet()
    {

    }
}

