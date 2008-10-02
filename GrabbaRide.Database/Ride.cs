using System;

namespace GrabbaRide.Database
{
    public partial class Ride
    {
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

        /// <summary>
        /// The distance of the journey, in degrees, calcuated using sweet pythagoras.
        /// </summary>
        public double JourneyDistance
        {
            get
            {
                // a^2 + b^2 = c^2
                double a = this.LocationToLat - this.LocationFromLat;
                double b = this.LocationToLong - this.LocationFromLong;
                double c2 = Math.Pow(a,2) + Math.Pow(b,2);

                return Math.Sqrt(c2);
            }
        }

        /// <summary>
        /// The distance of the journey, in kilometers.
        /// </summary>
        public double JourneyDistanceKm
        {
            get
            {
                // this is pretty approximate
                return JourneyDistance * 111;
            }
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
