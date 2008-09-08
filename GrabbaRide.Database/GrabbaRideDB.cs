using System;
using System.Linq;
using System.Collections.Generic;


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
        public  Ride getRide(int rideID)
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
                        where r.DepartureTime >= afterDate
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
                        where r.DepartureTime <= beforeDate
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
                        where r.DepartureTime >= afterDate
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
                        where r.NumSeats>0 && r.Available
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
            var rides;
            switch (day) 
            {
                case DayOfWeek.Monday: rides = from r in this.Rides
                                                   where r.RecurMon
                                                   select r;
                                         return (List<Ride>)rides;
                case DayOfWeek.Tuesday: rides = from r in this.Rides
                                                   where r.RecurTue
                                                   select r;
                                         return (List<Ride>)rides;
                case DayOfWeek.Wednesday: rides = from r in this.Rides
                                                   where r.RecurWed
                                                   select r;
                                         return (List<Ride>)rides;
                case DayOfWeek.Thursday: rides = from r in this.Rides
                                                   where r.RecurThu
                                                   select r;
                                         return (List<Ride>)rides;
                case DayOfWeek.Friday:  rides = from r in this.Rides
                                                   where r.RecurMon
                                                   select r;
                                         return (List<Ride>)rides;
                case DayOfWeek.Saturday: rides = from r in this.Rides
                                                   where r.RecurSat
                                                   select r;
                                         return (List<Ride>)rides;
                case DayOfWeek.Sunday:  rides = from r in this.Rides
                                                   where r.RecurSun
                                                   select r;
                                         return (List<Ride>)rides;
               
            }
        }


      



        #endregion

        #region UserMappings

        public static User GetUser(string username)
        {
            GrabbaRideDBDataContext context = new GrabbaRideDBDataContext();
            var user = from u in context.Users
                       where u.Username == username
                       select u;
            return (User)user;
        }
        #endregion
    }

    public enum Gender
    {
        Female,
        Male,
    }
}
