
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;

namespace ContosoCrafts.WebSite.Pages.Product
{
    public class CreateModel : PageModel
    {
        // Data middle tier
        public JsonFileLocationService ProductService { get; }

        /// <summary>
        /// Defualt Construtor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="productService"></param>
        public CreateModel(JsonFileLocationService productService)
        {
            ProductService = productService;
        }

        // The data to show
        public LocationModel Product;

        /// <summary>
        /// REST Get request
        /// </summary>
        public IActionResult OnGet()
        {
            Product  = ProductService.CreateData();

            return RedirectToPage("./Update", new { Id = Product.location_id });
        }
    }
}
