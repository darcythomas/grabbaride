using GrabbaRide.Database;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Linq.Mapping;
using System.Data;
using System.Collections.Generic;
using System;
using System.Data.Linq;

namespace GrabbaRide.UnitTests
{
    /// <summary>
    ///This is a test class for GrabbaRideDBDataContext and is intended
    ///to contain all GrabbaRideDBDataContext Unit Tests
    ///</summary>
    [TestClass()]
    public class GrabbaRideDBDataContextTest
    {
        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        /// <summary>
        ///A test for GrabbaRideDBDataContext Constructor
        ///</summary>
        [TestMethod()]
        public void GrabbaRideDBDataContextCreateDatabaseTest()
        {
            GrabbaRideDBDataContext target = new GrabbaRideDBDataContext();
            if (target.DatabaseExists())
            {
                Assert.Inconclusive("Cannot test database creation if database already exists!");
               
            }
            else
            {
                target.CreateDatabase();
                Assert.IsTrue(target.DatabaseExists(), "The database could not be successfully created!");
                target.DeleteDatabase();
            }
        }

        /// <summary>
        ///A test for Users
        ///</summary>
        [TestMethod()]
        public void UsersTest()
        {
            GrabbaRideDBDataContext target = new GrabbaRideDBDataContext(); // TODO: Initialize to an appropriate value
            Table<User> actual;
            actual = target.Users;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Rides
        ///</summary>
        [TestMethod()]
        public void RidesTest()
        {
            GrabbaRideDBDataContext target = new GrabbaRideDBDataContext(); // TODO: Initialize to an appropriate value
            Table<Ride> actual;
            actual = target.Rides;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for OpenIDs
        ///</summary>
        [TestMethod()]
        public void OpenIDsTest()
        {
            GrabbaRideDBDataContext target = new GrabbaRideDBDataContext(); // TODO: Initialize to an appropriate value
            Table<OpenID> actual;
            actual = target.OpenIDs;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for IsOpenIDRegistered
        ///</summary>
        [TestMethod()]
        public void IsOpenIDRegisteredTest()
        {
            GrabbaRideDBDataContext target = new GrabbaRideDBDataContext(); // TODO: Initialize to an appropriate value
            string url = string.Empty; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.IsOpenIDRegistered(url);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for getUserRides
        ///</summary>
        [TestMethod()]
        public void getUserRidesTest()
        {
            GrabbaRideDBDataContext target = new GrabbaRideDBDataContext(); // TODO: Initialize to an appropriate value
            int userID = 0; // TODO: Initialize to an appropriate value
            IEnumerable<Ride> expected = null; // TODO: Initialize to an appropriate value
            IEnumerable<Ride> actual;
            actual = target.getUserRides(userID);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetUserId
        ///</summary>
        [TestMethod()]
        public void GetUserIdTest()
        {
            GrabbaRideDBDataContext target = new GrabbaRideDBDataContext(); // TODO: Initialize to an appropriate value
            string openid_url = string.Empty; // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.GetUserId(openid_url);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetUserByUsername
        ///</summary>
        [TestMethod()]
        public void GetUserByUsernameTest()
        {
            GrabbaRideDBDataContext target = new GrabbaRideDBDataContext(); // TODO: Initialize to an appropriate value
            string username = string.Empty; // TODO: Initialize to an appropriate value
            User expected = null; // TODO: Initialize to an appropriate value
            User actual;
            actual = target.GetUserByUsername(username);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetUserByID
        ///</summary>
        [TestMethod()]
        public void GetUserByIDTest()
        {
            GrabbaRideDBDataContext target = new GrabbaRideDBDataContext(); // TODO: Initialize to an appropriate value
            int userID = 0; // TODO: Initialize to an appropriate value
            User expected = null; // TODO: Initialize to an appropriate value
            User actual;
            actual = target.GetUserByID(userID);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetUserByEmail
        ///</summary>
        [TestMethod()]
        public void GetUserByEmailTest()
        {
            GrabbaRideDBDataContext target = new GrabbaRideDBDataContext(); // TODO: Initialize to an appropriate value
            string email = string.Empty; // TODO: Initialize to an appropriate value
            User expected = null; // TODO: Initialize to an appropriate value
            User actual;
            actual = target.GetUserByEmail(email);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetUser_SortByUserName
        ///</summary>
        [TestMethod()]
        public void GetUser_SortByUserNameTest()
        {
            GrabbaRideDBDataContext target = new GrabbaRideDBDataContext(); // TODO: Initialize to an appropriate value
            IEnumerable<User> expected = null; // TODO: Initialize to an appropriate value
            IEnumerable<User> actual;
            actual = target.GetUser_SortByUserName();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetUser_SortByOccupation
        ///</summary>
        [TestMethod()]
        public void GetUser_SortByOccupationTest()
        {
            GrabbaRideDBDataContext target = new GrabbaRideDBDataContext(); // TODO: Initialize to an appropriate value
            IEnumerable<User> expected = null; // TODO: Initialize to an appropriate value
            IEnumerable<User> actual;
            actual = target.GetUser_SortByOccupation();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetUser_SortByLastActvityDate
        ///</summary>
        [TestMethod()]
        public void GetUser_SortByLastActvityDateTest()
        {
            GrabbaRideDBDataContext target = new GrabbaRideDBDataContext(); // TODO: Initialize to an appropriate value
            IEnumerable<User> expected = null; // TODO: Initialize to an appropriate value
            IEnumerable<User> actual;
            actual = target.GetUser_SortByLastActvityDate();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetUser_ByOpenID
        ///</summary>
        [TestMethod()]
        public void GetUser_ByOpenIDTest()
        {
            GrabbaRideDBDataContext target = new GrabbaRideDBDataContext(); // TODO: Initialize to an appropriate value
            string url = string.Empty; // TODO: Initialize to an appropriate value
            User expected = null; // TODO: Initialize to an appropriate value
            User actual;
            actual = target.GetUser_ByOpenID(url);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for getRidesBetween
        ///</summary>
        [TestMethod()]
        public void getRidesBetweenTest()
        {
            GrabbaRideDBDataContext target = new GrabbaRideDBDataContext(); // TODO: Initialize to an appropriate value
            DateTime beforeDate = new DateTime(); // TODO: Initialize to an appropriate value
            DateTime afterDate = new DateTime(); // TODO: Initialize to an appropriate value
            IEnumerable<Ride> expected = null; // TODO: Initialize to an appropriate value
            IEnumerable<Ride> actual;
            actual = target.getRidesBetween(beforeDate, afterDate);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for getRidesBeforeDate
        ///</summary>
        [TestMethod()]
        public void getRidesBeforeDateTest()
        {
            GrabbaRideDBDataContext target = new GrabbaRideDBDataContext(); // TODO: Initialize to an appropriate value
            DateTime beforeDate = new DateTime(); // TODO: Initialize to an appropriate value
            IEnumerable<Ride> expected = null; // TODO: Initialize to an appropriate value
            IEnumerable<Ride> actual;
            actual = target.getRidesBeforeDate(beforeDate);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for getRidesAfterDate
        ///</summary>
        [TestMethod()]
        public void getRidesAfterDateTest()
        {
            GrabbaRideDBDataContext target = new GrabbaRideDBDataContext(); // TODO: Initialize to an appropriate value
            DateTime afterDate = new DateTime(); // TODO: Initialize to an appropriate value
            IEnumerable<Ride> expected = null; // TODO: Initialize to an appropriate value
            IEnumerable<Ride> actual;
            actual = target.getRidesAfterDate(afterDate);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetRideByID
        ///</summary>
        [TestMethod()]
        public void GetRideByIDTest()
        {
            GrabbaRideDBDataContext target = new GrabbaRideDBDataContext(); // TODO: Initialize to an appropriate value
            int rideID = 0; // TODO: Initialize to an appropriate value
            Ride expected = null; // TODO: Initialize to an appropriate value
            Ride actual;
            actual = target.GetRideByID(rideID);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetOpenIDsByUser
        ///</summary>
        [TestMethod()]
        [DeploymentItem("GrabbaRide.Database.dll")]
        public void GetOpenIDsByUserTest()
        {
            GrabbaRideDBDataContext_Accessor target = new GrabbaRideDBDataContext_Accessor(); // TODO: Initialize to an appropriate value
            int user_id = 0; // TODO: Initialize to an appropriate value
            OpenID expected = null; // TODO: Initialize to an appropriate value
            OpenID actual;
            actual = target.GetOpenIDsByUser(user_id);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetOpenIDsByURL
        ///</summary>
        [TestMethod()]
        public void GetOpenIDsByURLTest()
        {
            GrabbaRideDBDataContext target = new GrabbaRideDBDataContext(); // TODO: Initialize to an appropriate value
            string openid_url = string.Empty; // TODO: Initialize to an appropriate value
            OpenID expected = null; // TODO: Initialize to an appropriate value
            OpenID actual;
            actual = target.GetOpenIDsByURL(openid_url);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetOpenIDByUser
        ///</summary>
        [TestMethod()]
        public void GetOpenIDByUserTest()
        {
            GrabbaRideDBDataContext target = new GrabbaRideDBDataContext(); // TODO: Initialize to an appropriate value
            int user_id = 0; // TODO: Initialize to an appropriate value
            OpenID expected = null; // TODO: Initialize to an appropriate value
            OpenID actual;
            actual = target.GetOpenIDByUser(user_id);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetAllUsers
        ///</summary>
        [TestMethod()]
        public void GetAllUsersTest()
        {
            GrabbaRideDBDataContext target = new GrabbaRideDBDataContext(); // TODO: Initialize to an appropriate value
            IEnumerable<User> expected = null; // TODO: Initialize to an appropriate value
            IEnumerable<User> actual;
            actual = target.GetAllUsers();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for getAllRidesRecur
        ///</summary>
        [TestMethod()]
        public void getAllRidesRecurTest()
        {
            GrabbaRideDBDataContext target = new GrabbaRideDBDataContext(); // TODO: Initialize to an appropriate value
            DayOfWeek day = new DayOfWeek(); // TODO: Initialize to an appropriate value
            IEnumerable<Ride> expected = null; // TODO: Initialize to an appropriate value
            IEnumerable<Ride> actual;
            actual = target.getAllRidesRecur(day);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for getAllAvalibleRides
        ///</summary>
        [TestMethod()]
        public void getAllAvalibleRidesTest()
        {
            GrabbaRideDBDataContext target = new GrabbaRideDBDataContext(); // TODO: Initialize to an appropriate value
            IEnumerable<Ride> expected = null; // TODO: Initialize to an appropriate value
            IEnumerable<Ride> actual;
            actual = target.getAllAvalibleRides();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for FindSimilarRides
        ///</summary>
        [TestMethod()]
        public void FindSimilarRidesTest()
        {
            GrabbaRideDBDataContext target = new GrabbaRideDBDataContext(); // TODO: Initialize to an appropriate value
            Ride ride = null; // TODO: Initialize to an appropriate value
            List<Ride> expected = null; // TODO: Initialize to an appropriate value
            List<Ride> actual;
            actual = target.FindSimilarRides(ride);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for DetachUser
        ///</summary>
        [TestMethod()]
        public void DetachUserTest()
        {
            GrabbaRideDBDataContext target = new GrabbaRideDBDataContext(); // TODO: Initialize to an appropriate value
            User deleteUser = null; // TODO: Initialize to an appropriate value
            target.DetachUser(deleteUser);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for DetachRide
        ///</summary>
        [TestMethod()]
        public void DetachRideTest()
        {
            GrabbaRideDBDataContext target = new GrabbaRideDBDataContext(); // TODO: Initialize to an appropriate value
            Ride oldRide = null; // TODO: Initialize to an appropriate value
            target.DetachRide(oldRide);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for DetachOpenIDsByUser
        ///</summary>
        [TestMethod()]
        public void DetachOpenIDsByUserTest()
        {
            GrabbaRideDBDataContext target = new GrabbaRideDBDataContext(); // TODO: Initialize to an appropriate value
            int user_id = 0; // TODO: Initialize to an appropriate value
            target.DetachOpenIDsByUser(user_id);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for DetachOpenID
        ///</summary>
        [TestMethod()]
        public void DetachOpenIDTest()
        {
            GrabbaRideDBDataContext target = new GrabbaRideDBDataContext(); // TODO: Initialize to an appropriate value
            string openid_url = string.Empty; // TODO: Initialize to an appropriate value
            int user_id = 0; // TODO: Initialize to an appropriate value
            target.DetachOpenID(openid_url, user_id);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for AttachRide
        ///</summary>
        [TestMethod()]
        public void AttachRideTest()
        {
            GrabbaRideDBDataContext target = new GrabbaRideDBDataContext(); // TODO: Initialize to an appropriate value
            Ride newRide = null; // TODO: Initialize to an appropriate value
            target.AttachRide(newRide);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for AttachOpenID
        ///</summary>
        [TestMethod()]
        public void AttachOpenIDTest()
        {
            GrabbaRideDBDataContext target = new GrabbaRideDBDataContext(); // TODO: Initialize to an appropriate value
            string openid_url = string.Empty; // TODO: Initialize to an appropriate value
            int user_id = 0; // TODO: Initialize to an appropriate value
            target.AttachOpenID(openid_url, user_id);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for AttachNewUser
        ///</summary>
        [TestMethod()]
        public void AttachNewUserTest()
        {
            GrabbaRideDBDataContext target = new GrabbaRideDBDataContext(); // TODO: Initialize to an appropriate value
            User newUser = null; // TODO: Initialize to an appropriate value
            target.AttachNewUser(newUser);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for GrabbaRideDBDataContext Constructor
        ///</summary>
        [TestMethod()]
        public void GrabbaRideDBDataContextConstructorTest4()
        {
            string connection = string.Empty; // TODO: Initialize to an appropriate value
            GrabbaRideDBDataContext target = new GrabbaRideDBDataContext(connection);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for GrabbaRideDBDataContext Constructor
        ///</summary>
        [TestMethod()]
        public void GrabbaRideDBDataContextConstructorTest3()
        {
            GrabbaRideDBDataContext target = new GrabbaRideDBDataContext();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for GrabbaRideDBDataContext Constructor
        ///</summary>
        [TestMethod()]
        public void GrabbaRideDBDataContextConstructorTest2()
        {
            IDbConnection connection = null; // TODO: Initialize to an appropriate value
            GrabbaRideDBDataContext target = new GrabbaRideDBDataContext(connection);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for GrabbaRideDBDataContext Constructor
        ///</summary>
        [TestMethod()]
        public void GrabbaRideDBDataContextConstructorTest1()
        {
            IDbConnection connection = null; // TODO: Initialize to an appropriate value
            MappingSource mappingSource = null; // TODO: Initialize to an appropriate value
            GrabbaRideDBDataContext target = new GrabbaRideDBDataContext(connection, mappingSource);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for GrabbaRideDBDataContext Constructor
        ///</summary>
        [TestMethod()]
        public void GrabbaRideDBDataContextConstructorTest()
        {
            string connection = string.Empty; // TODO: Initialize to an appropriate value
            MappingSource mappingSource = null; // TODO: Initialize to an appropriate value
            GrabbaRideDBDataContext target = new GrabbaRideDBDataContext(connection, mappingSource);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
