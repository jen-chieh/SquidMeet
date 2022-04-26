using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ContosoCrafts.WebSite.Models
{
    /// <summary>
    /// Model for location_type.json file. The model has a unique ID mapping back to a
    /// location in location.json, and displays all the types of locations like cafe/library/park etc. 
    /// </summary>
    public class LocationTypeModel
    {

        //Unique Id assigned to location type
        public string? type_id { get; set; }
        // Name of location type
        public string? type_name { get; set; }
        public override string ToString() => JsonSerializer.Serialize<LocationTypeModel>(this);
    }
}
