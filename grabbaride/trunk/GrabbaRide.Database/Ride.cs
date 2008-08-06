
using System;
namespace GrabbaRide.Database
{

  
    
    
    public partial class Ride 
    {  
        public int SearchRank { get; set; }

        

        public Ride(int userID, int fromLocationId, int toLocationID, RecurringRide recurringRide,
                    DateTime depature, DateTime arrival)
        {
            this.UserID = userID;
            this.FromLocationID = fromLocationId;
            this.ToLocationID = toLocationID;
            this.RecurringRideID = recurringRide.RecurringRideID;
            this.ReturnRide = recurringRide;// Amy come back to this
            this.OnCreated();
        }

    }

}
