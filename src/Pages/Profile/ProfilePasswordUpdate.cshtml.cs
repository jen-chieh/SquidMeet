using System.Linq;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SquidMeet.WebSite.Pages.Product
{
    public class ProfilePasswordUpdateModel : PageModel
    {
        // Data middle tier 
        public JsonFileUserService UserService { get; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="userService"></param>
        public ProfilePasswordUpdateModel(JsonFileUserService userService)
        {
            UserService = userService;
        }

        // The data to show, bind to it for the post
        [BindProperty]
        public UserModel UserProfile { get; set; }

        /// <summary>
        /// REST Get request
        /// </summary>
        /// <param name="id"></param>
        public void OnGet(string id)
        {
            UserProfile = UserService.GetUsers().FirstOrDefault(m => m.user_id.Equals(id));
        }

        /// <summary>
        /// REST Post request
        /// </summary>
        /// <returns></returns>
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            UserService.UpdateUserPassword(UserProfile);

            return RedirectToPage("../Index");
        }

    }
}
