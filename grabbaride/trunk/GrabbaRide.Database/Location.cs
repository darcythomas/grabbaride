

namespace GrabbaRide.Database
{
    partial class Location
    {
        public Location(string locationName_, long lat_, long long_)
        {
            this.Name = locationName_;
            this.Lat = lat_;
            this.Long = long_;
            OnCreated();
        }
    }
}
