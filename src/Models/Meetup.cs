namespace src.Models
{
    public class Meetup
    {
        public string meetup_id { get; set; }
        public string location_id { get; set; }
        public int index { get; set; }
        public string Title { get; set; }
        public string Date { get; set; }    
        public Attendee Attendees { get; set; }
        public string Description { get; set; }

        public override toString() => JsonSerializer.Serialize<Meetup>(this);
    }
}