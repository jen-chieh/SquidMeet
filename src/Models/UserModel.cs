using System.Text.Json;
using System.Text.Json.Serialization;

namespace ContosoCrafts.WebSite.Models
{
    public class UserModel
    {
        public string? user_id { get; set; }
        public string? username { get; set; }
        public string? password { get; set; }
        public string? name { get; set; }
        public int age { get; set; }
        public string? gender { get; set; }
        public string? bio { get; set; }

        public override string ToString() => JsonSerializer.Serialize<UserModel>(this);
    }
}
