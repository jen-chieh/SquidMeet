using System.Linq;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SquidMeet.WebSite.Pages.Product
{
    /// <summary>
    /// Model to manage updating profile age information
    /// </summary>
    public class ProfileAgeUpdateModel : PageModel
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="userService"></param>
        public ProfileAgeUpdateModel(JsonFileUserService userService)
        {
            UserService = userService;
        }

        // Data middle tier 
        public JsonFileUserService UserService { get; }

        // The data to show, bind to it for the post
        [BindProperty]
        public UserModel UserProfile { get; set; }

        /// <summary>
        /// REST Get request
        /// </summary>
        /// <param name="id"></param>
        public IActionResult OnGet(string id)
        {
            UserProfile = UserService.GetUsers().FirstOrDefault(m => m.user_id.Equals(id));

            if (UserProfile == null)
            {
                return RedirectToPage("Profile", new { id = TempData["userId"]});
            }
            return Page();

        }

        /// <summary>
        /// Post the model back to the page
        /// The model is in the class variable UserProfile
        /// Call the data layer to Update that data
        /// Then return to the Profile page
        /// </summary>
        /// <returns></returns>
        public IActionResult OnPost(UserModel UserProfile)
        {
            if (UserProfile.age == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid age input. Please input age");
                return Page();

            }

            UserService.UpdateUserAge(UserProfile);

            return RedirectToPage("Profile", new { id = UserProfile.user_id });
        }

    }
}
