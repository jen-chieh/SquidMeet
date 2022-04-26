using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using ContosoCrafts.WebSite.Models;
using Microsoft.AspNetCore.Hosting;

namespace ContosoCrafts.WebSite.Services
{
    /// <summary>
    /// Create class from users.json file and retrieve all data from file.
    /// </summary>
    public class JsonFileUserService
    {
        // Initialize class
        public JsonFileUserService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        // Data middle tier
        public IWebHostEnvironment WebHostEnvironment { get; }

        // Get json file path 
        private string JsonFileName => Path.Combine(WebHostEnvironment.WebRootPath, "data", "users.json");

        // Read .json file and return data fields through the model
        public IEnumerable<UserModel> GetUsers()
        {
            using var jsonFileReader = File.OpenText(JsonFileName);

            return JsonSerializer.Deserialize<UserModel[]>(jsonFileReader.ReadToEnd(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });        
        }
        /// <summary>
        /// Save All products data to storage
        /// </summary>
        private void SaveData(IEnumerable<UserModel> products)
        {

            using (var outputStream = File.Create(JsonFileName))
            {
                JsonSerializer.Serialize<IEnumerable<UserModel>>(
                    new Utf8JsonWriter(outputStream, new JsonWriterOptions
                    {
                        SkipValidation = true,
                        Indented = true
                    }),
                    products
                );
            }
        }

        public UserModel CreateUser()
        {
            var data = new UserModel()
            {
                user_id = GetHashCode(),
                username = "Enter User Name",
                password = "Enter password",
                name = "Enter Name",
                age = 0,
                gender= "Enter Gender",
                bio="Enter Bio"

            };

            // Get the current set, and append the new record to it
            var dataSet = GetUsers();
            dataSet = dataSet.Append(data);

            SaveData(dataSet);

            return data;
        }
    }
}
