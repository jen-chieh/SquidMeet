using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace ContosoCrafts.WebSite.Models
{

    /// <summary>
    /// Model for the meetup.json file. The model assigns each meetup an unique meetup ID
    /// location ID with a index, title, date, description and a list of attendees.
    /// </summary>
    public class MeetupModel
    {
        //Unique Id assigned to meetup
        public string? meetup_id { get; set; }

        //Refer to location id
        [Required]
        public string? location { get; set; }

        //An index so that we can do sort and arrange by location type
        [Required]
        public string? LocationType { get; set; }

        //Title of Meetup
        [Required]
        public string? Title { get; set; }

        //Start date and end Date of Meetup
        [DataType(DataType.Date), Required]
        public string? Date { get; set; }

        //Attendees in the meetup
        public List<StatusModel>? Attendees { get; set; }

        // To identify the host of the meetup
        [Required]
        public string? Host { get; set; }

        //To describe what meetup is 
        [Required]
        public string? Description { get; set; }

        // To store Invite code
        public string? InviteCode { get; set; }

        // Image to describe the meetup
        public string? Img { get; set; }

        // Video to describe the meetup
        public string? Video { get; set; }

        /// <summary>
        /// Method to pass database information as a string
        /// </summary>
        /// <returns></returns>
        public override string ToString() => JsonSerializer.Serialize<MeetupModel>(this);

    }
}
