using ContosoCrafts.WebSite.Controllers;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringLibraryTest
{
    /// <summary>
    /// Unit test for the User object/model that tests getting the correct value, creating a 
    /// new user, creating a new user when the username is taken, providing the correct login
    /// credentials and providing the incorrect login credentials.
    /// </summary>
    [TestClass]
    public class UserUnitTest
    {
        [TestMethod]
        public void TestGetCorrectValue()
        {
            // Implement test function to test if the correct value is returned for a data field
        }

        [TestMethod]
        public void TestCreateUser()
        {
            // Implement test function to test if a new user can be successfully created
        }

        [TestMethod]
        public void TestCreateUserDuplicate()
        {
            // Implement test function to test if an attempt to create a new user where the
            // username is already taken is rejected
        }

        [TestMethod]
        public void TestCorrectLogin()
        {
            // Implement test function to test if a user can successfully log in by providing the
            // correct credentials
        }

        [TestMethod]
        public void TestIncorrectLogin()
        {
            // Implement test function to test if a user is blocked from logging in by providing the
            // incorrect credentials
        }
    }
}
