using System.Text.Json;
using System.Text.Json.Serialization;

namespace ContosoCrafts.WebSite.Models
{
    public class Location
    {
        public string? location_id { get; set; }
        public string? name { get; set; }
        [JsonPropertyName("img")]
        public string? img { get; set; }
        public string? address { get; set; }      
        public int[]? Ratings { get; set; }
        public override string ToString() => JsonSerializer.Serialize<Location>(this);
    }
}
