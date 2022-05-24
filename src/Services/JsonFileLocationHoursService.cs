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
    /// Create class from location_hours.json file and retrieve all data from file.
    /// </summary>
    public class JsonFileLocationHoursService
    {
        public JsonFileLocationHoursService()
        {
        }

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

        /// <summary>
        /// Save All products data to storage
        /// </summary>
        /// <param name="products"></param>
        public void SaveData(IEnumerable<LocationHoursModel> locationhours)
        {

            using (var outputStream = File.Create(JsonFileName))
            {
                JsonSerializer.Serialize<IEnumerable<LocationHoursModel>>(
                    new Utf8JsonWriter(outputStream, new JsonWriterOptions
                    {
                        SkipValidation = true,
                        Indented = true
                    }),
                    locationhours
                );
            }
        }

        /// <summary>
        /// Create a new locationHours using default values
        /// After create the user can update to set values
        /// </summary>
        /// <returns></returns>
        public LocationHoursModel CreateData( String id,LocationHoursModel locationHours)
        {
            string tempHours = "Hours not set";

            if (locationHours.location_mon_hours == null)
            {
                locationHours.location_mon_hours = tempHours;
            }

            if (locationHours.location_tues_hours == null)
            {
                locationHours.location_tues_hours = tempHours;
            }

            if (locationHours.location_wed_hours == null)
            {
                locationHours.location_wed_hours = tempHours;
            }

            if (locationHours.location_thurs_hours == null)
            {
                locationHours.location_thurs_hours = tempHours;
            }

            if (locationHours.location_fri_hours == null)
            {
                locationHours.location_fri_hours = tempHours;
            }

            if (locationHours.location_sat_hours == null)
            {
                locationHours.location_sat_hours = tempHours;
            }

            if (locationHours.location_sun_hours == null)
            {
                locationHours.location_sun_hours = tempHours;
            }

            var datahours = new LocationHoursModel()
            {
                location_hours_id = id,
                location_mon_hours = locationHours.location_mon_hours,
                location_tues_hours = locationHours.location_tues_hours,
                location_wed_hours = locationHours.location_wed_hours,
                location_thurs_hours = locationHours.location_thurs_hours,
                location_fri_hours = locationHours.location_fri_hours,
                location_sat_hours = locationHours.location_sat_hours,
                location_sun_hours = locationHours.location_sun_hours,

            };

            // get the currrent locationhours set and append the new record to it
            var hoursDataset = GetLocationHours();
            hoursDataset = hoursDataset.Append(datahours);
            SaveData(hoursDataset);
            return datahours;
        }


    }
}
