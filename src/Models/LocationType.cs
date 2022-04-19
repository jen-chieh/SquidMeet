using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ContosoCrafts.WebSite.Models
{
    public class LocationType
    {
        
        public string? type_id { get; set; }
        public int? index { get; set; }
        public string? typeName { get; set; }
        public override string ToString() => JsonSerializer.Serialize<LocationType>(this);
    }
}
