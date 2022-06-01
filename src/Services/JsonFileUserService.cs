using System;
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
        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="webHostEnvironment"></param>
        public JsonFileUserService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        // Data middle tier
        public IWebHostEnvironment WebHostEnvironment { get; }

        // Get json file path 
        private string JsonFileName => Path.Combine(WebHostEnvironment.WebRootPath, "data", "users.json");

        // Random number generator for new user ids
        private static Random random = new Random();

        /// <summary>
        /// Generate and return a random string representation of numbers
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string RandomString(int length)
        {
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        /// <summary>
        /// Read .json file and return all data fields through the model
        /// </summary>
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
        /// <paramref name="products"/>
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

        /// <summary>
        /// Add new user to .json file
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public UserModel CreateUser(UserModel user)
        {
            var data = new UserModel()
            {
                user_id = RandomString(2),
                email = user.email,
                password = user.password,
                confirmPassword = user.confirmPassword,
                //name = user.email,
                //age = user.age,
                //gender = user.gender,
                bio = user.gender

            };

            // Get the current set, and append the new record to it
            var dataSet = GetUsers();
            dataSet = dataSet.Append(data);

            SaveData(dataSet);

            return data;
        }

        /// <summary>
        /// Update user data
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public UserModel UpdateUser(UserModel user)
        {
            var dataSet = GetUsers();
            var data = dataSet.FirstOrDefault(p => p.user_id == user.user_id);
            if (data == null)
            {
                return null;
            }
            data.email = user.email;
            data.password = user.password;
            data.name = user.name;
            data.age = user.age;
            data.gender = user.gender;
            data.bio = user.bio;

            SaveData(dataSet);
            return user;
        }

        /// <summary>
        /// Update user bio data
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public UserModel UpdateUserBio(UserModel user)
        {
            var dataSet = GetUsers();
            var data = dataSet.FirstOrDefault(p => p.user_id == user.user_id);
            if (data == null)
            {
                return null;
            }

            data.bio = user.bio;
            SaveData(dataSet);
            return user;
        }

        /// <summary>
        /// Update user name data
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public UserModel UpdateUserName(UserModel user)
        {
            var dataSet = GetUsers();
            var data = dataSet.FirstOrDefault(p => p.user_id == user.user_id);
            if (data == null)
            {
                return null;
            }

            data.name = user.name;
            SaveData(dataSet);
            return user;
        }

        /// <summary>
        /// Update user gender data
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public UserModel UpdateUserGender(UserModel user)
        {
            var dataSet = GetUsers();
            var data = dataSet.FirstOrDefault(p => p.user_id == user.user_id);
            if (data == null)
            {
                return null;
            }

            data.gender = user.gender;
            SaveData(dataSet);
            return user;
        }

        /// <summary>
        /// Update user age data
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public UserModel UpdateUserAge(UserModel user)
        {
            var dataSet = GetUsers();
            var data = dataSet.FirstOrDefault(p => p.user_id == user.user_id);
            if (data == null)
            {
                return null;
            }

            data.age = user.age;
            SaveData(dataSet);
            return user;
        }

        /// <summary>
        /// Update user password data 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public UserModel UpdateUserPassword(UserModel user)
        {
            var dataSet = GetUsers();
            var data = dataSet.FirstOrDefault(p => p.user_id == user.user_id);
            if (data != null)
            {
                data.password = user.password;
                SaveData(dataSet);
                return user;
            }

            return null;

        }

    }
}
