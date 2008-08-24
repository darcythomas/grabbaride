using System;

namespace GrabbaRide.Database
{
    public partial class Ride
    {
        public int SearchRank { get; set; }

        public TimeSpan DepartureTime
        {
            get { return new TimeSpan(this.DepartureTimeSrc); }
            set { this.DepartureTimeSrc = value.Ticks; }
        }

        public TimeSpan JourneyLength
        {
            get { return new TimeSpan(this.JourneyLengthSrc); }
            set { this.JourneyLengthSrc = value.Ticks; }
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
