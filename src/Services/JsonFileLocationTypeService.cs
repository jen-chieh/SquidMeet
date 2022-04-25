using System;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using ContosoCrafts.WebSite.Models;
using Microsoft.AspNetCore.Hosting;
namespace ContosoCrafts.WebSite.Services
{
    public class JsonFileLocationTypeService
    {
        public JsonFileLocationTypeService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }
        public IWebHostEnvironment WebHostEnvironment { get; }

        // Get json path 
        private string JsonFileName => Path.Combine(WebHostEnvironment.WebRootPath, "data", "location_type.json");

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
