using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GrabbaRide.Database
{
    partial class GrabbaRideDBDataContext
    {
        const double DISTANCE_VECTOR = 0.1; // 10%
        const double TIME_VECTOR = 0.5; // 30 mins

        /// <summary>
        /// Finds Rides in the DB which are similar to the submitted param ride object
        /// </summary>
        /// <param name="submittedRide"></param>
        /// <returns>A list of Ride objects found in the DB which are similar to the submittedRide param. 
        /// The list is ranked based on similarty to the param submittedRide</returns>
        public List<Ride> FindSimilarRides(Ride searchedRide)
        {
            double searchRadius = searchedRide.JourneyDistance * DISTANCE_VECTOR;
            if (searchRadius == 0) { searchRadius = 0.1; }

            var query = from r in Rides
                        where
                            // rides are similar in source location
                             (searchedRide.LocationFromLat == 0 ||
                              searchedRide.LocationFromLong == 0 ||
                               (r.LocationFromLat >= (searchedRide.LocationFromLat - searchRadius) &&
                                r.LocationFromLat <= (searchedRide.LocationFromLat + searchRadius) &&
                                r.LocationFromLong >= (searchedRide.LocationFromLong - searchRadius) &&
                                r.LocationFromLong <= (searchedRide.LocationFromLong + searchRadius)))
                            // rides are similar in destination location
                          && (searchedRide.LocationToLat == 0 ||
                              searchedRide.LocationToLong == 0 ||
                              (r.LocationToLat >= (searchedRide.LocationToLat - searchRadius) &&
                               r.LocationToLat <= (searchedRide.LocationToLat + searchRadius) &&
                               r.LocationToLong >= (searchedRide.LocationToLong - searchRadius) &&
                               r.LocationToLong <= (searchedRide.LocationToLong + searchRadius)))
                            // rides are on the right days
                          && (r.RecurMon || !searchedRide.RecurMon) &&
                             (r.RecurTue || !searchedRide.RecurTue) &&
                             (r.RecurWed || !searchedRide.RecurWed) &&
                             (r.RecurThu || !searchedRide.RecurThu) &&
                             (r.RecurFri || !searchedRide.RecurFri) &&
                             (r.RecurSat || !searchedRide.RecurSat) &&
                             (r.RecurSun || !searchedRide.RecurSun)

                        select r;

            // cut out rides that aren't similar in time (the DepartureTime field doesn't
            // exist on the server, so has to be done separately)
            List<Ride> result = query.Where(delegate(Ride r)
            {
                return r.DepartureTime.TotalHours >= (searchedRide.DepartureTime.TotalHours - TIME_VECTOR) &&
                       r.DepartureTime.TotalHours <= (searchedRide.DepartureTime.TotalHours + TIME_VECTOR);
            }).ToList();

            //This sorts the List according to the values in the SearchRank field of the Ride object
            result.Sort(new SimilarRideComparer(searchedRide));

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

        const double DISTANCE_SCALE = 100000;
        const double TIME_SCALE = 10;

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
            double r1Total = r1Distance * DISTANCE_SCALE +
                             r1Time * TIME_SCALE;
            double r2Total = r2Distance * DISTANCE_SCALE +
                             r2Time * TIME_SCALE;

            // compare the two rides
            return (int)(r2Total - r1Total);
        }
    }
}
