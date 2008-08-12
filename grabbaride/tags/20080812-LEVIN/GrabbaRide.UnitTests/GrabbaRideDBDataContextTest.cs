using GrabbaRide.Database;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
             //   System.Diagnostics.Debug.WriteLine(target.Connection.Database);
                Assert.IsTrue(target.DatabaseExists(), "The database could not be successfully created!");
                target.DeleteDatabase();
            }
        }
    }
}
