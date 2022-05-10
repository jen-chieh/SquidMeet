using System.Linq;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SquidMeet.WebSite.Pages.Group
{
    /// <summary>
    /// Model to handle accepting or rejecting meetup invitations from other
    /// users that updates database information accordingly.
    /// </summary>
    public class AcceptInviteModel : PageModel
    {
        // Data middle tier
        public JsonFileMeetupService MeetupService { get; }
        // Data middle tier
        public JsonFileUserService UserService { get; }

        /// <summary>
        /// Defualt Construtor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="meetupService, userService"></param>
        public AcceptInviteModel(JsonFileMeetupService meetupService, JsonFileUserService userService)
        {
            UserService = userService;

            MeetupService = meetupService;
        }

        // The data to show, bind to it for the post
        [BindProperty]
        public MeetupModel Meetup { get; set; }

        // The data to show, bind to it for the post
        [BindProperty]
        public UserModel User { get; set; }

        /// <summary>
        /// REST Get request
        /// </summary>
        /// <param name="id"></param>
        public void OnGet(string id)
        {
            User = UserService.GetUsers().FirstOrDefault(m => m.user_id.Equals(id));
        }

        /// <summary>
        /// Post the model back to the page
        /// The model is in the class variable Meetup
        /// Call the data layer to Update that data
        /// Then return to the ViewMyGroup page
        /// </summary>
        /// <returns></returns>
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
