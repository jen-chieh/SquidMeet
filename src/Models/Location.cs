using System.Text.Json;
using System.Text.Json.Serialization;

namespace ContosoCrafts.WebSite.Models
{
    /// <summary>
    /// Model for location.json file. The model has a unique location_id for each location in
    /// location.json, and displays the name, address and image of the location".
    /// </summary>
    public class Location
    {
        // Unique location id for meetups
        public string? location_id { get; set; }
        // location name
        public string? name { get; set; }
        // location type maps to the type in LocationTypes
        public int type_id { get; set; }
        // location address
        public string? address { get; set; }
        // location image url
        [JsonPropertyName("img")]
        public string? Image { get; set; }
        // location ratings
        public int[]? rating { get; set; }

        public override string ToString() => JsonSerializer.Serialize<Location>(this);
    }
}
