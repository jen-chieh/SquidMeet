using System.Text.Json;
using System.Text.Json.Serialization;

namespace ContosoCrafts.WebSite.Models
{
    public class LocationHours
    {
        public string? location_hours_id { get; set; }
        public string? location_mon_hours { get; set; }
        public string? location_tues_hours { get; set; }
        public string? location_wed_hours { get; set; }
        public string? location_thurs_hours { get; set; }
        public string? location_fri_hours { get; set; }
        public string? location_sat_hours { get; set; }
        public string? location_sun_hours { get; set; }

        public override string ToString() => JsonSerializer.Serialize<LocationHours>(this);
    }
}
