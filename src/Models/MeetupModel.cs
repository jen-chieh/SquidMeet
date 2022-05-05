using System.Text.Json;

namespace ContosoCrafts.WebSite.Models
{
    /// <summary>
    /// Model for the meetup.json file. The model assigns each meetup an unique meetup ID
    /// location ID with a index, title, date, description and a list of attendees.
    /// </summary>
    public class MeetupModel
    {
        //Unique Id assigned to meetup
        public string? meetup_id { get; set; }
        //Refer to location id
        public string? location { get; set; }
        //An index so that we can do sort and arrange
        public string? LocationType { get; set; }
        //Tittle of Meetup
        public string? Title { get; set; }
        //Start data and end Date of Meetup
        public string? Date { get; set; }
        //Attendees in the meetup
        public string[]? Attendees { get; set; }
        // To identify the host
        public string? Host { get; set; }
        //To descript what meetup is 
        public string? Description { get; set; }

        // To store Invite code
        public string? InviteCode { get; set; }

        public string? Img { get; set; }
        public override string ToString() => JsonSerializer.Serialize<MeetupModel>(this);
    }
}
