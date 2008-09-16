using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GrabbaRide.Database
{
    partial class GrabbaRideDBDataContext
    {
        const double DISTANCE_VECTOR = 0.1;
        const double TIME_VECTOR = 0.5;

        /// <summary>
        /// Finds Rides in the DB which are similar to the submitted param ride object
        /// </summary>
        /// <param name="submittedRide"></param>
        /// <returns>A list of Ride objects found in the DB which are similar to the submittedRide param. 
        /// The list is ranked based on similarty to the param submittedRide</returns>
        public List<Ride> FindSimilarRides(Ride ride)
        {
            var query = from r in Rides
                        where
                            // rides are similar in location
                              r.LocationFromLat >= (ride.LocationFromLat - DISTANCE_VECTOR) &&
                              r.LocationFromLat <= (ride.LocationFromLat + DISTANCE_VECTOR) &&
                              r.LocationFromLong >= (ride.LocationFromLong - DISTANCE_VECTOR) &&
                              r.LocationFromLong <= (ride.LocationFromLong + DISTANCE_VECTOR) &&
                            // rides are on the right days
                              (r.RecurMon || !ride.RecurMon) &&
                              (r.RecurTue || !ride.RecurTue) &&
                              (r.RecurWed || !ride.RecurWed) &&
                              (r.RecurThu || !ride.RecurThu) &&
                              (r.RecurFri || !ride.RecurFri) &&
                              (r.RecurSat || !ride.RecurSat) &&
                              (r.RecurSun || !ride.RecurSun)
                        select r;

            // cut out rides that aren't similar in time (the DepartureTime field doesn't
            // exist on the server, so has to be done separately)
            List<Ride> result = query.Where(delegate(Ride r)
            {
                return r.DepartureTime.TotalHours >= (ride.DepartureTime.TotalHours - TIME_VECTOR) &&
                       r.DepartureTime.TotalHours <= (ride.DepartureTime.TotalHours + TIME_VECTOR);
            }).ToList();

            //This sorts the List according to the values in the SearchRank field of the Ride object
            result.Sort(new SimilarRideComparer(ride));

            // Return the ranked list of possibly suitable rides
            return result;
        }
    }

    /// <summary>
    /// Ranks two rides based on their similarity to a base ride specified
    /// in the constructor.
    /// </summary>
    class SimilarRideComparer : IComparer<Ride>
    {
        private Ride baseRide;

        private SimilarRideComparer() { }
        public SimilarRideComparer(Ride baseRide)
        {
            this.baseRide = baseRide;
        }

        public int Compare(Ride r1, Ride r2)
        {
            // find the distance between the two rides (a^2 + b^2 = c^2)
            double r1Distance = Math.Pow(r1.LocationFromLat - baseRide.LocationFromLat, 2) +
                                Math.Pow(r1.LocationFromLong - baseRide.LocationFromLong, 2) +
                                Math.Pow(r1.LocationToLat - baseRide.LocationToLat, 2) +
                                Math.Pow(r1.LocationToLong - baseRide.LocationToLong, 2);
            double r2Distance = Math.Pow(r2.LocationFromLat - baseRide.LocationFromLat, 2) +
                                Math.Pow(r2.LocationFromLong - baseRide.LocationFromLong, 2) +
                                Math.Pow(r2.LocationToLat - baseRide.LocationToLat, 2) +
                                Math.Pow(r2.LocationToLong - baseRide.LocationToLong, 2);

            // find the time between the two rides
            double r1Time = Math.Pow((r1.DepartureTime - baseRide.DepartureTime).TotalHours, 2);
            double r2Time = Math.Pow((r2.DepartureTime - baseRide.DepartureTime).TotalHours, 2);

            // find the total score for each ride
            double r1Total = r1Distance + r1Time;
            double r2Total = r2Distance + r2Time;

            // compare the two rides
            return (int)(r2Total - r1Total);
        }
    }
}
