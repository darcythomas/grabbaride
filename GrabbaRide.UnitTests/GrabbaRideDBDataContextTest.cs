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
        /// Cleans up between each test in this class.
        /// </summary>
        [TestCleanupAttribute()]
        public void TestCleanup()
        {
            GrabbaRideDBDataContext dc = NewTestDataContext();
            
            // check for test ride
            Ride testRide = NewTestRide();
            if (dc.GetRideByID(testRide.RideID) != null)
            {
                dc.DetachRide(testRide);
            }

            // check for test user
            User testUser = NewTestUser();
            if (dc.GetUserByID(testUser.UserID) != null)
            {
                dc.DetachUser(testUser);
            }
        }

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
        public User NewTestUser()
        {
            User u = new User();
            u.Username = "sEri0uslyR4nd0m";
            u.Email = "sEri0uslyR4nd0m@rand0mma1l.com";
            u.Password = String.Empty;
            u.ApplicationName = "GrabbaRide";

            return u;
        }

        /// <summary>
        /// Creates a new Ride, initialised with valid test values (minus the ride's user).
        /// </summary>
        /// <returns></returns>
        public Ride NewTestRide()
        {
            Ride r = new Ride();
            r.LocationFromLat = -40.3597654232865;
            r.LocationFromLong = 175.6179141998291;
            r.LocationToLat = -40.373694696239774;
            r.LocationToLong = 175.5977439880371;
            r.StartDate = new DateTime(2007, 3, 17);
            r.EndDate = new DateTime(2010, 6, 12);
            r.DepartureTime = new TimeSpan(9, 30, 0);
            r.JourneyLength = new TimeSpan(0, 40, 0);

            return r;
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
        /// A test for GetUserByUsername
        /// </summary>
        [TestMethod()]
        public void GetUserByUsernameTestValid()
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
        public void GetUserByUsernameTestNull()
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
        public void GetUserByIDTestValid()
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
        public void GetUserByIDTestNull()
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
        public void GetUserByEmailTestValid()
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
        public void GetUserByEmailTestNull()
        {
            GrabbaRideDBDataContext target = NewTestDataContext();

            // look for them in the db
            User foundUser = target.GetUserByEmail("th1s3ma1ld0esnt@n0ex1st.com");

            // check that the user can not be found
            Assert.IsNull(foundUser);
        }

        /// <summary>
        ///A test for GetRideByID
        ///</summary>
        [TestMethod()]
        public void GetRideByIDTest()
        {
            GrabbaRideDBDataContext target = NewTestDataContext();

            // look for a ride that doesn't exist
            Ride notExistRide = target.GetRideByID(45834903);
            Assert.IsNull(notExistRide);

            // add a new user
            User newUser = NewTestUser();
            target.AttachNewUser(newUser);

            // add a new ride
            Ride newRide = NewTestRide();
            newRide.User = newUser;
            target.AttachRide(newRide);

            // check that the ride can be found
            Ride foundRide = target.GetRideByID(newRide.RideID);
            Assert.AreEqual(newRide.RideID, foundRide.RideID);
        }

        /// <summary>
        ///A test for GetAllUsers
        ///</summary>
        [TestMethod()]
        public void GetAllUsersTest()
        {
            GrabbaRideDBDataContext target = NewTestDataContext();

            // check that we actually found some users
            bool foundUsers = false;

            // for every user that was returned by GetAllUsers
            foreach (User u in target.GetAllUsers())
            {
                // check that the user can be found
                Assert.IsNotNull(target.GetUserByID(u.UserID));
                foundUsers = true;
            }

            if (!foundUsers)
            {
                Assert.Inconclusive("Can't test GetAllUsers(), because no users exist!");
            }
        }

        /// <summary>
        ///A test for getAllAvalibleRides
        ///</summary>
        [TestMethod()]
        public void GetAllAvalibleRidesTest()
        {
            GrabbaRideDBDataContext target = NewTestDataContext();

            // check that we actually found rides
            bool foundRides = false;

            foreach (Ride availableRide in target.GetAllAvalibleRides())
            {
                Ride foundRide = target.GetRideByID(availableRide.RideID);
                Assert.IsNotNull(foundRide);
                Assert.IsTrue(foundRide.Available);
                Assert.IsTrue(foundRide.StartDate <= DateTime.Now);
                Assert.IsTrue(foundRide.EndDate >= DateTime.Now);

                foundRides = true;
            }

            if (!foundRides)
            {
                Assert.Inconclusive("Can't test GetAllAvailableRides(), because no rides exist!");
            }
        }

        /// <summary>
        ///A test for FindSimilarRides
        ///</summary>
        [TestMethod()]
        public void FindSimilarRidesTest()
        {
            GrabbaRideDBDataContext target = NewTestDataContext();

            Ride ride = new Ride();
            ride.RecurMon = true;
            ride.DepartureTime = new TimeSpan(9, 0, 0);

            List<Ride> similarRides = target.FindSimilarRides(ride);

            if (similarRides.Count == 0)
            {
                Assert.Inconclusive("Can't test FindSimilarRides(), because no similar rides were found!");
            }

            // make sure that they are in fact similar
            foreach (Ride similarRide in similarRides)
            {
                // no more than 30 mins apart
                double minutesDifference = similarRide.DepartureTime.TotalMinutes -
                    ride.DepartureTime.TotalMinutes;
                Assert.IsTrue(Math.Abs(minutesDifference) <= 30);

                // occurs on the right days
                Assert.IsTrue(similarRide.RecurMon);

                // TODO: test locations

            }
        }

        /// <summary>
        ///A test for AttachRide and DetachRide
        ///</summary>
        [TestMethod()]
        public void AttachDetachRideTest()
        {
            GrabbaRideDBDataContext target = NewTestDataContext();

            // create a user
            User newUser = new User();
            target.AttachNewUser(newUser);

            // add a new ride
            Ride oldRide = NewTestRide();
            oldRide.User = newUser;
            target.AttachRide(oldRide);

            // check that it exists
            Assert.IsNotNull(target.GetRideByID(oldRide.RideID));

            // remove the ride
            target.DetachRide(oldRide);

            // check that it is gone
            Assert.IsNull(target.GetRideByID(oldRide.RideID));
        }

        /// <summary>
        ///A test for AttachOpenID and DetachOpenID
        ///</summary>
        [TestMethod()]
        public void AttachDetachOpenIDTest()
        {
            GrabbaRideDBDataContext target = NewTestDataContext(); // TODO: Initialize to an appropriate value
            string openid_url = string.Empty; // TODO: Initialize to an appropriate value
            int user_id = 0; // TODO: Initialize to an appropriate value
            target.AttachOpenID(openid_url, user_id);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for AttachNewUser and DetachUser
        ///</summary>
        [TestMethod()]
        public void AttachDetachNewUserTest()
        {
            GrabbaRideDBDataContext target = NewTestDataContext();

            // add a new user
            User deleteUser = NewTestUser();
            target.AttachNewUser(deleteUser);

            // check that they exist
            Assert.IsNotNull(target.GetUserByID(deleteUser.UserID));

            // delete the user
            target.DetachUser(deleteUser);

            // check that they do not exist
            Assert.IsNull(target.GetUserByID(deleteUser.UserID));
        }
    }
}
