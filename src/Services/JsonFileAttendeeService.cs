using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using ContosoCrafts.WebSite.Models;
using Microsoft.AspNetCore.Hosting;

namespace ContosoCrafts.WebSite.Services
{
    public class JsonFileAttendeeService
    {
        public JsonFileAttendeeService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }
        public IWebHostEnvironment WebHostEnvironment { get; }

        private string JsonFileAttendeeName => Path.Combine(WebHostEnvironment.WebRootPath, "data", "attendees.json");

        public IEnumerable<Attendee> GetAttendees()
        {
            using var jsonFileReader = File.OpenText(JsonFileAttendeeName);

            return JsonSerializer.Deserialize<Attendee[]>(jsonFileReader.ReadToEnd(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
        }
    }
}