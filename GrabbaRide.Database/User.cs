using System.Linq;

namespace GrabbaRide.Database
{
    public partial class User
    {
        public User(string username)
            : this()
        {
            this.Username = username;
        }

        public static User GetUser(string username)
        {
            GrabbaRideDBDataContext context = new GrabbaRideDBDataContext();
            var user = from u in context.Users
                       where u.Username == username
                       select u;
            return (User)user;
        }
    }
}
