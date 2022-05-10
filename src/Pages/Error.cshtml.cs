using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ContosoCrafts.WebSite.Pages
{
    /// <summary>
    /// Model to manage error pages
    /// </summary>
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public class ErrorModel : PageModel
    {
        // Unique ID for request
        public string? RequestId { get; set; }
        // Confirmation if requestID is null

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        // Logger for error page
        private readonly ILogger<ErrorModel> _logger;
        // Model initialized with error logger
        public ErrorModel(ILogger<ErrorModel> logger) => _logger = logger;

        public void OnGet() => RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
    }
}
