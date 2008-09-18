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
            const string passwordChars = "fjdksllreifjdlfpoqFHJDSLREQPUOVXMN47382109246520,.[]'-_";

            Random r = new Random();
            string password = String.Empty;

            for (int i = 0; i < 10; i++)
            {
                int z = r.Next(passwordChars.Length);
                password += passwordChars[z];
            }

            return password;
        }
    }
}
