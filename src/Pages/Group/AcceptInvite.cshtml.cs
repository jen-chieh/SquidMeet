using System.Linq;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SquidMeet.WebSite.Pages.Group
{
    public class AcceptInviteModel : PageModel
    {
        public JsonFileMeetupService MeetupService { get; }
        public JsonFileUserService UserService { get; }

        public AcceptInviteModel(JsonFileMeetupService meetupService, JsonFileUserService userService)
        {
            UserService = userService;

            MeetupService = meetupService;
        }

        [BindProperty]
        public MeetupModel Meetup { get; set; }

        [BindProperty]
        public UserModel User { get; set; }


        public void OnGet(string id)
        {
            User = UserService.GetUsers().FirstOrDefault(m => m.user_id.Equals(id));
        }

        public IActionResult OnPost(MeetupModel Meetup)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }


            MeetupService.AddAttendee(Meetup, "Azkaban");


            return RedirectToPage("ViewMyGroup");
        }
    }
}
