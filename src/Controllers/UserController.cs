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
        public UserController(JsonFileUserService userService) => 
            UserService = userService;

        public JsonFileUserService UserService { get; }

        [HttpGet]
        public IEnumerable<UserModel> Get() => UserService.GetUsers();

    }
}
