
using System;
namespace GrabbaRide.Database
{

  
    
    
    public partial class Ride 
    {  
        public int SearchRank { get; set; }

        

        public Ride(int userID, int fromLocationId, int toLocationID,
                    DateTime depature, DateTime arrival)
        {
            this.UserID = userID;
            this.FromLocationID = fromLocationId;
            this.ToLocationID = toLocationID;
            this.OnCreated();
        }

    }

}
