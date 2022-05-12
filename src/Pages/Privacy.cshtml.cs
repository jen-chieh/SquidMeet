using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ContosoCrafts.WebSite.Pages
{
    /// <summary>
    /// Model for privacy page
    /// </summary>
    public class PrivacyModel : PageModel
    {
        // Data middle tier
        private readonly ILogger<PrivacyModel> _logger;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="logger"></param>
        public PrivacyModel(ILogger<PrivacyModel> logger) => _logger = logger;

        /// <summary>
        /// REST Get request
        /// </summary>
        public void OnGet()
        {
        }

    }
}
