using System.Linq;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContosoCrafts.WebSite.Pages.Product
{
    /// <summary>
    /// Model to manage user authentication and handle invalid login attempts
    /// </summary>
    public class LoginModel : PageModel
    {
        // Data middle tier
        public JsonFileUserService ProductService { get; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="productService"></param>
        public LoginModel(JsonFileUserService productService)
        {
            ProductService = productService;
        }

        // The data to show
        [BindProperty]
        public bool checkAccount { get; set; }

        // The data to show
        [BindProperty]
        public UserModel User { get; set; }

        /// <summary>
        /// Post the model back to the page
        /// The model is in the class variable user
        /// Call the data layer to Update that data
        /// Then return to the profile page
        /// </summary>
        /// <returns></returns>
        public IActionResult OnPost(UserModel user)
        {
            
            // checked if account exist or not.
            checkAccount = ProductService.GetUsers().Any(m => m.email.Equals(user.email) && m.password.Equals(user.password));
            if (checkAccount == false)
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return Page();
            }

            User = ProductService.GetUsers().FirstOrDefault(m => m.email.Equals(user.email));

            //set email and id to TempData
            TempData["user"] = User.email;
            TempData["userId"] = User.user_id;

            //keep user and userId to TempData
            TempData.Keep("user");
            TempData.Keep("userId");

            //HttpContext.Session.SetString("Userid", User.email);

            return RedirectToPage("../Profile/Profile", new { id = User.user_id });
        }

    }
}
