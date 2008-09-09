using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GrabbaRide.Database
{
    partial class GrabbaRideDBDataContext
    {
        /// <summary>
        /// Finds Rides in the DB which are similar to the submitted param ride object
        /// </summary>
        /// <param name="submittedRide"></param>
        /// <returns>A list of Ride objects found in the DB which are similar to the submittedRide param. 
        /// The list is ranked based on similarty to the param submittedRide</returns>
        public List<Ride> FindSimilarRides(Ride submittedRide)
        {
            List<Ride> rankedRides = new List<Ride>();
            float locToll = 0.01f;
            var timeTol = 1800;

            var q = from p in this.Rides
                    where p.LocationFromLat >= (submittedRide.LocationFromLat - locToll)
                    && p.LocationFromLat <= (submittedRide.LocationFromLat + locToll)
                    && p.LocationFromLong >= (submittedRide.LocationFromLong - locToll)
                    && p.LocationFromLong <= (submittedRide.LocationFromLong + locToll)
                    && p.DepartureTime.TotalMinutes >= (submittedRide.DepartureTime.TotalMinutes - timeTol)
                    && p.DepartureTime.TotalMinutes <= (submittedRide.DepartureTime.TotalMinutes + timeTol)
                    select p;

            //This takes one of the ride returned by the LINQ db query,
            // runs the ranking algorithm (updating the SearchRank field) on it and then puts it into 
            // an array list
            foreach (var p in q)
            {
                this.RideRank(p, submittedRide);
                rankedRides.Add(p);
            }

            //This sorts the List according to the values in the SearchRank field of the Ride object
            rankedRides.Sort(delegate(Ride r1, Ride r2)
            {
                int returnValue = -1;
                if (r1.SearchRank > r2.SearchRank)
                {
                    returnValue = 1;
                }

                return returnValue;
            });

            // Return the ranked list of possibly suitable rides

            return (List<Ride>)rankedRides.AsEnumerable();
        }



        /// <summary>
        /// Sets the SearchRank value of one Ride object, based on the simalarty to another Ride object 
        /// </summary>
        /// <param name="rideToRank"></param>
        /// <param name="submittedRide"></param>
        /// <returns>A ride object the same as the rideToRank pram but with the SearchRank value modified</returns>
        Ride RideRank(Ride rideToRank, Ride submittedRide)
        {
            double rank = 0;

            float distanceScale = 1.0f;
            float timeScale = 1.0f;


            rank += Math.Pow(1 + Math.Abs(rideToRank.LocationFromLat - submittedRide.LocationFromLat), 2) * distanceScale;

            rank += Math.Pow(1 + Math.Abs(rideToRank.LocationFromLong - submittedRide.LocationFromLong), 2) * distanceScale;

            rank += Math.Pow((rideToRank.DepartureTime - submittedRide.DepartureTime).TotalMinutes, 2) * timeScale;

            rideToRank.SearchRank = rank;

            return rideToRank;

        }
    }
}
