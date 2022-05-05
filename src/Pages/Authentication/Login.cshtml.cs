using System.Linq;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContosoCrafts.WebSite.Pages.Product
{
    public class LoginModel : PageModel
    {
        // Data middle tier
        public JsonFileUserService ProductService { get; }

        /// <summary>
        /// Defualt Construtor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="productService"></param>
        public LoginModel(JsonFileUserService productService)
        {
            ProductService = productService;
        }
        [BindProperty]
        public bool checkAccount { get; set; }

        [BindProperty]
        public UserModel User { get; set; }

        // The data to show
        /// <summary>
        /// REST Get request
        /// </summary>
        /// <param name="id"></param>
        public void OnGet(string id)
        {
            User = ProductService.GetUsers().FirstOrDefault(m => m.user_id.Equals(id));
        }
        // On post
        public IActionResult OnPost()
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //};
            // checked if account exist or not.
            checkAccount = ProductService.GetUsers().Any(m => m.email.Equals(User.email) && m.password.Equals(User.password));
            if (checkAccount == false)
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return Page();
            }

            User = ProductService.GetUsers().FirstOrDefault(m => m.email.Equals(User.email));
            HttpContext.Session.SetString("Userid", User.user_id);
            return RedirectToPage("../Profile/Profile", new { id = User.user_id });

        }

    }
}
