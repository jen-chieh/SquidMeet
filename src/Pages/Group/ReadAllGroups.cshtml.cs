using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SquidMeet.WebSite.Pages.Group
{
    /// <summary>
    /// Read all groups
    /// </summary>
    public class ReadAllGroupModel : PageModel
    {
        // Data middletier
        public JsonFileMeetupService ProductService { get; }

        /// <summary>
        /// Defualt Construtor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="productService"></param>
        public ReadAllGroupModel(JsonFileMeetupService productService)
        {
            ProductService = productService;
        }

      
      
        // On get
        public void OnGet()
        {
        }
    }
}
