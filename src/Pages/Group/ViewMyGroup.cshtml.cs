using System.Collections.Generic;
using System.Linq;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SquidMeet.WebSite.Pages.Group
{
    /// <summary>
    /// This is the model for the update group page
    /// </summary>
    public class UpdateGroupModel : PageModel
    {
        // Data middle tier
        public JsonFileMeetupService MeetupService { get; }

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="meetupService"></param>
        public UpdateGroupModel(JsonFileMeetupService meetupService)
        {
            MeetupService = meetupService;
        }

        /// The data to show, bind to it for the post

        public IEnumerable<MeetupModel> Groups
        { get; private set; }
        /// <summary>
        /// REST Get request
        /// Loads the Data
        /// </summary>
        /// <param name="HostId"></param>
        public IActionResult OnGet(string id)
        {
            Groups = MeetupService.GetMeetups().Where(g => g.Host == id || (g.Attendees != null && g.Attendees.Where(a => a.user.Contains(id)).Any()));

            if (Groups.ToArray().Length == 0)
            {
                return RedirectToPage("../Index");
            }
            return Page();

        }

        /// <summary>
        /// Post the model back to the page
        /// The model is in the class variable Group
        /// Call the data layer to Update that data
        /// Then return to the Index page
        /// </summary>
        /// <returns></returns>
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            return RedirectToPage("../Index");
        }

    }
}
