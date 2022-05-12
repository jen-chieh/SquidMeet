using System.Linq;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SquidMeet.WebSite.Pages.NewGroup
{
    /// <summary>
    /// Model for creating a new group and linking it to a location in the database
    /// </summary>
    public class CreateNewGroupModel : PageModel
    {
        // Data middle tier  
        public JsonFileMeetupService MeetupService { get; }

        // Data middle tier  
        public JsonFileLocationService LocationService { get; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="meetupService"></param>
        /// <param name="locationService"></param>
        public CreateNewGroupModel(JsonFileMeetupService meetupService, JsonFileLocationService locationService)
        {
            this.MeetupService = meetupService;
            this.LocationService = locationService;
        }

        // The data to show, bind to it for the post
        [BindProperty]
        public LocationModel location { get; set; }

        // The data to show, bind to it for the post
        [BindProperty]
        public MeetupModel newMeetup { get; set; }

        /// <summary>
        /// REST Get request
        /// </summary>
        /// <param name="locationid"></param>
        public void OnGet(string locationId)
        {
            location = LocationService.GetAllData().FirstOrDefault(x => x.location_id == locationId);

        }

        /// <summary>
        /// Post the model back to the page
        /// The model is in the class variable newMeetup
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

            MeetupService.Create(newMeetup);
            return RedirectToPage("../Index");
        }

    }
}
