using System.Linq;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SquidMeet.WebSite.Pages.NewGroup
{
    public class CreateNewGroupModel : PageModel
    {
        // Data middle tier  
        public JsonFileMeetupService MeetupService { get; }
        public JsonFileLocationService LocationService { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="meetupService"></param>
        /// <param name="locationService"></param>
        public CreateNewGroupModel(JsonFileMeetupService meetupService, JsonFileLocationService locationService)
        {
            this.MeetupService = meetupService;
            this.LocationService = locationService;
        }

        // Data model
        [BindProperty]
        public LocationModel selectedLocation { get; set; }

        // On get
        public void OnGet(string Id)
        {
            selectedLocation = LocationService.GetAllData().FirstOrDefault(x => x.location_id == Id);
        }

        // On post
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            LocationService.UpdateData(selectedLocation);

            return RedirectToPage("../Index");
        }
    }
}
