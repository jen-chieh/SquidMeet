using System.Linq;

using Microsoft.AspNetCore.Mvc.RazorPages;

using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;

namespace ContosoCrafts.WebSite.Pages.Product
{
    public class ReadModel : PageModel
    {
        // Data middle tier
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

        /*
        // Data middle tier for location hours
        public JsonFileLocationHoursService LocationHoursService { get; }

        /// <summary>
        /// Defualt Construtor for location hours as parameter
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="locationHoursService"></param>
        public ReadModel(JsonFileLocationHoursService locationHoursService)
        {
            LocationHoursService = locationHoursService;
        }

        // The data to show for location hours
        public LocationHoursModel LocationHours;

        /// <summary>
        /// REST Get request for location hours
        /// </summary>
        /// <param name="id"></param>
        public void OnGetLocationHours(string id)
        {
            LocationHours = LocationHoursService.GetLocationHours().FirstOrDefault(m => m.location_hours_id.Equals(id));
        }*/
    }
}
