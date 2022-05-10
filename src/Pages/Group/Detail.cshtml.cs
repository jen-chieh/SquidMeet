using System.Linq;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SquidMeet.WebSite.Pages.Group
{
    /// <summary>
    /// Model for showing meetup details 
    /// </summary>
    public class DetailModel : PageModel
    {
        // Data middle tier service
        public JsonFileMeetupService MeetupService { get; }

        /// <summary>
        /// Defualt Construtor
        /// </summary>
        /// <param name="meetupService"></param>
        public DetailModel(JsonFileMeetupService meetupService)
        {
            MeetupService = meetupService;
        }

        // The data to show
        public MeetupModel Meetup;

        /// <summary>
        /// REST Get request
        /// </summary>
        /// <param name="id"></param>
        public void OnGet(string id)
        {
            Meetup = MeetupService.GetMeetups().FirstOrDefault(g => g.meetup_id == id);
        }
    }
}
