using System.Linq;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SquidMeet.WebSite.Pages.Product
{
    public class ProfileGenderUpdateModel : PageModel
    {
        public JsonFileUserService UserService { get; }

        public ProfileGenderUpdateModel(JsonFileUserService userService)
        {
            UserService = userService;
        }

        [BindProperty]
        public UserModel UserProfile { get; set; }
        public void OnGet(string id)
        {
            UserProfile = UserService.GetUsers().FirstOrDefault(m => m.user_id.Equals(id));

        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            UserService.UpdateUserGender(UserProfile);

            return RedirectToPage("../Index");
        }
    }
}
