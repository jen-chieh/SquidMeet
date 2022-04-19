namespace src.Models
{
    public class Attendee: User
    {
        public string userId { get; set; }
        public User User { get; set; }
        public Guid MeetupId { get; set; }

        public Meetup Meetup { get; set; }

        public bool IsHost { get; set; }
        
        public override string ToString() => JsonSerializer.Serialize<Attendee>(this);
    }
}