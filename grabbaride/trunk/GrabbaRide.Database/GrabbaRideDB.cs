using System.ComponentModel;
using System.Diagnostics;
using System.Collections.Generic;
partial class GrabbaRideDBDataContext
{
}

namespace GrabbaRide.Database
{
   
    public enum Gender
    {
        Female,
        Male,
    }

    public partial class GrabbaRideDBDataContext : System.Data.Linq.DataContext
    {
        /// <summary>
        /// Fills up the database with some sample data for testing.
        /// </summary>
        public void InputSampleData()
        {
            // create some sample locations
            Debug.WriteLine("Adding sample data to database...");
           // AddSampleLocations();

           
        }


        
        

        
    }
}
