using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ContosoCrafts.WebSite.Models
{
    /// <summary>
    /// Model for location_type.json file. This defines different types of locations like
    /// bars/cafe/conference_rooms/park for meet ups
    /// </summary>
    public class LocationType
    {
        // unique location type id
        public string? type_id { get; set; }
        public int? index { get; set; }
        // location type names like bars / cafes / park / conference room
        public string? typeName { get; set; }
        public override string ToString() => JsonSerializer.Serialize<LocationType>(this);
    }
}
