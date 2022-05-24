using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;

namespace ContosoCrafts.WebSite.Pages.Product
{
    /// <summary>
    /// Model to add a new location to the database
    /// </summary>
    public class CreateModel : PageModel
    {
        // Data middle tier
        public JsonFileLocationService ProductService { get; }
        // Data middle tier
        public JsonFileLocationHoursService LocationHoursService { get; }

        /// <summary>
        /// Defualt Construtor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="productService"></param>
        public CreateModel(JsonFileLocationService productService, JsonFileLocationHoursService locationHoursservice)
        {
            ProductService = productService;
            LocationHoursService = locationHoursservice;
        }

        // The data to show
        public LocationModel Product;

        // The data to show
        public LocationHoursModel locationHoursModel;

        /// <summary>
        /// REST Get request
        /// </summary>
        public IActionResult OnGet(LocationModel ProductModel)
        {
            return Page();
        }

        /// <summary>
        /// REST post request
        /// </summary>
        public IActionResult OnPost(LocationModel Product, LocationHoursModel locationHoursModel)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

           string id =  ProductService.CreateData(Product).location_id;

            LocationHoursService.CreateData(id, locationHoursModel);

            return RedirectToPage("../Index");
        }

    }
}
