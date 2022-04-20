using System.Text.Json;
using System.Text.Json.Serialization;

namespace ContosoCrafts.WebSite.Models
{
    /// <summary>
    /// Model for the attendees.json file. The model assigns each Attendee an unique user ID
    /// event ID with 
    /// </summary>
    public class Attendee: UserModel
    {
        public string? UserId { get; set; }
        public UserModel? User { get; set; }
        public string? EventId { get; set; }
        public Meetup? Event { get; set; }
        public bool? IsHost { get; set; }
    
        public override string ToString() => JsonSerializer.Serialize<Attendee>(this);
    }
}
