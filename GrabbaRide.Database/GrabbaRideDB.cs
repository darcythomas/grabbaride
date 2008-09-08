using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace GrabbaRide.Database
{
    partial class GrabbaRideDBDataContext
    {
        #region RideMappings

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

        /// <summary>
        /// Finds a user by their user ID.
        /// </summary>
        /// <param name="userID">The user ID to search for.</param>
        /// <returns>The User object, or null if no user was found.</returns>
        public User GetUserByID(int userID)
        {
            var query = from u in Users
                        where u.UserID == userID
                        select u;

            return query.Single();
        }

        /// <summary>
        /// Finds a user by their username.
        /// </summary>
        /// <param name="username">The username of the user to search for.</param>
        /// <returns>The User object, or null if no user was found.</returns>
        public User GetUserByUsername(string username)
        {
            var query = from u in Users
                        where u.Username == username
                        select u;

            return query.Single();
        }

        public IEnumerable<User> GetAllUsers()
        {
            return from u in this.Users
                   select u;
        }

        public IEnumerable<User> GetUser_SortByUserName()
        {
            return from u in this.Users
                   orderby u.Username
                   select u;
        }

        public IEnumerable<User> GetUser_SortByOccupation()
        {
            return from u in this.Users
                   orderby u.Occupation
                   select u;
        }

        public IEnumerable<User> GetUser_SortByLastActvityDate()
        {
            return from u in this.Users
                   orderby u.LastActvityDate
                   select u;
        }

        public User GetUserByEmail(String email)
        {
            // is it an email?
            if (!Regex.IsMatch(email, "(?<user>[^@]+)@(?<host>.+)"))
            {
                throw new ArgumentException("Not a valid email address: emails must be \"user@host.something\"");
            }
            else
            {
                var query = from u in this.Users
                            where u.Email == email
                            select u;

                return query.Single();
            }

        }

        #endregion
    }

    public enum Gender
    {
        Female,
        Male,
    }
}
