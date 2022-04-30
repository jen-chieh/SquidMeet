using System.Linq;

using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;

namespace ContosoCrafts.WebSite.Pages.Product
{
    /// <summary>
    /// Manage the Update of the user data for a single record
    /// </summary>
    public class CreateUserModelModel : PageModel
    {
        // Data middletier
        public JsonFileUserService ProductService { get; }

        /// <summary>
        /// Defualt Construtor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="productService"></param>
        public CreateUserModelModel(JsonFileUserService productService)
        {
            ProductService = productService;
            //  Product  = ProductService.GetAllData().FirstOrDefault(m => m.location.Equals(id));
            // Product = ProductService.GetUsers().FirstOrDefault(m => m.user_id.Equals(id));


            /// <summary>
            /// Post the model back to the page
            /// The model is in the class variable Product
            /// Call the data layer to Update that data
            /// Then return to the index page
            /// </summary>
            /// <returns></returns>
        }

        // The data to show
        public UserModel Product;

        /// <summary>
        /// REST Post request
        /// </summary>
        public IActionResult OnPost()
        {

            ProductService.CreateUser();

            return RedirectToPage("../Index");
        }
    }
}
