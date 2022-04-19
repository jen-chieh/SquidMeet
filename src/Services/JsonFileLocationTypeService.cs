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
        public JsonFileLocationTypeService()
        {
        }
        public IWebHostEnvironment WebHostEnvironment { get; }

        // Get json path 
        private string JsonFileName => Path.Combine(WebHostEnvironment.WebRootPath, "data", "location_type.json");

        public IEnumerable<LocationType> GetLocationTypes()
        {
            using var jsonFileReader = File.OpenText(JsonFileName);

            return JsonSerializer.Deserialize<LocationType[]>(jsonFileReader.ReadToEnd(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });


        }
    }
}
