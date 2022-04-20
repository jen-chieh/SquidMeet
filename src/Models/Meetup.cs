using System.Text.Json;
using System.Text.Json.Serialization;

namespace ContosoCrafts.WebSite.Models
{
    public class Meetup
    {
        public string? meetup_id { get; set; }
        public string? location_id { get; set; }
        public int? index { get; set; }
        public string? Title { get; set; }
        public string? Date { get; set; }    
        public Attendee? Attendees { get; set; }
        public string? Description { get; set; }

        public override string ToString() => JsonSerializer.Serialize<Meetup>(this);
    }
}
