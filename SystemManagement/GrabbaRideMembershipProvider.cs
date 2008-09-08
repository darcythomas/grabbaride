using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using System.Collections.Specialized;
using System.Web.Configuration;
using System.Configuration;
using System.Configuration.Provider;
using SystemManagement.Properties;
using GrabbaRide.Database;
using System.Reflection;

namespace SystemManagement
{
    public sealed class GrabbaRideMembershipProvider : MembershipProvider
    {
        public override void Initialize(string name, NameValueCollection config)
        {
            if (config == null)
            {
                throw new ArgumentNullException("config cannot be null");
            }

            if (String.IsNullOrEmpty(name))
            {
                name = "GrabbaRideMembershipProvider";
            }

            //Initialize the abstract base class.
            base.Initialize(name, config);
        }

        #region Implementation of MembershipProvider Methods

        public override string ApplicationName { get; set; }

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            GrabbaRideDBDataContext dataContext = new GrabbaRideDBDataContext();
            User u = dataContext.GetUserByUsername(username);
            if (u == null) { return false; }

            if (u.Password == oldPassword)
            {
                u.Password = newPassword;
                dataContext.SubmitChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            GrabbaRideDBDataContext dataContext = new GrabbaRideDBDataContext();
            User u = dataContext.GetUserByUsername(username);
            if (u == null) { return false; }

            if (u.Password == password)
            {
                u.PasswordQuestion = newPasswordQuestion;
                u.PasswordAnswer = newPasswordAnswer;
                dataContext.SubmitChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// We do allow password resetting.
        /// </summary>
        public override bool EnablePasswordReset
        {
            get { return true; }
        }

        /// <summary>
        /// We do not allow password retrieval, users must reset their password.
        /// </summary>
        public override bool EnablePasswordRetrieval
        {
            get { return false; }
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            throw new NotSupportedException("You cannot retrieve users' passwords, they must be reset.");
        }

        public override MembershipUser GetUser(string username, bool userIsOnline)
        {
            GrabbaRideDBDataContext dataContext = new GrabbaRideDBDataContext();
            User u = dataContext.GetUserByUsername(username);
            if (u == null) { return null; }

            if (userIsOnline)
            {
                u.LastActvityDate = DateTime.Now;
                dataContext.SubmitChanges();
            }

            return u.GetMembershipUser();
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            GrabbaRideDBDataContext dataContext = new GrabbaRideDBDataContext();
            User u = dataContext.GetUserByID((int)providerUserKey);
            if (u == null) { return null; }

            if (userIsOnline)
            {
                u.LastActvityDate = DateTime.Now;
                dataContext.SubmitChanges();
            }

            return u.GetMembershipUser();
        }

        public override string GetUserNameByEmail(string email)
        {
            GrabbaRideDBDataContext dataContext = new GrabbaRideDBDataContext();
            User u = dataContext.GetUserByEmail(email);
            return u.Username;
        }

        public override int MaxInvalidPasswordAttempts
        {
            get { return Settings.Default.MaxInvalidPasswordAttempts; }
        }

        public override int MinRequiredNonAlphanumericCharacters
        {
            get { return Settings.Default.MinRequiredNonAlphanumericCharacters; }
        }

        public override int MinRequiredPasswordLength
        {
            get { return Settings.Default.MinRequiredPasswordLength; }
        }

        public override int PasswordAttemptWindow
        {
            get { return Settings.Default.PasswordAttemptWindow; }
        }

        public override MembershipPasswordFormat PasswordFormat
        {
            get { throw new NotImplementedException(); }
        }

        public override string PasswordStrengthRegularExpression
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Our MembershipProvider requires the user to answer a password question
        /// for password reset and retrieval.
        /// </summary>
        public override bool RequiresQuestionAndAnswer
        {
            get { return true; }
        }

        /// <summary>
        /// Our MembershipProvider requires unique emails.
        /// </summary>
        public override bool RequiresUniqueEmail
        {
            get { return true; }
        }

        public override string ResetPassword(string username, string answer)
        {
            GrabbaRideDBDataContext dataContext = new GrabbaRideDBDataContext();
            User u = dataContext.GetUserByUsername(username);

            if (u.PasswordAnswer == answer)
            {
                // generate a new random password and save it to the database
                u.Password = User.GenerateRandomPassword();
                dataContext.SubmitChanges();

                // return the new password
                return u.Password;
            }
            else
            {
                throw new MembershipPasswordException("Incorrect password answer.");
            }
        }

        public override bool UnlockUser(string userName)
        {
            GrabbaRideDBDataContext dataContext = new GrabbaRideDBDataContext();
            User u = dataContext.GetUserByUsername(userName);
            if (u == null) { return false; }

            if (u.IsLockedOut == true)
                u.IsLockedOut = false;

            dataContext.SubmitChanges();
            return true;
        }

        public override void UpdateUser(MembershipUser mUser)
        {
            // find the underlying user with LINQ
            GrabbaRideDBDataContext dataContext = new GrabbaRideDBDataContext();
            User dbUser = dataContext.GetUserByID((int)mUser.ProviderUserKey);

            // update the details in the underlying User object
            if (!dbUser.Comment.Equals(mUser.Comment))
                dbUser.Comment = mUser.Comment;

            if (!dbUser.CreationDate.Equals(mUser.CreationDate))
                dbUser.CreationDate = mUser.CreationDate;

            if (!dbUser.Email.Equals(mUser.Email))
                dbUser.Email = mUser.Email;

            if (!dbUser.IsApproved.Equals(mUser.IsApproved))
                dbUser.IsApproved = mUser.IsApproved;

            if (!dbUser.IsLockedOut.Equals(mUser.IsLockedOut))
                dbUser.IsLockedOut = mUser.IsLockedOut;

            if (!dbUser.LastActvityDate.Equals(mUser.LastActivityDate))
                dbUser.LastActvityDate = mUser.LastActivityDate;

            if (!dbUser.LastLockoutDate.Equals(mUser.LastLockoutDate))
                dbUser.LastLockoutDate = mUser.LastLockoutDate;

            if (!dbUser.LastLoginDate.Equals(mUser.LastLoginDate))
                dbUser.LastLoginDate = mUser.LastLoginDate;

            if (!dbUser.LastPasswordChangedDate.Equals(mUser.LastPasswordChangedDate))
                dbUser.LastPasswordChangedDate = mUser.LastPasswordChangedDate;

            if (!dbUser.PasswordQuestion.Equals(mUser.PasswordQuestion))
                dbUser.PasswordQuestion = mUser.PasswordQuestion;

            if (!dbUser.Username.Equals(mUser.UserName))
                dbUser.Username = mUser.UserName;

            // save back to the database
            dataContext.SubmitChanges();
        }

        public override bool ValidateUser(string username, string password)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
