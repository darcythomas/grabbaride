using System;
using GrabbaRide.Database;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GrabbaRide.UnitTests
{
    /// <summary>
    ///This is a test class for RideTest and is intended
    ///to contain all RideTest Unit Tests
    ///</summary>
    [TestClass()]
    public class RideTest
    {
        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext { get; set; }

        /// <summary>
        /// A test for JourneyLength
        /// </summary>
        [TestMethod()]
        public void JourneyLengthTest()
        {
            Ride target = new Ride();
            target.JourneyLength = new TimeSpan(1, 30, 0);
            TimeSpan expected = new TimeSpan(1, 30, 0);

            // check that the JourneyLength has successfully been stored and retrieved
            // (since it's actually stored as an Int64)
            Assert.AreEqual(expected, target.JourneyLength);
        }

        /// <summary>
        /// A test for DepartureTime
        /// </summary>
        [TestMethod()]
        public void DepartureTimeTest()
        {
            Ride target = new Ride();
            target.DepartureTime = new TimeSpan(17, 15, 0);
            TimeSpan expected = new TimeSpan(17, 15, 0);

            // check that the JourneyLength has successfully been stored and retrieved
            // (since it's actually stored as an Int64)
            Assert.AreEqual(expected, target.DepartureTime);
        }

        /// <summary>
        /// A test for JourneyDistance:
        /// A simple pythagoras test first.
        /// </summary>
        [TestMethod()]
        public void JourneyDistanceTest1()
        {
            Ride target = new Ride();

            // total latitude distance is 3
            target.LocationFromLat = 1;
            target.LocationToLat = 4;

            // total longitude distance is 4
            target.LocationFromLong = 5;
            target.LocationToLong = 9;

            // expect a total distance of 5
            Assert.AreEqual(5, target.JourneyDistance);
        }

        /// <summary>
        /// A test for JourneyDistance:
        /// A more difficult pythagoras test.
        /// </summary>
        [TestMethod()]
        public void JourneyDistanceTest2()
        {
            Ride target = new Ride();

            // total latitude distance is 9
            target.LocationFromLat = -109;
            target.LocationToLat = -118;

            // total longitude distance is 12
            target.LocationFromLong = 45;
            target.LocationToLong = 57;

            // expect a total distance of 15
            Assert.AreEqual(15, target.JourneyDistance);
        }

        /// <summary>
        ///A test for Ride Constructor
        ///</summary>
        [TestMethod()]
        public void RideConstructorTest()
        {
            double locFromLat = -40.3597654232865;
            double locFromLong = 175.6179141998291;
            double locToLat = -40.373694696239774;
            double locToLong = 175.5977439880371;

            Ride target = new Ride(locFromLat, locFromLong, locToLat, locToLong);

            Assert.AreEqual(locFromLat, target.LocationFromLat);
            Assert.AreEqual(locFromLong, target.LocationFromLong);
            Assert.AreEqual(locToLat, target.LocationToLat);
            Assert.AreEqual(locToLong, target.LocationToLong);
        }
    }
}
