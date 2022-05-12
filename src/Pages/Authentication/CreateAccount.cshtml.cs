
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContosoCrafts.WebSite.Pages.Product
{
    /// <summary>
    /// Manage the Update of the user data for a single record
    /// </summary>
    public class CreateUserModelModel : PageModel
    {
        // Data middle tier
        public JsonFileUserService ProductService { get; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="productService"></param>
        public CreateUserModelModel(JsonFileUserService productService)
        {
            ProductService = productService;
        }

        // The data to show
        [BindProperty]
        public UserModel User { get; set; }

        /// <summary>
        /// Post the model back to the page
        /// The model is in the class variable Product
        /// Call the data layer to Update that data
        /// Then return to the index page
        /// </summary>
        /// <returns></returns>
        public IActionResult OnPost(UserModel User)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            ProductService.CreateUser(User);

            return RedirectToPage("../Index");
        }

    }
}
