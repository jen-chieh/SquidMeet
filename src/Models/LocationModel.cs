using System.Text.Json;
using System.Text.Json.Serialization;

namespace ContosoCrafts.WebSite.Models
{
    public class LocationModel
    {
        public string? location_id { get; set; }
        public string? name { get; set; }
        public int type_id { get; set; }
        public string? address { get; set; }
        [JsonPropertyName("img")]
        public string? Image { get; set; }

        public int[]? rating { get; set; }

        public override string ToString() => JsonSerializer.Serialize<LocationModel>(this);

 
    }
}
