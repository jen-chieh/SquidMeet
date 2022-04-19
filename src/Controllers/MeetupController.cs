using System.Collections.Generic;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc;

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