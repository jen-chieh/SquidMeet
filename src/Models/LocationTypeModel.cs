using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ContosoCrafts.WebSite.Models
{
    public class LocationTypeModel
    {
        
        public string? type_id { get; set; }
        public string? type_name { get; set; }
        public override string ToString() => JsonSerializer.Serialize<LocationTypeModel>(this);
    }
}
