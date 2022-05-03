using System.Linq;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SquidMeet.WebSite.Pages.Group
{
    /// <summary>
    /// This is the  model for the update group page.
    /// </summary>
    public class UpdateGroupModel : PageModel
    {
        // 
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
        [BindProperty]
        public MeetupModel Group { get; set; }

        public void OnGet(string HostId)
        {
            Group = MeetupService.GetMeetups().First(g => g.Host == HostId);
        }

        /// <summary>
        /// REST Get request
        /// Loads the Data
        /// </summary>
        /// <param name="HostId"></param>
        /// s>
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
