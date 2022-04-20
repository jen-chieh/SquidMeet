using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;

namespace ContosoCrafts.WebSite.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MeetupController : Controller
    {
        public MeetupController(JsonFileMeetupService meetupService) =>
            MeetupService = meetupService;
        public JsonFileMeetupService MeetupService { get; }

        [HttpGet]
        public IEnumerable<Meetup> Get() => MeetupService.GetMeetups();
    }
}
