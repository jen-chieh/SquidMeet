using System.Collections.Generic;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContosoCrafts.WebSite.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        // Initialize user controller
        public UserController(JsonFileUserService userService) => 
            UserService = userService;

        // Data middle tier
        public JsonFileUserService UserService { get; }

        // Get user information from model
        [HttpGet]
        public IEnumerable<UserModel> Get() => UserService.GetUsers();

    }
}
