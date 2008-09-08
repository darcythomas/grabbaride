using System.Linq;
using System;
using System.Web.Security;

namespace GrabbaRide.Database
{
    public partial class User
    {
        public User(string username)
            : this()
        {
            this.Username = username;
        }

        /// <summary>
        /// Generates a random valid password.
        /// </summary>
        /// <returns></returns>
        public static string GenerateRandomPassword()
        {
            Guid g = new Guid();
            return g.ToString().Substring(1, 8);
        }

        /// <summary>
        /// Gets a MembershipUser object corresponding to this User.
        /// </summary>
        /// <returns></returns>
        public MembershipUser GetMembershipUser()
        {
            MembershipUser user = new MembershipUser("GrabbaRideMembershipProvider", this.Username,
                this.UserID, this.Email, this.PasswordQuestion, this.Comment, this.IsApproved,
                this.IsLockedOut, this.CreationDate, this.LastLoginDate.GetValueOrDefault(),
                this.LastActvityDate.GetValueOrDefault(), this.LastPasswordChangedDate.GetValueOrDefault(),
                this.LastLockoutDate.GetValueOrDefault());
            
            return user;
        }
    }
}
