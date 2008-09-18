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
            this.Rides.Attach(newRide);
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

            return query.Single();
        }

        /// <summary>
        /// Returns All rides after the specifed date
        /// </summary>
        /// <param name="afterDate"></param>
        /// <returns></returns>
        public IEnumerable<Ride> getRidesAfterDate(DateTime afterDate)
        {

            var rides = from r in Rides
                        where r.StartDate >= afterDate
                        select r;
            return rides;
        }

        /// <summary>
        /// Returns all rides before the specifed date
        /// </summary>
        /// <param name="beforeDate"></param>
        /// <returns></returns>
        public IEnumerable<Ride> getRidesBeforeDate(DateTime beforeDate)
        {

            var rides = from r in Rides
                        where r.EndDate <= beforeDate
                        select r;
            return rides;
        }

        /// <summary>
        /// Returns all rides between the specifed Dates
        /// </summary>
        /// <param name="beforeDate"></param>
        /// <param name="afterDate"></param>
        /// <returns></returns>
        public IEnumerable<Ride> getRidesBetween(DateTime beforeDate, DateTime afterDate)
        {
            var rides = from r in Rides
                        where r.StartDate >= afterDate && r.EndDate <= beforeDate
                        select r;
            return rides;

        }

        /// <summary>
        /// Returns all rides avalible
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Ride> getAllAvalibleRides()
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
        public IEnumerable<Ride> getUserRides(int userID)
        {
            var rides = from r in Rides
                        where r.UserID == userID
                        select r;
            return rides;
        }

        /// <summary>
        /// Returns all rides that reocur for a given day
        /// Day is an enum dayofweek
        /// </summary>
        /// <param name="day"></param>
        /// <returns></returns>
        public IEnumerable<Ride> getAllRidesRecur(DayOfWeek day)
        {
            IEnumerable<Ride> rides = null;

            switch (day)
            {
                case DayOfWeek.Monday: rides = from r in this.Rides
                                               where r.RecurMon
                                               select r;
                    break;
                case DayOfWeek.Tuesday: rides = from r in this.Rides
                                                where r.RecurTue
                                                select r;
                    break;
                case DayOfWeek.Wednesday: rides = from r in this.Rides
                                                  where r.RecurWed
                                                  select r;
                    break;
                case DayOfWeek.Thursday: rides = from r in this.Rides
                                                 where r.RecurThu
                                                 select r;
                    break;
                case DayOfWeek.Friday: rides = from r in this.Rides
                                               where r.RecurMon
                                               select r;
                    break;
                case DayOfWeek.Saturday: rides = from r in this.Rides
                                                 where r.RecurSat
                                                 select r;
                    break;
                case DayOfWeek.Sunday: rides = from r in this.Rides
                                               where r.RecurSun
                                               select r;
                    break;
            }

            return rides;
        }

        #endregion

        #region UserMappings

        public void AttachNewUser(User newUser)
        {
            this.Users.InsertOnSubmit(newUser);
            this.SubmitChanges();
        }

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

        public IEnumerable<User> GetUser_SortByUserName()
        {
            return from u in this.Users
                   where u.ApplicationName == APPLICATION_NAME
                   orderby u.Username
                   select u;
        }

        public IEnumerable<User> GetUser_SortByOccupation()
        {
            return from u in this.Users
                   where u.ApplicationName == APPLICATION_NAME
                   orderby u.Occupation
                   select u;
        }

        public User GetUser_ByOpenID(String url)
        { 
            int id= GetOpenIDsByURL(url).UserID;
            var user= from u in this.Users
                   where u.UserID == id
                   select u;
            return user.Single();
                   
        }

        public IEnumerable<User> GetUser_SortByLastActvityDate()
        {
            return from u in this.Users
                   where u.ApplicationName == APPLICATION_NAME
                   orderby u.LastActvityDate
                   select u;
        }

        #endregion

        #region OpenIDMappings

        /// <summary>
        /// Aelect user_id from user_openids where openid_url = openid_url 
        /// </summary>
        /// <param name="?">The url to search for</param>
        /// <returns>The unique user id mapped to the url </returns>
        public int GetUserId(string openid_url)
        {
            var query = from url in this.OpenIDs
                        where url.OpenIDUrl == openid_url
                        select url.UserID;

            return query.Single();
        }


        public Boolean IsOpenIDRegistered(string url)
        {
            return (GetOpenIDsByURL(url) != null);
        }

        /// <summary>
        /// select openid_url from user_openids where user_id = user_id 
        /// </summary>
        /// <param name="user_id"></param>
        /// <returns></returns>
        public OpenID GetOpenIDByUser(int user_id)
        {
            var user = from u in this.OpenIDs
                              where u.UserID == user_id
                              select u;
            return user.Single();
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
                + "/?:@&=+$\\.\\-_!~*'()%]+)?(#[0-9a-zA-Z;/?:@&=+$\\.\\-_!~*'()%]+)?",openid_url))
            {
                //throw some sweet exception
                throw new ArgumentException("Not a valid Url provided for OpenID");
            }
            else
            {
                OpenID id = new OpenID(openid_url, user_id);
                this.OpenIDs.Attach(id);
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
            this.OpenIDs.DeleteOnSubmit(this.GetOpenIDsByURL(openid_url));
            this.SubmitChanges();
        }


        /// <summary>
        /// delete from user_openids where user_id = user_id
        /// </summary>
        /// <param name="user_id"></param>
        public void DetachOpenIDsByUser(int user_id)
        {
            this.OpenIDs.DeleteOnSubmit(this.GetOpenIDsByUser(user_id));
            this.SubmitChanges();
        }

        private OpenID GetOpenIDsByUser(int user_id)
        {
            var id = from oid in this.OpenIDs
                     where oid.UserID == user_id
                     select oid;
            return id.Single();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="openid_url"></param>
        /// <returns></returns>
        public OpenID GetOpenIDsByURL(string openid_url)
        {
            var id = from oid in this.OpenIDs
                                where oid.OpenIDUrl == openid_url
                                select oid;
            return id.Single();
        }
        
        





        #endregion
    }

    public enum Gender
    {
        Female,
        Male,
    }
}
