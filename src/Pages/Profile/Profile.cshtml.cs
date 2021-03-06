using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ContosoCrafts.WebSite.Pages.Product
{
    /// <summary>
    /// Model to manage profile information
    /// </summary>
    public class ProfileModel : PageModel
    {
        // Data middle tier
        public JsonFileUserService ProductService { get; }

        /// <summary>
        /// Default Construtor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="productService"></param>
        public ProfileModel(JsonFileUserService productService)
        {
            ProductService = productService;
        }

        // The data to show
        public UserModel Product;

        /// <summary>
        /// REST Get request
        /// </summary>
        /// <param name="id"></param>
        public IActionResult OnGet(string id)
        {
        
            Product = ProductService.GetUsers().FirstOrDefault(m => m.user_id.Equals(id));

            if (Product == null || id ==null) {
                return RedirectToPage("../Authentication/Login");
            }
            return Page();
        }
        
    }
}
