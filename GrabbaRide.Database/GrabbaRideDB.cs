using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace GrabbaRide.Database
{
    partial class GrabbaRideDBDataContext
    {
        protected const string APPLICATION_NAME = "GrabbaRide";

        #region RideMappings

        public void AttachRide(Ride newRide)
        {
            newRide.CreationDate = DateTime.Now;
            this.Rides.InsertOnSubmit(newRide);
            this.SubmitChanges();
        }

        public void DetachRide(Ride oldRide)
        {
            this.Rides.DeleteOnSubmit(oldRide);
            this.SubmitChanges();
        }

        /// <summary>
        /// Gets the ride owned by the id
        /// </summary>
        /// <param name="rideID"></param>
        /// <returns></returns>
        public Ride GetRideByID(int rideID)
        {
            var query = from r in Rides
                        where r.RideID == rideID
                        select r;

            if (query.Count() == 0) { return null; }
            else { return query.Single(); }
        }

        /// <summary>
        /// Returns all rides avalible
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Ride> GetAllAvalibleRides()
        {
            var rides = from r in Rides
                        where r.NumSeats > 0 && r.Available
                        select r;

            return rides;
        }

        /// <summary>
        /// Returns all rides belonging to userID
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public IEnumerable<Ride> GetRidesByUserID(int userID)
        {
            var rides = from r in Rides
                        where r.UserID == userID
                        select r;

            return rides;
        }

        #endregion

        #region UserMappings

        /// <summary>
        /// Inserts a new user into the database.
        /// </summary>
        /// <param name="newUser"></param>
        public void AttachNewUser(User newUser)
        {
            this.Users.InsertOnSubmit(newUser);

            // set the CreationDate to now
            newUser.CreationDate = DateTime.Now;

            this.SubmitChanges();
        }

        /// <summary>
        /// Removes an existing user from the database.
        /// </summary>
        /// <param name="deleteUser"></param>
        public void DetachUser(User deleteUser)
        {
            this.Users.DeleteOnSubmit(deleteUser);
            this.SubmitChanges();
        }

        /// <summary>
        /// Finds a user by their user ID.
        /// </summary>
        /// <param name="userID">The user ID to search for.</param>
        /// <returns>The User object, or null if no user was found.</returns>
        public User GetUserByID(int userID)
        {
            var query = from u in Users
                        where u.UserID == userID &&
                              u.ApplicationName == APPLICATION_NAME
                        select u;

            if (query.Count() == 0) { return null; }
            else { return query.Single(); }
        }

        /// <summary>
        /// Finds a user by their username.
        /// </summary>
        /// <param name="username">The username of the user to search for.</param>
        /// <returns>The User object, or null if no user was found.</returns>
        public User GetUserByUsername(string username)
        {
            var query = from u in Users
                        where u.Username == username &&
                              u.ApplicationName == APPLICATION_NAME
                        select u;

            if (query.Count() == 0) { return null; }
            else { return query.Single(); }
        }

        /// <summary>
        /// Finds a user by the email address.
        /// </summary>
        /// <param name="email">The email of the user to search for.</param>
        /// <returns>The User object, or null if no user was found.</returns>
        public User GetUserByEmail(string email)
        {
            // is it an email?
            if (!Regex.IsMatch(email, "(?<user>[^@]+)@(?<host>.+)"))
            {
                throw new ArgumentException("Not a valid email address: emails must be \"user@host.something\"");
            }
            else
            {
                var query = from u in this.Users
                            where u.Email == email &&
                                  u.ApplicationName == APPLICATION_NAME
                            select u;

                if (query.Count() == 0) { return null; }
                else { return query.Single(); }
            }
        }

        /// <summary>
        /// Gets a list of all users.
        /// </summary>
        /// <returns>A list of all users.</returns>
        public IEnumerable<User> GetAllUsers()
        {
            return from u in this.Users
                   where u.ApplicationName == APPLICATION_NAME
                   select u;
        }

        /// <summary>
        /// Finds a user by their OpenID Url
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public User GetUserByOpenIDUrl(string url)
        {
            int id = GetOpenIDByUrl(url).UserID;
            var user = from u in this.Users
                       where u.UserID == id
                       select u;
            return user.Single();

        }

        #endregion

        #region OpenIDMappings

        /// <summary>
        /// Aelect user_id from user_openids where openid_url = openid_url 
        /// </summary>
        /// <param name="?">The url to search for</param>
        /// <returns>The unique user id mapped to the url </returns>
        public int GetUserIDByOpenIDUrl(string openIDUrl)
        {
            return GetOpenIDByUrl(openIDUrl).UserID;
        }

        /// <summary>
        /// Checks whether a given OpenID Url exists in our database.
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public bool IsOpenIDRegistered(string url)
        {
            OpenID openID = GetOpenIDByUrl(url);
            return openID != null;
        }

        /// <summary>
        /// select openid_url from user_openids where user_id = user_id 
        /// </summary>
        /// <param name="user_id"></param>
        /// <returns></returns>
        public IEnumerable<OpenID> GetOpenIDsByUserID(int userID)
        {
            var query = from o in OpenIDs
                        where o.UserID == userID
                        select o;

            return query.AsEnumerable();
        }

        /// <summary>
        /// Insert new open ID into the database
        /// </summary>
        /// <param name="?"></param>
        /// <param name="?"></param>
        public void AttachOpenID(string openid_url, int user_id)
        {
            //check if url is valid
            if (!Regex.IsMatch("(([a-zA-Z][0-9a-zA-Z+\\-\\.]*:)?/{0,2}[0-9a-zA-Z;"
                + "/?:@&=+$\\.\\-_!~*'()%]+)?(#[0-9a-zA-Z;/?:@&=+$\\.\\-_!~*'()%]+)?", openid_url))
            {
                //throw some sweet exception
                throw new ArgumentException("Not a valid Url provided for OpenID");
            }
            else
            {
                OpenID id = new OpenID(openid_url, user_id);
                this.OpenIDs.InsertOnSubmit(id);
                this.SubmitChanges();
            }
        }

        /// <summary>
        /// delete from user_openids where openid_url = openid_url and user_id = user_id 
        /// </summary>
        /// <param name="?"></param>
        /// <param name="?"></param>
        public void DetachOpenID(String openid_url, int user_id)
        {
            // not sure yet why userID is required for this ... just leave please
            this.OpenIDs.DeleteOnSubmit(this.GetOpenIDByUrl(openid_url));
            this.SubmitChanges();
        }

        /// <summary>
        /// delete from user_openids where user_id = user_id
        /// </summary>
        /// <param name="user_id"></param>
        public void DetachOpenIDsByUser(int userID)
        {
            this.OpenIDs.DeleteAllOnSubmit(this.GetOpenIDsByUserID(userID));
            this.SubmitChanges();
        }

        /// <summary>
        /// Finds an OpenID by its Url
        /// </summary>
        /// <param name="openid_url"></param>
        /// <returns></returns>
        public OpenID GetOpenIDByUrl(string url)
        {
            var query = from o in OpenIDs
                        where o.OpenIDUrl == url
                        select o;

            if (query.Count() == 0) { return null; }
            else { return query.Single(); }
        }

        #endregion
    }

    public enum Gender
    {
        Female,
        Male,
    }
}
