using System.Text.Json;

namespace ContosoCrafts.WebSite.Models
{
    /// <summary>
    /// Model for the attendees.json file. The model inherits from the UserModel class. 
    /// It assigns each attendee an unique user ID with event ID, event object and a boolean 
    /// variable to tell if the attendee is host of the event.
    /// </summary>
    public class AttendeeModel : UserModel
    {
        // Unique Id of User
        public string? UserId { get; set; }
        // Information of User Account
        public int? User { get; set; }
        // Id of Event that Attendee participate
        public string? EventId { get; set; }
        // Information of Event that Attendee participate
        public string? Event { get; set; }
        // To check if the Event host or cancel
        public string? IsHost { get; set; }

        public override string ToString() => JsonSerializer.Serialize<AttendeeModel>(this);
    }
}
