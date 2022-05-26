using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContosoCrafts.WebSite.Pages.Product
{
    /// <summary>
    /// Model to manage user authentication and handle invalid login attempts
    /// </summary>
    public class LogoutModel : PageModel
    {
        // Data middle tier
        public JsonFileUserService ProductService { get; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="productService"></param>
        public LogoutModel(JsonFileUserService productService)
        {
            ProductService = productService;
        }

        /// <summary>
        /// Get UserId from TempData
        /// delete user when logout
        /// delete userId when logout
        /// return Login page
        /// </summary>
        /// <returns></returns>
        public IActionResult OnGet()
        {
            // Logout and return to Login page
            TempData.Keep("user");
            TempData.Keep("userId");
            TempData["user"] = null;
            TempData["userId"] = null;
         
            return RedirectToPage("Login");
        }

    }
}
