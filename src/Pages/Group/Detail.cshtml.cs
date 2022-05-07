using System.Linq;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SquidMeet.WebSite.Pages.Group
{
    public class DetailModel : PageModel
    {
        // Data middle tier service
        public JsonFileMeetupService MeetupService { get; }


        public DetailModel(JsonFileMeetupService meetupService)
        {
            MeetupService = meetupService;
        }

        public MeetupModel Meetup;
        public void OnGet(string id)
        {
            Meetup = MeetupService.GetMeetups().FirstOrDefault(g => g.meetup_id == id);
        }
    }
}
