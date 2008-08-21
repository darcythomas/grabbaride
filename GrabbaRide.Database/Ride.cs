using System;

namespace GrabbaRide.Database
{
    public partial class Ride
    {
        public int SearchRank { get; set; }

        public TimeSpan DepartureTimeSpan
        {
            get { return new TimeSpan(this.DepartureTime); }
            set { this.DepartureTime = value.Ticks; }
        }

        public TimeSpan JourneyTimeSpan
        {
            get { return new TimeSpan(this.JourneyLength); }
            set { this.JourneyLength = value.Ticks; }
        }

        public Ride(double locFromLat, double locFromLong, double locToLat, double locToLong)
            : this()
        {
            this.Available = true;
            this.CreationDate = DateTime.Now;
            this.LocationFromLat = locFromLat;
            this.LocationFromLong = locFromLong;
            this.LocationToLat = locToLat;
            this.LocationToLong = locToLong;
        }
    }
}
