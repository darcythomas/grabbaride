using System;
using System.Linq;
using System.Collections.Generic;


namespace GrabbaRide.Database
{

    partial class GrabbaRideDBDataContext
    {

        #region RideMappings

        public  Ride getRide(Integer rideID)
        {
          
           var ride = from r in this.Rides
                      where r.RideID == rideID
                      select r;
           return (Ride)ride;
        }

        public List<Ride> getRidesAfterDate(DateTime afterDate)
        {
          
            var rides = from r in this.Rides
                        where r.DepartureTime >= afterDate
                        select r;
            return (List<Ride>)rides;
        }

        public List<Ride> getRidesBeforeDate(DateTime beforeDate)
        {
          
            var rides = from r in this.Rides
                        where r.DepartureTime <= beforeDate
                        select r;
            return (List<Ride>)rides;
        }

        public List<Ride> getRidesBetween(DateTime beforeDate, DateTime afterDate)
        {
            var rides = from r in this.getRidesBeforeDate(beforeDate)
                        where r.DepartureTime >= afterDate
                        select r;
            return (List<Ride>)rides;

        }

        public List<Ride> getAllAvalibleRides()
        {
            var rides = from r in this.Rides
                        where r.NumSeats>0 && r.Available
                        select r;
            return (List<Ride>)rides;
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
