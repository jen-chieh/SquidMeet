using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using ContosoCrafts.WebSite.Models;
using Microsoft.AspNetCore.Hosting;
namespace ContosoCrafts.WebSite.Services
{
    /// <summary>
    /// Create class from meetup.json file and retrieve all data from file.
    /// </summary>
    public class JsonFileMeetupService
    {
        // Initialize class
        public JsonFileMeetupService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }
        // Data middle tier
        public IWebHostEnvironment WebHostEnvironment { get; }

        // Get json file path

        private string JsonFileName => Path.Combine(WebHostEnvironment.WebRootPath, "data", "meetup.json");

        // Read .json file and return all data fields through the model
        public IEnumerable<MeetupModel> GetMeetups()
        {
            using var jsonFileReader = File.OpenText(JsonFileName);

            return JsonSerializer.Deserialize<MeetupModel[]>(jsonFileReader.ReadToEnd(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
        }
    }
}
