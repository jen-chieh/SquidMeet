using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using ContosoCrafts.WebSite.Models;
using Microsoft.AspNetCore.Hosting;
using ContosoCrafts.WebSite.Services;

namespace ContosoCrafts.WebSite.Services
{
    /// <summary>
    /// Create class from Location.json file and retrieve all data from file.
    /// </summary>
    public class JsonFileLocationService
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="webHostEnvironment"></param>
        public JsonFileLocationService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        // Data middle tier
        public IWebHostEnvironment WebHostEnvironment { get; }

        // Get json file path 
        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "location.json"); }
        }

        /// <summary>
        /// Read .json file and return all data fields through the model
        /// </summary>
        public IEnumerable<LocationModel> GetAllData()
        {
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<LocationModel[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
            }
        }

        public JsonFileLocationHoursService LocationHoursService = new JsonFileLocationHoursService();

        /// <summary>
        /// Find matching productId and update rating of product to include new rating
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="rating"></param>
        public void AddRating(string productId, int rating)
        {
            var products = GetAllData();

            if (products.First(x => x.location_id == productId).rating == null)
            {
                products.First(x => x.location_id == productId).rating = new int[] { rating };
            }
            else
            {
                var ratings = products.First(x => x.location_id == productId).rating.ToList();
                ratings.Add(rating);
                products.First(x => x.location_id == productId).rating = ratings.ToArray();
            }

            // Update database information to include rating
            using (var outputStream = File.OpenWrite(JsonFileName))
            {
                JsonSerializer.Serialize<IEnumerable<LocationModel>>(
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
        /// Find the data record
        /// Update the fields
        /// Save to the data store
        /// </summary>
        /// <param name="data"></param>
        public LocationModel UpdateData(LocationModel data)
        {
            var products = GetAllData();
            var productData = products.FirstOrDefault(x => x.location_id.Equals(data.location_id));
            if (productData == null)
            {
                return null;
            }

            productData.name = data.name;
            productData.type_id = data.type_id;
            productData.address = data.address;
            productData.img = data.img;

            SaveData(products);

            return productData;
        }

        /// <summary>
        /// Save All products data to storage
        /// </summary>
        /// <param name="products"></param>
        private void SaveData(IEnumerable<LocationModel> products)
        {

            using (var outputStream = File.Create(JsonFileName))
            {
                JsonSerializer.Serialize<IEnumerable<LocationModel>>(
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
        /// Create a new product using default values
        /// After create the user can update to set values
        /// </summary>
        /// <returns></returns>
        public LocationModel CreateData(LocationModel locationmodel)
        {

            string name = "Temporary name";
            string address = "Temporary address";
            string type_id = "0";
            string img = "Temporary image";

            if (locationmodel.name == null) {
                locationmodel.name = name;
            }

            if (locationmodel.address == null)
            {
                locationmodel.address = address;
            }

            if (locationmodel.type_id == null)
            {
                locationmodel.type_id = type_id;
            }

            if (locationmodel.img == null)
            {
                locationmodel.img = img;
            }

            var data = new LocationModel()
            {
                location_id = System.Guid.NewGuid().ToString(),
                name = locationmodel.name,
                address = locationmodel.address,
                type_id = locationmodel.type_id,
                img = locationmodel.img,
            };

            // Get the current set, and append the new record to it
            var dataSet = GetAllData();
            dataSet = dataSet.Append(data);
            SaveData(dataSet);
            return data;
        }

        /// <summary>
        /// Remove the item from the system
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public LocationModel DeleteData(string id)
        {
            // Get the current set, and append the new record to it
            var dataSet = GetAllData();
            var data = dataSet.FirstOrDefault(m => m.location_id.Equals(id));

            var newDataSet = GetAllData().Where(m => m.location_id.Equals(id) == false);

            SaveData(newDataSet);

            return data;
        }

        /// <summary>
        /// Sort locations by rating in descending order
        /// </summary>
        /// <param name="rating"></param>
        /// <returns></returns>
        public IEnumerable<LocationModel> sortByRate(int rating)
        {
            // Get the current set, and append the new record to it
            var dataSet = GetAllData();

            if (rating == 0)
                return dataSet;

            var data = (from t in dataSet
                        where t.rating != null

                        select t);

            var sortingData = data.Where(d => ((int)(d.rating.Sum() / d.rating.Count())).Equals(rating));
            return sortingData;
        }

        /// <summary>
        /// Sort locations by location type
        /// </summary>
        /// <returns></returns>
        
        public IEnumerable<LocationModel> sortByLocation()
        {
            // Get the current set, and append the new record to it
            var dataSet = GetAllData();

            var sortingData = dataSet.OrderByDescending(d => d.type_id);
            return sortingData;
        }

        public IEnumerable<LocationModel> sortByLocationAndRating(string type, int rating)
        {
            // Get the current set, and append the new record to it
            var dataSet = GetAllData();

            if (rating != 0)
            {
                dataSet = (from t in dataSet
                           where t.rating != null

                           select t);

                dataSet = dataSet.Where(d => ((int)(d.rating.Sum() / d.rating.Count())).Equals(rating));
            }

            if (!string.IsNullOrEmpty(type))
            {
                dataSet = dataSet.Where(d => d.type_id == type);
            }

            return dataSet;
        }

    }
}
