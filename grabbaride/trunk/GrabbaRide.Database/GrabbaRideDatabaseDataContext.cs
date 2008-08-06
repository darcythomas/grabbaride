

namespace GrabbaRide.Database
{
    using System.Data.Linq.Mapping;

    public partial class GrabbaRideDBDataContext : System.Data.Linq.DataContext
    {

        private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();

        #region Extensibility Method Definitions
        partial void OnCreated();
        partial void InsertRide(Ride instance);
        partial void UpdateRide(Ride instance);
        partial void DeleteRide(Ride instance);
        partial void InsertLocation(Location instance);
        partial void UpdateLocation(Location instance);
        partial void DeleteLocation(Location instance);
        partial void InsertUser(User instance);
        partial void UpdateUser(User instance);
        partial void DeleteUser(User instance);
        partial void InsertRecurringRide(RecurringRide instance);
        partial void UpdateRecurringRide(RecurringRide instance);
        partial void DeleteRecurringRide(RecurringRide instance);
        partial void InsertOpenID(OpenID instance);
        partial void UpdateOpenID(OpenID instance);
        partial void DeleteOpenID(OpenID instance);
        #endregion

        public GrabbaRideDBDataContext() :
            base(global::GrabbaRide.Database.Properties.Settings.Default.GrabbaRideDBConnectionString, mappingSource)
        {
            OnCreated();
        }

        public GrabbaRideDBDataContext(string connection) :
            base(connection, mappingSource)
        {
            OnCreated();
        }

        public GrabbaRideDBDataContext(System.Data.IDbConnection connection) :
            base(connection, mappingSource)
        {
            OnCreated();
        }

        public GrabbaRideDBDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) :
            base(connection, mappingSource)
        {
            OnCreated();
        }

        public GrabbaRideDBDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) :
            base(connection, mappingSource)
        {
            OnCreated();
        }

        public System.Data.Linq.Table<Ride> Rides
        {
            get
            {
                return this.GetTable<Ride>();
            }
        }

        public System.Data.Linq.Table<Location> Locations
        {
            get
            {
                return this.GetTable<Location>();
            }
        }

        public System.Data.Linq.Table<User> Users
        {
            get
            {
                return this.GetTable<User>();
            }
        }

        public System.Data.Linq.Table<RecurringRide> RecurringRides
        {
            get
            {
                return this.GetTable<RecurringRide>();
            }
        }

        public System.Data.Linq.Table<OpenID> OpenIDs
        {
            get
            {
                return this.GetTable<OpenID>();
            }
        }
    }

}
