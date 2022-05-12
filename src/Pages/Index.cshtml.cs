using System.Collections.Generic;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ContosoCrafts.WebSite.Pages
{
    /// <summary>
    /// Yucong Li
    /// Selina Hu
    /// JenChieh Lu
    /// Laharika Kalyani
    /// </summary>

    public class IndexModel : PageModel
    {
        /// <summary>
        /// Model for the index page displaying all locations
        /// </summary>
        
        // Data middle tier
        private readonly ILogger<IndexModel> _logger;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="productService"></param>
        public IndexModel(ILogger<IndexModel> logger,
            JsonFileLocationService productService)
        {
            _logger = logger;
            ProductService = productService;
        }

        // The data to show
        public JsonFileLocationService ProductService { get; }

        // Collection of the data to show
        public IEnumerable<LocationModel> Products { get; private set; }

        /// <summary>
        /// REST Get request
        /// </summary>
        public void OnGet()
        {
            Products = ProductService.GetAllData();
        }

    }
}
