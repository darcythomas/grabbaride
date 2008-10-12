using GrabbaRide.Database;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GrabbaRide.UnitTests
{
    /// <summary>
    ///This is a test class for OpenIDTest and is intended
    ///to contain all OpenIDTest Unit Tests
    ///</summary>
    [TestClass()]
    public class OpenIDTest
    {
        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext { get; set; }

        /// <summary>
        ///A test for OpenID Constructor
        ///</summary>
        [TestMethod()]
        public void OpenIDConstructorTest()
        {
            string url = "http://www.nowhere-test.com/myrandomOpenID48/";
            int userID = 4372891;

            OpenID target = new OpenID(url, userID);

            Assert.AreEqual(url, target.OpenIDUrl);
            Assert.AreEqual(userID, target.UserID);
        }
    }
}
