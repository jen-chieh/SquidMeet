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
    /// Service for location.json file to fetch data from database
    /// </summary>
    public class JsonFileLocationService
    {
        public JsonFileLocationService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }
        public IWebHostEnvironment WebHostEnvironment { get; }

        // Get json path 
        private string JsonFileName => Path.Combine(WebHostEnvironment.WebRootPath, "data", "location.json");

        public IEnumerable<LocationModel> GetLocations()
        {
            using var jsonFileReader = File.OpenText(JsonFileName);

            return JsonSerializer.Deserialize<LocationModel[]>(jsonFileReader.ReadToEnd(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });


        }

        // Method to add a user rating to location
        public void AddRating(string locationId, int rating)
        {
            var locations = GetLocations();

            if (locations.First(x => x.location_id == locationId).rating == null)
            {
                locations.First(x => x.location_id == locationId).rating = new int[] { rating };
            }
            else
            {
                var ratings = locations.First(x => x.location_id == locationId).rating.ToList();
                ratings.Add(rating);
                locations.First(x => x.location_id == locationId).rating = ratings.ToArray();
            }

            using (var outputStream = File.OpenWrite(JsonFileName))
            {
                JsonSerializer.Serialize<IEnumerable<LocationModel>>(
                    new Utf8JsonWriter(outputStream, new JsonWriterOptions
                    {
                        SkipValidation = true,
                        Indented = true
                    }),
                    locations
                );
            }
        }

        /// <summary>
        /// Find the data record
        /// Update the fields
        /// Save to the data store
        /// </summary>
        /// <param name="data"></param>
        public LocationModel UpdateData(LocationModel data)
        {
            var locations = GetLocations();
            var locationData = locations.FirstOrDefault(x => x.location_id.Equals(data.location_id));
            if (locationData == null)
            {
                return null;
            }

            locationData.name = data.name;
            locationData.type_id = data.type_id;
            locationData.address = data.address;
            locationData.Image = data.Image;

            SaveData(locations);

            return locationData;
        }

        /// <summary>
        /// Save All location data to storage
        /// </summary>
        private void SaveData(IEnumerable<LocationModel> locations)
        {

            using (var outputStream = File.Create(JsonFileName))
            {
                JsonSerializer.Serialize<IEnumerable<LocationModel>>(
                    new Utf8JsonWriter(outputStream, new JsonWriterOptions
                    {
                        SkipValidation = true,
                        Indented = true
                    }),
                    locations
                );
            }
        }

        /// <summary>
        /// Create a new location using default values
        /// After create the user can update to set values
        /// Type_id set to 1
        /// </summary>
        /// <returns></returns>
        public LocationModel CreateData()
        {
            var data = new LocationModel()
            {
                location_id = System.Guid.NewGuid().ToString(),
                name = "Enter Name",
                address = "Enter Address",
                type_id = 1,
                Image = "",
            };

            // Get the current set, and append the new record to it because IEnumerable does not have Add function
            var dataSet = GetLocations();
            dataSet = dataSet.Append(data);

            SaveData(dataSet);

            return data;
        }

        /// <summary>
        /// Remove the item from the system
        /// </summary>
        /// <returns></returns>
        public LocationModel DeleteData(string id)
        {
            // Get the current set, and append the new record to it
            var dataSet = GetLocations();
            var data = dataSet.FirstOrDefault(m => m.location_id.Equals(id));

            var newDataSet = GetLocations().Where(m => m.location_id.Equals(id) == false);

            SaveData(newDataSet);

            return data;
        }

    
    }
}
