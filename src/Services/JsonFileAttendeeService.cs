using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using ContosoCrafts.WebSite.Models;
using Microsoft.AspNetCore.Hosting;

namespace ContosoCrafts.WebSite.Services
{
    /// <summary>
    /// Create class from attendee.json file and retrieve all data from file.
    /// </summary>
    
    public class JsonFileAttendeeService
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="webHostEnvironment"></param>
        public JsonFileAttendeeService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        // Data middle tier
        public IWebHostEnvironment WebHostEnvironment { get; }

        // Get json file path 
        private string JsonFileAttendeeName => Path.Combine(WebHostEnvironment.WebRootPath, "data", "attendees.json");

        /// <summary>
        /// Read .json file and return all data fields through the model
        /// </summary>
        public IEnumerable<AttendeeModel> GetAttendees()
        {
            using var jsonFileReader = File.OpenText(JsonFileAttendeeName);

            return JsonSerializer.Deserialize<AttendeeModel[]>(jsonFileReader.ReadToEnd(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
        }

    }
}
