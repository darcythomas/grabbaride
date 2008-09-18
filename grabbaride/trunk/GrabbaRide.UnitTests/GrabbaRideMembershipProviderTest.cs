using GrabbaRide.UserManagement;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Security;
using System.Collections.Specialized;

namespace GrabbaRide.UnitTests
{
    
    
    /// <summary>
    ///This is a test class for GrabbaRideMembershipProviderTest and is intended
    ///to contain all GrabbaRideMembershipProviderTest Unit Tests
    ///</summary>
    [TestClass()]
    public class GrabbaRideMembershipProviderTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for RequiresUniqueEmail
        ///</summary>
        [TestMethod()]
        public void RequiresUniqueEmailTest()
        {
            GrabbaRideMembershipProvider target = new GrabbaRideMembershipProvider(); // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.RequiresUniqueEmail;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for RequiresQuestionAndAnswer
        ///</summary>
        [TestMethod()]
        public void RequiresQuestionAndAnswerTest()
        {
            GrabbaRideMembershipProvider target = new GrabbaRideMembershipProvider(); // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.RequiresQuestionAndAnswer;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for PasswordStrengthRegularExpression
        ///</summary>
        [TestMethod()]
        public void PasswordStrengthRegularExpressionTest()
        {
            GrabbaRideMembershipProvider target = new GrabbaRideMembershipProvider(); // TODO: Initialize to an appropriate value
            string actual;
            actual = target.PasswordStrengthRegularExpression;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for PasswordFormat
        ///</summary>
        [TestMethod()]
        public void PasswordFormatTest()
        {
            GrabbaRideMembershipProvider target = new GrabbaRideMembershipProvider(); // TODO: Initialize to an appropriate value
            MembershipPasswordFormat actual;
            actual = target.PasswordFormat;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for PasswordAttemptWindow
        ///</summary>
        [TestMethod()]
        public void PasswordAttemptWindowTest()
        {
            GrabbaRideMembershipProvider target = new GrabbaRideMembershipProvider(); // TODO: Initialize to an appropriate value
            int actual;
            actual = target.PasswordAttemptWindow;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for MinRequiredPasswordLength
        ///</summary>
        [TestMethod()]
        public void MinRequiredPasswordLengthTest()
        {
            GrabbaRideMembershipProvider target = new GrabbaRideMembershipProvider(); // TODO: Initialize to an appropriate value
            int actual;
            actual = target.MinRequiredPasswordLength;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for MinRequiredNonAlphanumericCharacters
        ///</summary>
        [TestMethod()]
        public void MinRequiredNonAlphanumericCharactersTest()
        {
            GrabbaRideMembershipProvider target = new GrabbaRideMembershipProvider(); // TODO: Initialize to an appropriate value
            int actual;
            actual = target.MinRequiredNonAlphanumericCharacters;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for MaxInvalidPasswordAttempts
        ///</summary>
        [TestMethod()]
        public void MaxInvalidPasswordAttemptsTest()
        {
            GrabbaRideMembershipProvider target = new GrabbaRideMembershipProvider(); // TODO: Initialize to an appropriate value
            int actual;
            actual = target.MaxInvalidPasswordAttempts;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for EnablePasswordRetrieval
        ///</summary>
        [TestMethod()]
        public void EnablePasswordRetrievalTest()
        {
            GrabbaRideMembershipProvider target = new GrabbaRideMembershipProvider(); // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.EnablePasswordRetrieval;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for EnablePasswordReset
        ///</summary>
        [TestMethod()]
        public void EnablePasswordResetTest()
        {
            GrabbaRideMembershipProvider target = new GrabbaRideMembershipProvider(); // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.EnablePasswordReset;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ApplicationName
        ///</summary>
        [TestMethod()]
        public void ApplicationNameTest()
        {
            GrabbaRideMembershipProvider target = new GrabbaRideMembershipProvider(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.ApplicationName = expected;
            actual = target.ApplicationName;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ValidateUser
        ///</summary>
        [TestMethod()]
        public void ValidateUserTest()
        {
            GrabbaRideMembershipProvider target = new GrabbaRideMembershipProvider(); // TODO: Initialize to an appropriate value
            string username = string.Empty; // TODO: Initialize to an appropriate value
            string password = string.Empty; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.ValidateUser(username, password);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for UpdateUser
        ///</summary>
        [TestMethod()]
        public void UpdateUserTest()
        {
            GrabbaRideMembershipProvider target = new GrabbaRideMembershipProvider(); // TODO: Initialize to an appropriate value
            MembershipUser mUser = null; // TODO: Initialize to an appropriate value
            target.UpdateUser(mUser);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for UnlockUser
        ///</summary>
        [TestMethod()]
        public void UnlockUserTest()
        {
            GrabbaRideMembershipProvider target = new GrabbaRideMembershipProvider(); // TODO: Initialize to an appropriate value
            string userName = string.Empty; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.UnlockUser(userName);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ResetPassword
        ///</summary>
        [TestMethod()]
        public void ResetPasswordTest()
        {
            GrabbaRideMembershipProvider target = new GrabbaRideMembershipProvider(); // TODO: Initialize to an appropriate value
            string username = string.Empty; // TODO: Initialize to an appropriate value
            string answer = string.Empty; // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.ResetPassword(username, answer);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Initialize
        ///</summary>
        [TestMethod()]
        public void InitializeTest()
        {
            GrabbaRideMembershipProvider target = new GrabbaRideMembershipProvider(); // TODO: Initialize to an appropriate value
            string name = string.Empty; // TODO: Initialize to an appropriate value
            NameValueCollection config = null; // TODO: Initialize to an appropriate value
            target.Initialize(name, config);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for GetUserNameByEmail
        ///</summary>
        [TestMethod()]
        public void GetUserNameByEmailTest()
        {
            GrabbaRideMembershipProvider target = new GrabbaRideMembershipProvider(); // TODO: Initialize to an appropriate value
            string email = string.Empty; // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.GetUserNameByEmail(email);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetUser
        ///</summary>
        [TestMethod()]
        public void GetUserTest1()
        {
            GrabbaRideMembershipProvider target = new GrabbaRideMembershipProvider(); // TODO: Initialize to an appropriate value
            string username = string.Empty; // TODO: Initialize to an appropriate value
            bool userIsOnline = false; // TODO: Initialize to an appropriate value
            MembershipUser expected = null; // TODO: Initialize to an appropriate value
            MembershipUser actual;
            actual = target.GetUser(username, userIsOnline);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetUser
        ///</summary>
        [TestMethod()]
        public void GetUserTest()
        {
            GrabbaRideMembershipProvider target = new GrabbaRideMembershipProvider(); // TODO: Initialize to an appropriate value
            object providerUserKey = null; // TODO: Initialize to an appropriate value
            bool userIsOnline = false; // TODO: Initialize to an appropriate value
            MembershipUser expected = null; // TODO: Initialize to an appropriate value
            MembershipUser actual;
            actual = target.GetUser(providerUserKey, userIsOnline);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetPassword
        ///</summary>
        [TestMethod()]
        public void GetPasswordTest()
        {
            GrabbaRideMembershipProvider target = new GrabbaRideMembershipProvider(); // TODO: Initialize to an appropriate value
            string username = string.Empty; // TODO: Initialize to an appropriate value
            string answer = string.Empty; // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.GetPassword(username, answer);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetNumberOfUsersOnline
        ///</summary>
        [TestMethod()]
        public void GetNumberOfUsersOnlineTest()
        {
            GrabbaRideMembershipProvider target = new GrabbaRideMembershipProvider(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.GetNumberOfUsersOnline();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetAllUsers
        ///</summary>
        [TestMethod()]
        public void GetAllUsersTest()
        {
            GrabbaRideMembershipProvider target = new GrabbaRideMembershipProvider(); // TODO: Initialize to an appropriate value
            int pageIndex = 0; // TODO: Initialize to an appropriate value
            int pageSize = 0; // TODO: Initialize to an appropriate value
            int totalRecords = 0; // TODO: Initialize to an appropriate value
            int totalRecordsExpected = 0; // TODO: Initialize to an appropriate value
            MembershipUserCollection expected = null; // TODO: Initialize to an appropriate value
            MembershipUserCollection actual;
            actual = target.GetAllUsers(pageIndex, pageSize, out totalRecords);
            Assert.AreEqual(totalRecordsExpected, totalRecords);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for FindUsersByName
        ///</summary>
        [TestMethod()]
        public void FindUsersByNameTest()
        {
            GrabbaRideMembershipProvider target = new GrabbaRideMembershipProvider(); // TODO: Initialize to an appropriate value
            string usernameToMatch = string.Empty; // TODO: Initialize to an appropriate value
            int pageIndex = 0; // TODO: Initialize to an appropriate value
            int pageSize = 0; // TODO: Initialize to an appropriate value
            int totalRecords = 0; // TODO: Initialize to an appropriate value
            int totalRecordsExpected = 0; // TODO: Initialize to an appropriate value
            MembershipUserCollection expected = null; // TODO: Initialize to an appropriate value
            MembershipUserCollection actual;
            actual = target.FindUsersByName(usernameToMatch, pageIndex, pageSize, out totalRecords);
            Assert.AreEqual(totalRecordsExpected, totalRecords);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for FindUsersByEmail
        ///</summary>
        [TestMethod()]
        public void FindUsersByEmailTest()
        {
            GrabbaRideMembershipProvider target = new GrabbaRideMembershipProvider(); // TODO: Initialize to an appropriate value
            string emailToMatch = string.Empty; // TODO: Initialize to an appropriate value
            int pageIndex = 0; // TODO: Initialize to an appropriate value
            int pageSize = 0; // TODO: Initialize to an appropriate value
            int totalRecords = 0; // TODO: Initialize to an appropriate value
            int totalRecordsExpected = 0; // TODO: Initialize to an appropriate value
            MembershipUserCollection expected = null; // TODO: Initialize to an appropriate value
            MembershipUserCollection actual;
            actual = target.FindUsersByEmail(emailToMatch, pageIndex, pageSize, out totalRecords);
            Assert.AreEqual(totalRecordsExpected, totalRecords);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for DeleteUser
        ///</summary>
        [TestMethod()]
        public void DeleteUserTest()
        {
            GrabbaRideMembershipProvider target = new GrabbaRideMembershipProvider(); // TODO: Initialize to an appropriate value
            string username = string.Empty; // TODO: Initialize to an appropriate value
            bool deleteAllRelatedData = false; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.DeleteUser(username, deleteAllRelatedData);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for CreateUser
        ///</summary>
        [TestMethod()]
        public void CreateUserTest()
        {
            GrabbaRideMembershipProvider target = new GrabbaRideMembershipProvider(); // TODO: Initialize to an appropriate value
            string username = string.Empty; // TODO: Initialize to an appropriate value
            string password = string.Empty; // TODO: Initialize to an appropriate value
            string email = string.Empty; // TODO: Initialize to an appropriate value
            string passwordQuestion = string.Empty; // TODO: Initialize to an appropriate value
            string passwordAnswer = string.Empty; // TODO: Initialize to an appropriate value
            bool isApproved = false; // TODO: Initialize to an appropriate value
            object providerUserKey = null; // TODO: Initialize to an appropriate value
            MembershipCreateStatus status = new MembershipCreateStatus(); // TODO: Initialize to an appropriate value
            MembershipCreateStatus statusExpected = new MembershipCreateStatus(); // TODO: Initialize to an appropriate value
            MembershipUser expected = null; // TODO: Initialize to an appropriate value
            MembershipUser actual;
            actual = target.CreateUser(username, password, email, passwordQuestion, passwordAnswer, isApproved, providerUserKey, out status);
            Assert.AreEqual(statusExpected, status);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ChangePasswordQuestionAndAnswer
        ///</summary>
        [TestMethod()]
        public void ChangePasswordQuestionAndAnswerTest()
        {
            GrabbaRideMembershipProvider target = new GrabbaRideMembershipProvider(); // TODO: Initialize to an appropriate value
            string username = string.Empty; // TODO: Initialize to an appropriate value
            string password = string.Empty; // TODO: Initialize to an appropriate value
            string newPasswordQuestion = string.Empty; // TODO: Initialize to an appropriate value
            string newPasswordAnswer = string.Empty; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.ChangePasswordQuestionAndAnswer(username, password, newPasswordQuestion, newPasswordAnswer);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ChangePassword
        ///</summary>
        [TestMethod()]
        public void ChangePasswordTest()
        {
            GrabbaRideMembershipProvider target = new GrabbaRideMembershipProvider(); // TODO: Initialize to an appropriate value
            string username = string.Empty; // TODO: Initialize to an appropriate value
            string oldPassword = string.Empty; // TODO: Initialize to an appropriate value
            string newPassword = string.Empty; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.ChangePassword(username, oldPassword, newPassword);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GrabbaRideMembershipProvider Constructor
        ///</summary>
        [TestMethod()]
        public void GrabbaRideMembershipProviderConstructorTest()
        {
            GrabbaRideMembershipProvider target = new GrabbaRideMembershipProvider();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
