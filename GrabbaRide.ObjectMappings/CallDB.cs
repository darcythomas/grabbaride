using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GrabbaRide.ObjectMappings
{
    class CallDB
    {

        /*
         * SubmitTrip()
         * Takes the int ID for the the city to and from locations
         * The date as a datetime.
         * The int userID
         * 
         * This then creates a new instance of a ride
         * 
         **/
       public void SubmitTrip(int nameFrom, int nameTo, DateTime date, int userID)
       {

           DataClassesDataContext context = new DataClassesDataContext();
           Ride ride = new Ride();
               
           ride.FromLocation = nameFrom;
           ride.ToLocation = nameTo;
           ride.Date = date;
           ride.UserID = userID;

           context.Rides.InsertOnSubmit(ride);
                context.SubmitChanges();
       }




        public void GetATrip(int rideID)
        {

            DataClassesDataContext context = new DataClassesDataContext();
           

            var q = from Ride r in context.Rides
                    where r.RideID == rideID
                    select new { userID = r.UserID, fromLoc = r.FromLocation, toLoc = r.ToLocation, date = r.Date };

            if (q.Count() > 0)
            {
                 //Do something with the data, pass it back to someone or some thing.
            }
            else
            {
                //Crap I dont know; you work it out.
                //i.e., no such rideID
            }


        }


        
    }
}
