using System.Collections.Generic;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContosoCrafts.WebSite.Controllers
{
    /// <summary>
    /// Create class from user.json file and retrieve all data from file.
    /// </summary>

    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="userService"></param>
        public UserController(JsonFileUserService userService) => 
            UserService = userService;

        // Data middle tier
        public JsonFileUserService UserService { get; }

        /// <summary>
        /// Get database information from model
        /// </summary>
        [HttpGet]
        public IEnumerable<UserModel> Get() => UserService.GetUsers();
    }
}
