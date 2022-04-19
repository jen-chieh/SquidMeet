namespace src.Models
{
    public class Attendee: User
    {
        public string UserId { get; set; }
        public User User { get; set; }
        public Guid EventId { get; set; }
        public Meetup Event { get; set; }
        public bool IsHost { get; set; }
    
        public override string ToString() => JsonSerializer.Serialize<Attendee>(this);
    }
}