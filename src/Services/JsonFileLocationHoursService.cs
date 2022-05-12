using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using ContosoCrafts.WebSite.Models;
using Microsoft.AspNetCore.Hosting;

namespace ContosoCrafts.WebSite.Services
{
    /// <summary>
    /// Create class from location_hours.json file and retrieve all data from file.
    /// </summary>
    public class JsonFileLocationHoursService
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="webHostEnvironment"></param>
        public JsonFileLocationHoursService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        // Data middle tier
        public IWebHostEnvironment WebHostEnvironment { get; }

        // Get json file path
        private string JsonFileName => Path.Combine(WebHostEnvironment.WebRootPath, "data", "location_hours.json");

        /// <summary>
        /// Read .json file and return all data fields through the model
        /// </summary>
        public IEnumerable<LocationHoursModel> GetLocationHours()
        {
            using var jsonFileReader = File.OpenText(JsonFileName);

            return JsonSerializer.Deserialize<LocationHoursModel[]>(jsonFileReader.ReadToEnd(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

        }

    }
}
