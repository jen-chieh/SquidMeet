using System.Text.Json;
using System.Text.Json.Serialization;

namespace ContosoCrafts.WebSite.Models

/// <summary>
/// Model for location_model.json file. The model has a unique ID mapping back to a
/// location in location.json
/// </summary>
{
    public class LocationModel
    {
        //Unique Id assign to location
        public string? location_id { get; set; }
        // Name of the location
        public string? name { get; set; }
        // the type of location Id to connect locationType.json 
        public string? type_id { get; set; }
        // Address of Location 
        public string? address { get; set; }
        [JsonPropertyName("img")]
        //Image of location 
        public string? img { get; set; }
        // rating for Location for sorting and filtering.
        public int[]? rating { get; set; }

        public override string ToString() => JsonSerializer.Serialize<LocationModel>(this);

 
    }
}
