namespace src.Models
{
    public class Meetup
    {
        public Guid MeetupId { get; set; }

        public ICollection<Attendee> Attendees { get; set; }
        public ICollection<Product> Product { get; set; }
        public ICollection<Location> Locations { get; set; }
    }
}