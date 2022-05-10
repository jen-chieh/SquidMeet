
using Microsoft.AspNetCore.Mvc;
using System.Linq;

using NUnit.Framework;

using ContosoCrafts.WebSite.Pages.Product;
using ContosoCrafts.WebSite.Models;

namespace UnitTests.Pages.Services.JsonFileUserService
{
    public class UserTests
    {
        #region TestSetup
        public static UserModel pageModel;

        [SetUp]
        public void TestInitialize()
        {
            pageModel = new UserModel()
            {
            };
        }

        #endregion TestSetup

        #region OnGet
        // Test to verify getAllUsers returns correct data is valid
        [Test]
        public void OnGet_Valid_Should_Return_User()
        {
            // Arrange
            var data = TestHelper.UserService.GetUsers().Count();
            // Act
        

            // Assert
            Assert.AreEqual(data, TestHelper.UserService.GetUsers().Count());
           
        }
        #endregion OnGet


        #region OnGet
        // Test to verify saveData returns correct data is valid
        [Test]
        public void Valid_CreateUser()
        {
            // Arrang
            var data = new UserModel()
            {
                user_id = "",
                email = "",
                password = "",
                confirmPassword = "",
                //name = user.email,
                //age = user.age,
                //gender = user.gender,
                bio =""

            };
            var user = TestHelper.UserService.CreateUser(data);

            // Act
          

            // Assert
            Assert.NotNull(data);

        }
        #endregion OnGet

        #region OnGet
        // Test to verify updateUser returns correct data is valid
        [Test]
        public void Valid_update()
        {
            // Arrang
          
            var user = TestHelper.UserService.GetUsers().FirstOrDefault();
            var updatedUser= TestHelper.UserService.UpdateUser(user);
            // Act    

            // Assert
            Assert.NotNull(updatedUser);

        }
        #endregion OnGet

        #region OnGet
        // Test to verify updateUser returns correct data is invalid
        [Test]
        public void inValid_update()
        {
            // Arrang
            var user = new UserModel()
            {
                user_id = "test11",
                email = "test@seattleu.edu",
                password = "jen1211",
                name = "jen",
                age = 19,
                gender = "M",
                bio = "hello world"

            };
            var updatedUser = TestHelper.UserService.UpdateUser(user);
            // Act    

            // Assert
            Assert.IsNull(updatedUser);

        }
        #endregion OnGet

        #region OnGet
        // Test to verify updateUserage returns correct data is valid
        [Test]
        public void Valid_updateAge()
        {
            // Arrang
            var user = TestHelper.UserService.GetUsers().FirstOrDefault();
            user.age = 11;
          
            var updatedUser = TestHelper.UserService.UpdateUserAge(user);
            // Act    

            // Assert
            Assert.IsNotNull(updatedUser);

        }
        #endregion OnGet
        #region OnGet
        // Test to verify updateUserGender returns correct data is valid
        [Test]
        public void Valid_updateGender()
        {
            // Arrang
            var user = TestHelper.UserService.GetUsers().FirstOrDefault();
            user.gender = "F";

            var updatedUser = TestHelper.UserService.UpdateUserGender(user);
            // Act    

            // Assert
            Assert.IsNotNull(updatedUser);

        }
        #endregion OnGet
        #region OnGet
        // Test to verify updateUserbio returns correct data is valid
        [Test]
        public void Valid_Bio()
        {
            // Arrang
            var user = TestHelper.UserService.GetUsers().FirstOrDefault();
            user.bio = "hello";

            var updatedUser = TestHelper.UserService.UpdateUserBio(user);
            // Act    

            // Assert
            Assert.IsNotNull(updatedUser);

        }
        #endregion OnGet
        #region OnGet
        // Test to verify updatename returns correct data is valid
        [Test]
        public void Valid_updatname()
        {
            // Arrang
            var user = TestHelper.UserService.GetUsers().FirstOrDefault();
            user.name = "Bi Bi";

            var updatedUser = TestHelper.UserService.UpdateUserName(user);
            // Act    

            // Assert
            Assert.IsNotNull(updatedUser);

        }
        #endregion OnGet
        #region OnGet
        // Test to verify updatepassword returns correct data is invalid
        [Test]
        public void Valid_updatepassword()
        {
            // Arrang
            var user = TestHelper.UserService.GetUsers().FirstOrDefault();
            user.password = "11";

            var updatedUser = TestHelper.UserService.UpdateUserPassword(user);
            // Act    

            // Assert
            Assert.IsNotNull(updatedUser);

        }
        #endregion OnGet


    }
}
