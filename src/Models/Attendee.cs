using System.Text.Json;
using System.Text.Json.Serialization;

namespace ContosoCrafts.WebSite.Models
{
    /// <summary>
    /// Model for the attendees.json file. The model inherits from the UserModel class. 
    /// It assigns each attendee an unique user ID with event ID, event object and a boolean 
    /// variable to tell if the attendee is the host of the event.
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
