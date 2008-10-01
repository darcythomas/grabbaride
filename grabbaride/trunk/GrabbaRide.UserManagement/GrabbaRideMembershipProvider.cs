using System;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Web.Security;
using GrabbaRide.Database;
using GrabbaRide.UserManagement.Properties;
using DotNetOpenId.Extensions.SimpleRegistration;

namespace GrabbaRide.UserManagement
{
    public sealed class GrabbaRideMembershipProvider : MembershipProvider
    {
        /// <summary>
        /// Converts a GrabbaRideDB User into a MembershipUser
        /// </summary>
        /// <returns></returns>
        public MembershipUser GetMembershipUser(User databaseUser)
        {
            MembershipUser user = new MembershipUser("GrabbaRideMembershipProvider",
                databaseUser.Username,
                databaseUser.UserID,
                databaseUser.Email,
                databaseUser.PasswordQuestion,
                databaseUser.Comment,
                databaseUser.IsApproved,
                databaseUser.IsLockedOut,
                databaseUser.CreationDate,
                databaseUser.LastLoginDate.GetValueOrDefault(),
                databaseUser.LastActvityDate.GetValueOrDefault(),
                databaseUser.LastPasswordChangedDate.GetValueOrDefault(),
                databaseUser.LastLockoutDate.GetValueOrDefault());

            return user;
        }

        public override void Initialize(string name, NameValueCollection config)
        {
            if (String.IsNullOrEmpty(name))
            {
                name = "GrabbaRideMembershipProvider";
            }

            if (!String.IsNullOrEmpty(config["applicationName"]))
            {
                throw new NotSupportedException("ApplicationName is always 'GrabbaRide'!");
            }

            if (String.IsNullOrEmpty(config["description"]))
            {
                config.Remove("description");
                config.Add("description", "GrabbaRide Membership Provider");
            }

            // initialize the abstract base class.
            base.Initialize(name, config);
        }

        public override string ApplicationName
        {
            get { return "GrabbaRide"; }
            set { throw new NotSupportedException("ApplicationName is always 'GrabbaRide'!"); }
        }

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            if (ValidateUser(username, oldPassword))
            {
                GrabbaRideDBDataContext dataContext = new GrabbaRideDBDataContext();
                User u = dataContext.GetUserByUsername(username);

                byte[] encryptedPwd = EncryptPassword(Encoding.Unicode.GetBytes(newPassword));

                u.Password = Convert.ToBase64String(encryptedPwd);
                u.LastPasswordChangedDate = DateTime.Now;
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
            if (ValidateUser(username, password))
            {
                GrabbaRideDBDataContext dataContext = new GrabbaRideDBDataContext();
                User u = dataContext.GetUserByUsername(username);

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
            GrabbaRideDBDataContext dataContext = new GrabbaRideDBDataContext();

            // perform some tests
            if (dataContext.GetUserByUsername(username) != null)
            {
                status = MembershipCreateStatus.DuplicateUserName;
                return null;
            }

            if (dataContext.GetUserByEmail(email) != null)
            {
                status = MembershipCreateStatus.DuplicateEmail;
                return null;
            }

            if (providerUserKey != null)
            {
                // we don't support providing a user key, they are allocated
                status = MembershipCreateStatus.InvalidProviderUserKey;
                return null;
            }

            // create and populate the new user
            User u = new User();
            u.Username = username;

            byte[] encryptedPwd = EncryptPassword(Encoding.Unicode.GetBytes(password));
            u.Password = Convert.ToBase64String(encryptedPwd);
            u.LastPasswordChangedDate = DateTime.Now;

            u.Email = email;
            u.CreationDate = DateTime.Now;
            u.LastActvityDate = DateTime.Now;
            u.PasswordQuestion = passwordQuestion;
            u.PasswordAnswer = passwordAnswer;
            u.IsApproved = isApproved;
            u.ApplicationName = ApplicationName;

            // add the user to the database
            dataContext.AttachNewUser(u);


            // return the new user
            status = MembershipCreateStatus.Success;
            return GetMembershipUser(u);
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            GrabbaRideDBDataContext dataContext = new GrabbaRideDBDataContext();
            User u = dataContext.GetUserByUsername(username);
            if (u == null) { return false; }

            dataContext.Users.DeleteOnSubmit(u);
            dataContext.SubmitChanges();
            return true;
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
            // use LINQ directly here because it is very specific
            GrabbaRideDBDataContext dataContext = new GrabbaRideDBDataContext();
            MembershipUserCollection result = new MembershipUserCollection();

            var users = from u in dataContext.Users
                        where u.Email.Contains(emailToMatch)
                        orderby u.Email
                        select u;

            totalRecords = users.Count();

            foreach (User u in users.Skip(pageIndex * pageSize).Take(pageSize))
            {
                result.Add(GetMembershipUser(u));
            }

            return result;
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            // use LINQ directly here because it is very specific
            GrabbaRideDBDataContext dataContext = new GrabbaRideDBDataContext();
            MembershipUserCollection result = new MembershipUserCollection();

            var users = from u in dataContext.Users
                        where u.Username.Contains(usernameToMatch)
                        orderby u.Username
                        select u;

            totalRecords = users.Count();

            foreach (User u in users.Skip(pageIndex * pageSize).Take(pageSize))
            {
                result.Add(GetMembershipUser(u));
            }

            return result;
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            // use LINQ directly here because it is very specific
            GrabbaRideDBDataContext dataContext = new GrabbaRideDBDataContext();
            MembershipUserCollection result = new MembershipUserCollection();

            var users = from u in dataContext.Users
                        orderby u.Username
                        select u;

            totalRecords = users.Count();

            foreach (User u in users.Skip(pageIndex * pageSize).Take(pageSize))
            {
                result.Add(GetMembershipUser(u));
            }

            return result;
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

            return GetMembershipUser(u);
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

            return GetMembershipUser(u);
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
            get { return MembershipPasswordFormat.Encrypted; }
        }

        public override string PasswordStrengthRegularExpression
        {
            get { return Settings.Default.PasswordStrengthRegularExpression; }
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
                string newPassword = User.GenerateRandomPassword();
                byte[] encryptedPwd = EncryptPassword(Encoding.Unicode.GetBytes(newPassword));

                u.Password = Convert.ToBase64String(encryptedPwd);
                u.LastPasswordChangedDate = DateTime.Now;
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
            GrabbaRideDBDataContext dataContext = new GrabbaRideDBDataContext();
            User u = dataContext.GetUserByUsername(username);
            if (u == null) { return false; }

            byte[] decryptedPwd = DecryptPassword(Convert.FromBase64String(u.Password));
            if (password == Encoding.Unicode.GetString(decryptedPwd))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void OpenIDlogin(ClaimsResponse response)
        {
            
        }
    }
}
