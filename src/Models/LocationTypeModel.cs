using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ContosoCrafts.WebSite.Models
{
    public class LocationTypeModel
    {

        //Unique Id assigned to location type
        public string? type_id { get; set; }
        // Name of location type
        public string? type_name { get; set; }
        public override string ToString() => JsonSerializer.Serialize<LocationTypeModel>(this);
    }
}
