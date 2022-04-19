using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using ContosoCrafts.WebSite.Models;
using Microsoft.AspNetCore.Hosting;

namespace ContosoCrafts.WebSite.Services
{
    /// <summary>
    /// Create class from users.json file and retrieve all data from file.
    /// </summary>
    public class JsonFileUserService
    {
        // Initialize class
        public JsonFileUserService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        // Data middle tier
        public IWebHostEnvironment WebHostEnvironment { get; }

        // Get json file path 
        private string JsonFileName => Path.Combine(WebHostEnvironment.WebRootPath, "data", "users.json");

        // Read .json file and return all data fields through the model
        public IEnumerable<UserModel> GetUsers()
        {
            using var jsonFileReader = File.OpenText(JsonFileName);

            return JsonSerializer.Deserialize<UserModel[]>(jsonFileReader.ReadToEnd(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });        
        }

    }
}
