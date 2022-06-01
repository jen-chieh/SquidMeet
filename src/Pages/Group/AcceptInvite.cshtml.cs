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
        /// <param name="meetupService"></param>
        /// <param name="userService"></param>
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
        /// <param name="Meetup"></param>
        /// <returns></returns>
        public IActionResult OnPost(MeetupModel Meetup)
        {
             MeetupModel mp = new MeetupModel
            {
                Host = "New title"
            };
          //  TempData["user"] = mp.Host;
           // TempData.Keep("user");

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Please enter a valid Invitation Code");
            }

            if (MeetupService.AddAttendee(mp, (string)TempData["user"]))
            {
                return RedirectToPage("ReadAllGroups");
            }

            return Page();
        }

    }
}
