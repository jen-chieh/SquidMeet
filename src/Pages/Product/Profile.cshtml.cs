using System.Linq;

using Microsoft.AspNetCore.Mvc.RazorPages;

using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;

namespace ContosoCrafts.WebSite.Pages.Product
{
    public class ProfileModel : PageModel
    {
        // Data middle tier
        public JsonFileUserService ProductService { get; }

        /// <summary>
        /// Defualt Construtor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="productService"></param>
        public ProfileModel(JsonFileUserService productService)
        {
            ProductService = productService;
        }

        // The data to show
        public UserModel Product;
        public UserModel Product2;
        /// <summary>
        /// REST Get request
        /// </summary>
        /// <param name="id"></param>
        public void OnGet(string username)
        {
            Product = ProductService.GetUsers().FirstOrDefault(m => m.username.Equals(username));

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