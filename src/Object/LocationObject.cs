using System;
using ContosoCrafts.WebSite.Models;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
namespace ContosoCrafts.WebSite.Object
{
    public class LocationObject
    {
        public LocationObject(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }
        public IWebHostEnvironment WebHostEnvironment { get; }


        //getting json path
        private string JsonFileName => Path.Combine(WebHostEnvironment.WebRootPath, "data", "Location.json");

        public IEnumerable<Location> GetAllLocations()
        {
            using var jsonFileReader = File.OpenText(JsonFileName);
            IEnumerable<Location> LocationList = JsonSerializer.Deserialize<Location[]>(jsonFileReader.ReadToEnd(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

            var selectResult = from s in LocationList
                               select new {s.location_id,s.name,s.type_id,s.address,s.Image,s.rating};

            //return objectList
            return (IEnumerable<Location>)selectResult;
        }

    }
}