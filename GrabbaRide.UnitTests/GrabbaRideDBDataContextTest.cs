using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using GrabbaRide.Database;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Common;
using GrabbaRide.UnitTests.Properties;

namespace GrabbaRide.UnitTests
{
    /// <summary>
    ///This is a test class for GrabbaRideDBDataContext and is intended
    ///to contain all GrabbaRideDBDataContext Unit Tests
    ///</summary>
    [TestClass()]
    public class GrabbaRideDBDataContextTest
    {
        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext { get; set; }

        /// <summary>
        /// Creates a new GrabbaRideDBDataContext, connected to a test database.
        /// </summary>
        /// <returns>A test GrabbaRideDBDataContext.</returns>
        public static GrabbaRideDBDataContext NewTestDataContext()
        {
            return new GrabbaRideDBDataContext(Settings.Default.GrabbaRideTestDBConnectionString);
        }

        /// <summary>
        /// Creates a new User, initialised with valid test values.
        /// </summary>
        /// <returns></returns>
        public static User NewTestUser()
        {
            User u = new User();
            u.Username = "sEri0uslyR4nd0mUs3rn4me";
            u.Email = "sEri0uslyR4nd0m@rand0mma1l.com";
            u.Password = String.Empty;
            u.ApplicationName = "GrabbaRide";

            return u;
        }

        /// <summary>
        /// Creates a test database to work on, complete with test data.
        /// </summary>
        /// <param name="testContext"></param>
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            GrabbaRideDBDataContext dc = NewTestDataContext();

            // delete the test db if it exists
            if (dc.DatabaseExists())
            {
                dc.DeleteDatabase();
            }

            // create the test db
            dc.CreateDatabase();

            // populate with test data
            dc.InsertSampleData();
        }

        /// <summary>
        /// Removes the test database we have been using.
        /// </summary>
        [ClassCleanup()]
        public static void MyClassCleanup()
        {
            GrabbaRideDBDataContext dc = NewTestDataContext();
            if (dc.DatabaseExists())
            {
                dc.DeleteDatabase();
            }
        }

        /// <summary>
        ///A test for GrabbaRideDBDataContext Constructor
        ///</summary>
        [TestMethod()]
        public void CreateDatabaseTest()
        {
            GrabbaRideDBDataContext target = NewTestDataContext();

            // make sure db doesn't already exist
            if (target.DatabaseExists())
            {
                Assert.Inconclusive("We can't test database creation when it already exists.");
            }

            // create the db
            target.CreateDatabase();

            // check that db exists
            Assert.IsTrue(target.DatabaseExists());
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
        /// A test for GetUserByUsername
        /// </summary>
        [TestMethod()]
        public void GetUserByUsernameTest1()
        {
            GrabbaRideDBDataContext target = NewTestDataContext();

            // add a test user
            User newUser = NewTestUser();
            target.AttachNewUser(newUser);

            // look for them in the db
            User foundUser = target.GetUserByUsername(newUser.Username);

            // check that the user has been found
            Assert.AreEqual(newUser.UserID, foundUser.UserID);

            // remove the test user
            target.DetachUser(newUser);
        }

        /// <summary>
        /// A test for GetUserByUsername when the username doesn't exist
        /// </summary>
        [TestMethod()]
        public void GetUserByUsernameTest2()
        {
            GrabbaRideDBDataContext target = NewTestDataContext();

            User foundUser = target.GetUserByUsername("th1susern4mesh0uldn0tex1st");

            // check that the user can't be found
            Assert.IsNull(foundUser);
        }

        /// <summary>
        ///A test for GetUserByID
        ///</summary>
        [TestMethod()]
        public void GetUserByIDTest1()
        {
            GrabbaRideDBDataContext target = NewTestDataContext();

            // add a test user
            User newUser = NewTestUser();
            target.AttachNewUser(newUser);

            // look for them in the db
            User foundUser = target.GetUserByID(newUser.UserID);

            // check that the user has been found
            Assert.AreEqual(newUser.UserID, foundUser.UserID);

            // remove the test user
            target.DetachUser(newUser);
        }

        /// <summary>
        ///A test for GetUserByID where the id doesn't exist
        ///</summary>
        [TestMethod()]
        public void GetUserByIDTest2()
        {
            GrabbaRideDBDataContext target = NewTestDataContext();

            // look for them in the db
            User foundUser = target.GetUserByID(54235252);

            // check that the user can not be found
            Assert.IsNull(foundUser);
        }

        /// <summary>
        ///A test for GetUserByEmail
        ///</summary>
        [TestMethod()]
        public void GetUserByEmailTest1()
        {
            GrabbaRideDBDataContext target = NewTestDataContext();

            // add a test user
            User newUser = NewTestUser();
            target.AttachNewUser(newUser);

            // look for them in the db
            User foundUser = target.GetUserByEmail(newUser.Email);

            // check that the user has been found
            Assert.AreEqual(newUser.UserID, foundUser.UserID);

            // remove the test user
            target.DetachUser(newUser);
        }

        /// <summary>
        ///A test for GetUserByEmail
        ///</summary>
        [TestMethod()]
        public void GetUserByEmailTest2()
        {
            GrabbaRideDBDataContext target = NewTestDataContext();

            // look for them in the db
            User foundUser = target.GetUserByEmail("th1s3ma1ld0esnt@n0ex1st.com");

            // check that the user can not be found
            Assert.IsNull(foundUser);
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
            GrabbaRideDBDataContext target = NewTestDataContext();
            User newUser = NewTestUser();

            // add the user to the db
            target.AttachNewUser(newUser);

            // check that the user can be found in the db
            Assert.IsNotNull(target.GetUserByID(newUser.UserID));

            // remove the user from db
            target.DetachUser(newUser);
        }
    }
}
