﻿using System.Linq;

using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;

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
        public void OnGet(string id)
        {
            Product = ProductService.GetMeetups().FirstOrDefault(m => m.meetup_id.Equals(id));
        }

        /// <summary>
        /// Post the model back to the page
        /// The model is in the class variable Product
        /// Call the data layer to Update that data
        /// Then return to the ViewMyGroup page
        /// </summary>
        /// <returns></returns>
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            ProductService.UpdateMeetup(Product);

            return RedirectToPage("./ViewMyGroup");
        }

    }
}
