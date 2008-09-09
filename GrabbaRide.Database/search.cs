using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GrabbaRide.Database
{
    class search
    {

      List<Ride>  getRides(Ride submittedRide)
        {
            List<Ride> rankedRides = new List<Ride>();
          float locToll = 0.01f;
          int timeTol = 1800;
            GrabbaRideDBDataContext db = new GrabbaRideDBDataContext();

          var q = from p in db.Rides
                  where p.LocationFromLat >= (submittedRide.LocationFromLat - locToll) 
                  && p.LocationFromLat  <= (submittedRide.LocationFromLat + locToll) 
                  && p.LocationFromLong >= (submittedRide.LocationFromLong - locToll)
                  && p.LocationFromLong <= (submittedRide.LocationFromLong + locToll)
                  && p.DepartureTime >= (submittedRide.DepartureTime - timeTol)
                  && p.DepartureTime <= (submittedRide.DepartureTime + timeTol)
               select p;
             
          foreach(var p in db.Rides)
          {
              this.RideRank(p, submittedRide);
             rankedRides.Add(p);
          }
          rankedRides.Sort();
         // rankedRides.Sort(Ride r1, Ride r2) 
                 //  { return r1.SearchRank - r2.SearchRank ; });
          return rankedRides;
        }
    
     // public interface ride IComparable rideCompare{
     //     if ( 
      // }

          public class ride : IComparable<ride>
{
              /**
       public int CompareTo(object obj)
    {
        if (obj is ride)
        {
            ride p2 = (ride)obj;
            return _firstname.CompareTo(p2.Firstname);
        }
        else
            throw new ArgumentException("Object is not a Person.");
    }
    */

    #region IComparable<ride> Members

    int IComparable<ride>.CompareTo(ride other)
    {
        if (obj is Ride)
        {
            Ride r = (Ride)obj;
            return r.SearchRank;
        }
        else
            throw new ArgumentException("Object is not a ride object.");
    }

       

    #endregion
}





        Ride RideRank(Ride rr, Ride submittedRide)
        {
           double rank=0;

         float  distanceScale = 1.0f;
         float timeScale = 1.0f;


         rank += Math.Pow(1 + Math.Abs(rr.LocationFromLat - submittedRide.LocationFromLat), 2) * distanceScale;

         rank += Math.Pow(1 + Math.Abs(rr.LocationFromLong - submittedRide.LocationFromLong), 2) * distanceScale;

         rank += Math.Pow(1 + Math.Abs(rr.DepartureTime - submittedRide.DepartureTime), 2) * timeScale;
                
           rr.SearchRank = rank;

           return rr;

        }
    }
}
