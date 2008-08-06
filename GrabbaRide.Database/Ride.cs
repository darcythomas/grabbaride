
using System;
namespace GrabbaRide.Database
{

  
    
    
    public partial class Ride 
    {  
        public int SearchRank { get; set; }

        

        public Ride(int userID, Location fromLocation,Location toLocation,
                    DateTime depature, DateTime arrival)
        {
            this.UserID = userID;
            this.FromLocation= fromLocation;
            this.ToLocation = toLocation;
            this.OnCreated();
        }

    }

}
