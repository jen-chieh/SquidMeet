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
        public JsonFileMeetupService MeetupService { get; }

        public UpdateGroupModel(JsonFileMeetupService meetupService)
        {
            MeetupService = meetupService;
        }

        [BindProperty]
        public MeetupModel Group { get; set; }

        public void OnGet(string HostId)
        {
            Group = MeetupService.GetMeetups().First(g => g.Host == HostId);
        }

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
