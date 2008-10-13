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
        /// Returns whether the ride is available, has seats, and has good start and end dates.
        /// </summary>
        public bool IsValidAndAvailable
        {
            get
            {
                return this.Available &&
                    this.StartDate <= DateTime.Now &&
                    this.EndDate >= DateTime.Now &&
                    this.NumSeats > 0;
            }
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
                double c2 = Math.Pow(a, 2) + Math.Pow(b, 2);

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

        public string DepartureTimeString
        {
            get
            {
                return new DateTime(this.DepartureTimeSrc).ToString("h:mm tt");
            }
        }

        public string JourneyLengthString
        {
            get
            {
                return new DateTime(this.DepartureTimeSrc).ToString("H:mm");
            }
        }

        /// <summary>
        /// Gets the days of the week this ride is available, as a string.
        /// </summary>
        public string DaysAvailable
        {
            get
            {
                string days = String.Empty;
                if (this.RecurMon) { days += "Mon, "; }
                if (this.RecurTue) { days += "Tue, "; }
                if (this.RecurWed) { days += "Wed, "; }
                if (this.RecurThu) { days += "Thu, "; }
                if (this.RecurFri) { days += "Fri, "; }
                if (this.RecurSat) { days += "Sat, "; }
                if (this.RecurSun) { days += "Sun, "; }
                return days.TrimEnd(',', ' ');
            }
        }

        public string DaysAvailableICal
        {
            get
            {
                string days = String.Empty;
                if (this.RecurMon) { days += "MO,"; }
                if (this.RecurTue) { days += "TU,"; }
                if (this.RecurWed) { days += "WE,"; }
                if (this.RecurThu) { days += "TH,"; }
                if (this.RecurFri) { days += "FR,"; }
                if (this.RecurSat) { days += "SA,"; }
                if (this.RecurSun) { days += "SU,"; }
                return days.TrimEnd(',');
            }
        }

        public string HiddenFieldStart
        {
            get
            {
                return String.Format("{0},{1}",
                    this.LocationFromLat,
                    this.LocationFromLong);
            }
            set
            {
                string[] location = value.Split(',');

                if (location.Length == 2)
                {
                    this.LocationFromLat = Double.Parse(location[0]);
                    this.LocationFromLong = Double.Parse(location[1]);
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }

        public string HiddenFieldEnd
        {
            get
            {
                return String.Format("{0},{1}",
                    this.LocationToLat,
                    this.LocationToLong);
            }
            set
            {
                string[] location = value.Split(',');

                if (location.Length == 2)
                {
                    this.LocationToLat = Double.Parse(location[0]);
                    this.LocationToLong = Double.Parse(location[1]);
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }
    }
}
