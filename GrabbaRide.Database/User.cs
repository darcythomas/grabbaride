using System.Linq;
using System;

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
    }
}
