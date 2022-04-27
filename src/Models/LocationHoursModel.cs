using System.Text.Json;
using System.Text.Json.Serialization;

namespace ContosoCrafts.WebSite.Models
{

    /// <summary>
    /// Model for location_hours.json file. The model has a unique ID mapping back to a
    /// location in location.json, and displays all hours in military time in the below
    /// format: "(12:00-23:59)".
    /// </summary>
    public class LocationHoursModel
    {
        // Unique ID that maps to a location
        public string? location_hours_id { get; set; }
        // Hours that the location is open on monday
        public string? location_mon_hours { get; set; }
        // Hours that the location is open on tuesday
        public string? location_tues_hours { get; set; }
        // Hours that the location is open on wednesday
        public string? location_wed_hours { get; set; }
        // Hours that the location is open on thursday
        public string? location_thurs_hours { get; set; }
        // Hours that the location is open on friday
        public string? location_fri_hours { get; set; }
        // Hours that the location is open on saturday
        public string? location_sat_hours { get; set; }
        // Hours that the location is open on sunday
        public string? location_sun_hours { get; set; }

        public override string ToString() => JsonSerializer.Serialize<LocationHoursModel>(this);
    }
}
