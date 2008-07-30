using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GrabbaRide.ObjectMappings
{
    class CallDB
    {

        public Object getRideDetails(int rideID)
        {
            DataClasses1DataContext context = new DataClasses1DataContext();

            var q = from Ride r in context.Rides
                    where r.RideID == rideID
                    select new Ride { };

            if (q.Count() > 0)
            {
                return q;
            }
            else
            {
                return null;
                //RideID not valid.
            }
        }

        public void AddRide(Ride newRide)
        {
            DataClasses1DataContext context = new DataClasses1DataContext();

            context.Rides.InsertOnSubmit(newRide);
            context.SubmitChanges();
        }

    }
}

