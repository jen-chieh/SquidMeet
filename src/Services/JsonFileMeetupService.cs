using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using ContosoCrafts.WebSite.Models;
using Microsoft.AspNetCore.Hosting;

namespace ContosoCrafts.WebSite.Services
{
    /// <summary>
    /// Create class from meetup.json file and retrieve all data from file.
    /// </summary>
    public class JsonFileMeetupService
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="webHostEnvironment"></param>
        public JsonFileMeetupService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        // Data middle tier
        public IWebHostEnvironment WebHostEnvironment { get; }

        // Get json file path
        private string JsonFileName => Path.Combine(WebHostEnvironment.WebRootPath, "data", "meetup.json");

        /// <summary>
        /// Read .json file and return all data fields through the model
        /// </summary>
        public IEnumerable<MeetupModel> GetMeetups()
        {
            using var jsonFileReader = File.OpenText(JsonFileName);

            return JsonSerializer.Deserialize<MeetupModel[]>(jsonFileReader.ReadToEnd(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
        }

        /// <summary>
        /// Add new meetup to json file
        /// </summary>
        /// <param name="meetups"></param>
        private void Add(IEnumerable<MeetupModel> meetups)
        {
            using (var outputStream = File.Create(JsonFileName))
            {
                JsonSerializer.Serialize<IEnumerable<MeetupModel>>(
                    new Utf8JsonWriter(outputStream, new JsonWriterOptions
                    {
                        SkipValidation = true,
                        Indented = true
                    }),
                    meetups
                );
            }
        }

        /// <summary>
        /// Create new meetup to json file
        /// </summary>
        /// <param name="newMeetup"></param>
        /// <returns></returns>
        public MeetupModel Create(MeetupModel newMeetup)
        {
            var meetup = new MeetupModel()
            {
                meetup_id = System.Guid.NewGuid().ToString(),
                location = newMeetup.location,
                LocationType = newMeetup.LocationType,
                Title = newMeetup.Title,
                Date = newMeetup.Date,
                Description = newMeetup.Description,
                Host = newMeetup.Host,
                Img = newMeetup.Img,
                InviteCode = System.Guid.NewGuid().ToString(),
            };

            var meetups = GetMeetups();
            meetups = meetups.Append(meetup);

            Add(meetups);

            return meetup;

        }

        /// <summary>
        /// Update meetup to json file
        /// </summary>
        /// <param name="meetup"></param>
        /// <returns></returns>
        public MeetupModel UpdateMeetup(MeetupModel meetup)
        {
            var dataSet = GetMeetups();
            var data = dataSet.FirstOrDefault(p => p.meetup_id == meetup.meetup_id);
            if (data == null)
            {
                return null;
            }
            data.Date = meetup.Date;
            data.Title = meetup.Title;
            data.Description = meetup.Description;
            data.Img = meetup.Img;
            data.Video = meetup.Video;
            SaveData(dataSet);
            return meetup;
        }

        /// <summary>
        /// Save All Meetup data to storage
        /// <param name="meetups"></param>
        /// </summary>
        private void SaveData(IEnumerable<MeetupModel> meetups)
        {
            using (var outputStream = File.Create(JsonFileName))
            {
                JsonSerializer.Serialize<IEnumerable<MeetupModel>>(
                    new Utf8JsonWriter(outputStream, new JsonWriterOptions
                    {
                        SkipValidation = true,
                        Indented = true
                    }),
                    meetups
                );
            }
        }

        /// <summary>
        /// Add attendee names to the meetup
        /// </summary>
        /// <param name="meetup"></param>
        /// <param name="attendeeName"></param>
        public void AddAttendee(MeetupModel meetup, string attendeeName)
        {
            var meetups = GetMeetups();
            var validMeetup = meetups.FirstOrDefault(p => p.InviteCode == meetup.InviteCode);
            if (validMeetup == null)
            {
                return;
            }
            var attendees = meetups.FirstOrDefault(p => p.InviteCode == meetup.InviteCode).Attendees.ToList();
            attendees.Add(attendeeName);
            meetups.FirstOrDefault(p => p.InviteCode == meetup.InviteCode).Attendees = attendees.ToArray();

            using (var outputStream = File.OpenWrite(JsonFileName))
            {
                JsonSerializer.Serialize<IEnumerable<MeetupModel>>(
                    new Utf8JsonWriter(outputStream, new JsonWriterOptions
                    {
                        SkipValidation = true,
                        Indented = true
                    }),
                    meetups
                );
            }

        }

    }
}
