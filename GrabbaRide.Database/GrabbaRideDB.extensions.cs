using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace GrabbaRide.Database
{
    public partial class Ride : INotifyPropertyChanging, INotifyPropertyChanged
    {
        public int SearchRank { get; set; }
    }

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
            Location l = new Location();
            l.Name = "Vegas";
            l.Lat = -115.136719;
            l.Long = 36.196633;
            this.Locations.InsertOnSubmit(l);

            l = new Location();
            l.Name = "Monte Carlo";
            l.Lat = 43.7398;
            l.Long = 7.4272;
            this.Locations.InsertOnSubmit(l);

            l = new Location();
            l.Name = "Atlantis";
            l.Lat = -180;
            l.Long = 180;
            this.Locations.InsertOnSubmit(l);

            l = new Location();
            l.Name = "Mt Doom, Mordor";
            l.Lat = 175.526240;
            l.Long = -39.304700;
            this.Locations.InsertOnSubmit(l);

            l = new Location();
            l.Name = "South Pole";
            l.Lat = 175.617230;
            l.Long = -180.0;
            this.Locations.InsertOnSubmit(l);

            l = new Location();
            l.Name = "New Washington";
            l.Lat = 44.395752;
            l.Long = 33.299313;
            this.Locations.InsertOnSubmit(l);

            l = new Location();
            l.Name = "Massey";
            l.Lat = 175.617779;
            l.Long = -40.385765;
            this.Locations.InsertOnSubmit(l);

            // add some sample users
            User u = new User();
            u.Username = "Darcy";
            u.Gender = Gender.Male;
            u.DateOfBirth = new DateTime(1983, 1, 1);
            this.Users.InsertOnSubmit(u);

            u = new User();
            u.Username = "Amy";
            u.Gender = Gender.Female;
            u.DateOfBirth = new DateTime(1983, 1, 1);
            this.Users.InsertOnSubmit(u);

            u = new User();
            u.Username = "Adrian";
            u.Gender = Gender.Male;
            u.DateOfBirth = new DateTime(1983, 1, 1);
            this.Users.InsertOnSubmit(u);

            u = new User();
            u.Username = "Nick";
            u.Gender = Gender.Male;
            u.DateOfBirth = new DateTime(1983, 1, 1);
            this.Users.InsertOnSubmit(u);

            u = new User();
            u.Username = "Tom";
            u.Gender = Gender.Male;
            u.DateOfBirth = new DateTime(1983, 1, 1);
            this.Users.InsertOnSubmit(u);

            u = new User();
            u.Username = "Michelle";
            u.Gender = Gender.Female;
            u.DateOfBirth = new DateTime(1983, 1, 1);
            this.Users.InsertOnSubmit(u);
        }
    }
}
