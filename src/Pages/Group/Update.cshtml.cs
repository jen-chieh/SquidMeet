using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using System.Collections.Generic;

namespace SquidMeet.WebSite.Pages.Group
{
    /// <summary>
    /// Model to update group information
    /// </summary>
    public class MeetupUpdateModel : PageModel
    {
        // Data middle tier
        public JsonFileMeetupService ProductService { get; }

        /// <summary>
        /// Defualt Construtor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="productService"></param>
        public MeetupUpdateModel(JsonFileMeetupService productService)
        {
            ProductService = productService;
        }

        // The data to show, bind to it for the post
        [BindProperty]
        public MeetupModel Product { get; set; }

        /// <summary>
        /// REST Get request
        /// Loads the Data
        /// </summary>
        /// <param name="id"></param>
        public IActionResult OnGet(string id)
        {
            Product = ProductService.GetMeetups().FirstOrDefault(m => m.meetup_id.Equals(id));
            
            if (Product == null)
            {
                return RedirectToPage("ViewMyGroup", new { id = TempData["user"] });
            }
            return Page();

        }

        /// <summary>
        /// Post the model back to the page
        /// The model is in the class variable Product
        /// Call the data layer xto Update that data
        /// Then return to the ViewMyGroup page
        /// </summary>
        /// <returns></returns>
        public IActionResult OnPost()
        {

            if (Product.Attendees == null || Product.Attendees.Count() == 0)
            {
                Product.Attendees = new List<StatusModel>();
            }
            ProductService.UpdateMeetup(Product);
            return RedirectToPage("/Group/ViewMyGroup", new { id = TempData["user"] });

        }
    }
}
