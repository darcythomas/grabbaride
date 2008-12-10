using System.Text.RegularExpressions;
using System.Web.Security;
using GrabbaRide.Database;
using GrabbaRide.UserManagement;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GrabbaRide.UnitTests
{
    /// <summary>
    ///This is a test class for UserTest and is intended
    ///to contain all UserTest Unit Tests
    ///</summary>
    [TestClass()]
    public class UserTest
    {
        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext { get; set; }

        /// <summary>
        ///A test for GenerateRandomPassword
        ///</summary>
        [TestMethod()]
        public void GenerateRandomPasswordTest()
        {
            // our MembershipProvider to test password validity
            GrabbaRideMembershipProvider membershipProvider = new GrabbaRideMembershipProvider();

            // test 100 different random passwords
            for (int i = 0; i < 100; i++)
            {
                // generate a random password
                string password = User.GenerateRandomPassword();

                // see if it is valid
                bool isMatch = Regex.IsMatch(password, membershipProvider.PasswordStrengthRegularExpression);
                Assert.IsTrue(isMatch, "Generated password '{0}' does not pass validity test.", password);
            }
        }

        /// <summary>
        ///A test for User Constructor
        ///</summary>
        [TestMethod()]
        public void UserConstructorTest()
        {
            string username = "sEri0uslyR4nd0mUs3rn4me";
            User target = new User(username);
            Assert.AreEqual(username, target.Username);
        }

        /// <summary>
        ///A test for SendMessage
        ///</summary>
        [TestMethod()]
        public void SendMessageTest()
        {
            User target = new User();
            target.Email = "adrian.macneil@gmail.com";
            target.FirstName = "Adrian";
            target.LastName = "Is Fake";

            User from = new User();
            from.Email = "darcy@darcythomas.com";
            from.FirstName = "Darcy";
            from.LastName = "Is Also Fake";

            target.SendMessage("I hate you", from);

            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }
    }
}
