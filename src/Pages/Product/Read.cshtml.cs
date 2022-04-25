using System.Linq;

using Microsoft.AspNetCore.Mvc.RazorPages;

using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;

namespace ContosoCrafts.WebSite.Pages.Product
{
    public class ReadModel : PageModel
    {
        // Data middletier
        public JsonFileLocationService ProductService { get; }

        /// <summary>
        /// Defualt Construtor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="productService"></param>
        public ReadModel(JsonFileLocationService productService)
        {
            ProductService = productService;
        }

        // The data to show
        public LocationModel Product;

        /// <summary>
        /// REST Get request
        /// </summary>
        /// <param name="id"></param>
        public void OnGet(string id)
        {
            Product  = ProductService.GetAllData().FirstOrDefault(m => m.location_id.Equals(id));
        }
    }
}
