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
        public string? location_id { get; set; }
        //An index so that we can do sort and arrange
        public int? index { get; set; }
        //Tittle of Meetup
        public string? Title { get; set; }
        //Start data and end Date of Meetup
        public string? Date { get; set; }
        //Attendees in the meetup
        public string[]? Attendees { get; set; }
        //To descript what meetup is 
        public string? Description { get; set; }

        public override string ToString() => JsonSerializer.Serialize<MeetupModel>(this);
    }
}
