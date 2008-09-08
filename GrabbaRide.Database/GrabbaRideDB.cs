using System;
using System.Linq;
using System.Collections.Generic;
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
        public Ride getRide(int rideID)
        {

            var ride = from r in this.Rides
                       where r.RideID == rideID
                       select r;
            return (Ride)ride;
        }

        /// <summary>
        /// Returns All rides after the specifed date
        /// </summary>
        /// <param name="afterDate"></param>
        /// <returns></returns>
        public List<Ride> getRidesAfterDate(DateTime afterDate)
        {

            var rides = from r in this.Rides
                        where r.StartDate >= afterDate
                        select r;
            return (List<Ride>)rides;
        }


        /// <summary>
        /// Returns all rides before the specifed date
        /// </summary>
        /// <param name="beforeDate"></param>
        /// <returns></returns>
        public List<Ride> getRidesBeforeDate(DateTime beforeDate)
        {

            var rides = from r in this.Rides
                        where r.EndDate <= beforeDate
                        select r;
            return (List<Ride>)rides;
        }


        /// <summary>
        /// Returns all rides between the specifed Dates
        /// </summary>
        /// <param name="beforeDate"></param>
        /// <param name="afterDate"></param>
        /// <returns></returns>
        public List<Ride> getRidesBetween(DateTime beforeDate, DateTime afterDate)
        {
            var rides = from r in this.getRidesBeforeDate(beforeDate)
                        where r.StartDate >= afterDate
                        select r;
            return (List<Ride>)rides;

        }


        /// <summary>
        /// Returns all rides avalible
        /// </summary>
        /// <returns></returns>
        public List<Ride> getAllAvalibleRides()
        {
            var rides = from r in this.Rides
                        where r.NumSeats > 0 && r.Available
                        select r;
            return (List<Ride>)rides;
        }

        /// <summary>
        /// Returns all rides belonging to userID
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public List<Ride> getUserRides(int userID)
        {
            var rides = from r in this.Rides
                        where r.UserID == userID
                        select r;
            return (List<Ride>)rides;
        }

        /// <summary>
        /// Returns all rides that reocur for a given day
        /// Day is an enum dayofweek
        /// </summary>
        /// <param name="day"></param>
        /// <returns></returns>
        public List<Ride> getAllRidesRecur(DayOfWeek day)
        {
            List<Ride> rides = null;

            switch (day)
            {
                case DayOfWeek.Monday: rides = (List<Ride>)from r in this.Rides
                                                           where r.RecurMon
                                                           select r;
                    break;
                case DayOfWeek.Tuesday: rides = (List<Ride>)from r in this.Rides
                                                            where r.RecurTue
                                                            select r;
                    break;
                case DayOfWeek.Wednesday: rides = (List<Ride>)from r in this.Rides
                                                              where r.RecurWed
                                                              select r;
                    break;
                case DayOfWeek.Thursday: rides = (List<Ride>)from r in this.Rides
                                                             where r.RecurThu
                                                             select r;
                    break;
                case DayOfWeek.Friday: rides = (List<Ride>)from r in this.Rides
                                                           where r.RecurMon
                                                           select r;
                    break;
                case DayOfWeek.Saturday: rides = (List<Ride>)from r in this.Rides
                                                             where r.RecurSat
                                                             select r;
                    break;
                case DayOfWeek.Sunday: rides = (List<Ride>)from r in this.Rides
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
            User result = (User)from u in Users
                                where u.UserID == userID
                                select u;
            return result;
        }

        /// <summary>
        /// Finds a user by their username.
        /// </summary>
        /// <param name="username">The username of the user to search for.</param>
        /// <returns>The User object, or null if no user was found.</returns>
        public User GetUserByUsername(string username)
        {
            User result = (User)from u in Users
                                where u.Username == username
                                select u;
            return result;
        }

        public List<User> GetAllUsers()
        {
            return (List<User>)from u in this.Users
                               select u;
        }



        public List<User> GetUser_SortByUserName()
        {
            return (List<User>)from u in this.Users
                               orderby u.Username
                               select u;
        }

        public List<User> GetUser_SortByOccupation()
        {
            return (List<User>)from u in this.Users
                               orderby u.Occupation
                               select u;
        }

        public List<User> GetUser_SortByLastActvityDate()
        {
            return (List<User>)from u in this.Users
                               orderby u.LastActvityDate
                               select u;
        }




        public User GetUserByEmail(String email)
        {
            // Is it an email

            if (!Regex.IsMatch(email, "(?<user>[^@]+)@(?<host>.+)"))
            {
                // throw some exception
                throw new ArgumentException("Not a valid email address: emails must be \"user@host.something\"");

            }
            else
            {
                User user = (User)from u in this.Users
                                  where u.Email == email

                                  select u;

                return user;
            }

        }
    }
        #endregion

    public enum Gender
    {
        Female,
        Male,
    }
}
