using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using GrabbaRide.Database;

namespace SystemManagement
{
    /// <summary>
    /// GrabbaRideMembershipUser is an implementation of MembershipUser which stores all properties
    /// in an underlying LINQ User object, which is then stored in SQL.
    /// So it is basically a wrapper class.
    /// </summary>
    class GrabbaRideMembershipUser : MembershipUser
    {
        /// <summary>
        /// The underlying User object.
        /// </summary>
        protected User _user;

        /// <summary>
        /// Creates a new GrabbaRideMembershipUser.
        /// </summary>
        public GrabbaRideMembershipUser()
        {
            this._user = new User();
        }

        /// <summary>
        /// Creates a GrabbaRideMembershipUser based on an existing underlying User object.
        /// </summary>
        /// <param name="user">The underlying User object.</param>
        public static GrabbaRideMembershipUser CreateFromUser(User user)
        {
            return new GrabbaRideMembershipUser(user);
        }

        protected GrabbaRideMembershipUser(User user)
        {
            this._user = user;
        }

        public override string Comment
        {
            get { return _user.Comment; }
            set { _user.Comment = value; }
        }

        public override DateTime CreationDate
        {
            get { return _user.CreationDate.GetValueOrDefault(); }
        }

        public override string Email
        {
            get { return _user.Email; }
            set { _user.Email = value; }
        }

        public override bool IsApproved
        {
            get { return _user.IsApproved; }
            set { _user.IsApproved = value; }
        }

        public override bool IsLockedOut
        {
            get { return _user.IsLockedOut; }
        }

        public override DateTime LastActivityDate
        {
            get { return _user.LastActvityDate.GetValueOrDefault(); }
            set { _user.LastActvityDate = value; }
        }

        public override DateTime LastLockoutDate
        {
            get { return _user.LastLockoutDate.GetValueOrDefault(); }
        }

        public override DateTime LastLoginDate
        {
            get { return _user.LastLoginDate.GetValueOrDefault(); }
            set { _user.LastLoginDate = value; }
        }

        public override DateTime LastPasswordChangedDate
        {
            get { return _user.LastPasswordChangedDate.GetValueOrDefault(); }
        }

        public override string PasswordQuestion
        {
            get { return _user.PasswordQuestion; }
        }

        /// <summary>
        /// Should this be hard coded as "GrabbaRideMembershipProvider"?
        /// </summary>
        public override string ProviderName
        {
            get { return base.ProviderName; }
        }

        public override object ProviderUserKey
        {
            get { return _user.UserID; }
        }

        public override string UserName
        {
            get { return _user.Username; }
        }
    }
}
