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
        public string? location_id { get; set; }
        public string? name { get; set; }
        public int type_id { get; set; }
        public string? address { get; set; }
        [JsonPropertyName("img")]
        public string? Image { get; set; }
      
        public int[]? rating { get; set; }

        public override string ToString() => JsonSerializer.Serialize<Location>(this);
    }
}
