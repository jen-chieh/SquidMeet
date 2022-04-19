namespace src.Models
{
    public class Meetup
    {
        public Guid MeetupId { get; set; }
        public string MeetupName { get; set; }
        public string HostId { get; set; }
        public ICollection<Attendee> Attendees { get; set; }
        public ICollection<Product> Product { get; set; }
        public ICollection<Location> Locations { get; set; }
        public override toString() => JsonSerializer.Serialize<Meetup>(this);
    }
}