using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContosoCrafts.WebSite.Pages.Product
{
    /// <summary>
    /// Index Page will return all the data to show
    /// </summary>
    public class IndexModel : PageModel
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="productService"></param>
        public IndexModel(JsonFileLocationService productService)
        {
            ProductService = productService;
        }

        // Data middle tier
        public JsonFileLocationService ProductService { get; }
        
        // Collection of the Data
        public IEnumerable<LocationModel> Products { get; private set; }

        // location_id 
        [BindProperty]
        public int Id { get; set; }

        /// <summary>
        /// REST OnGet, return all data
        /// </summary>
        public void OnGet()
        {
            Products = ProductService.GetAllData();
        }

        /// <summary>
        /// REST OnPost, delete Location
        /// </summary>
        public IActionResult OnPost(string Id)
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }

            ProductService.DeleteData(Id);

            return RedirectToPage("./Index");
        }
    }
}
