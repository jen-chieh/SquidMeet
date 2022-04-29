using System.Linq;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SquidMeet.WebSite.Pages.NewGroup
{
    public class CreateNewGroupModel : PageModel
    {
        public JsonFileMeetupService MeetupService { get; }
        public JsonFileLocationService LocationService { get; }

        public CreateNewGroupModel(JsonFileMeetupService meetupService, JsonFileLocationService locationService)
        {
            this.MeetupService = meetupService;
            this.LocationService = locationService;
        }

        [BindProperty]
        public LocationModel selectedLocation { get; set; }


        public void OnGet(string Id)
        {
            selectedLocation = LocationService.GetAllData().FirstOrDefault(x => x.location_id == Id);
        }

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
