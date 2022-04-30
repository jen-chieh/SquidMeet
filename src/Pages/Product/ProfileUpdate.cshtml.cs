using System.Linq;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace SquidMeet.WebSite.Pages.Product
{
    public class ProfileUpdateModel : PageModel
    {
        public JsonFileUserService UserService { get; }

        public ProfileUpdateModel(JsonFileUserService userService)
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

            UserService.UpdateUser(UserProfile);

            return RedirectToPage("../Index");
        }

    }
}
