using System;
using System.Linq;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SquidMeet.WebSite.Pages.Product
{
    /// <summary>
    /// Model to manage updating profile name information
    /// </summary>
    public class ProfileNameUpdateModel : PageModel
    {
        // Data middle tier 
        public JsonFileUserService UserService { get; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="userService"></param>
        public ProfileNameUpdateModel(JsonFileUserService userService)
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
        public IActionResult OnGet(string id)
        {
            UserProfile = UserService.GetUsers().FirstOrDefault(m => m.user_id.Equals(id));

            if (UserProfile == null)
            {
                return RedirectToPage("Profile", new { id = TempData["userId"] });
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
            if (UserProfile.name==null)
            {
                ModelState.AddModelError(string.Empty, " Invalid name input. Please input name");
                return Page();
             
            }

            UserService.UpdateUserName(UserProfile);

            return RedirectToPage("Profile", new { id = TempData["userId"] });
        }

    }
}
