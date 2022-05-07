using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using ContosoCrafts.WebSite.Models;
using Microsoft.AspNetCore.Hosting;
namespace ContosoCrafts.WebSite.Services
{
    /// <summary>
    /// Create class from location_type.json file and retrieve all data from file.
    /// </summary>
    public class JsonFileLocationTypeService
    {
        // Initialize class
        public JsonFileLocationTypeService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }
        // Data middle tier
        public IWebHostEnvironment WebHostEnvironment { get; }

        // Get json path 
        private string JsonFileName => Path.Combine(WebHostEnvironment.WebRootPath, "data", "location_type.json");

        // Read .json file and return all data fields through the model
        public IEnumerable<LocationTypeModel> GetLocationTypes()
        {
            using var jsonFileReader = File.OpenText(JsonFileName);

            return JsonSerializer.Deserialize<LocationTypeModel[]>(jsonFileReader.ReadToEnd(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });


        }
    }
}
