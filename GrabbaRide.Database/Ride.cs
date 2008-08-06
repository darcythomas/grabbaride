
namespace GrabbaRide.Database
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data.Linq;
    using System.Data.Linq.Mapping;
    using System.Data;
    using System.Reflection;
    using System.Linq.Expressions;
    using System.ComponentModel;
  
    
    [Table(Name = "")]
    public partial class Ride : INotifyPropertyChanging, INotifyPropertyChanged
    {  
        public int SearchRank { get; set; }

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _RideID = default(int);

        private int _UserID;

        private int _FromLocationID;

        private int _ToLocationID;

        private System.DateTime _DepartureTime;

        private System.Nullable<System.DateTime> _ArrivalTime;

        private System.Nullable<int> _ReturnRideID;

        private System.Nullable<System.DateTime> _CreationDate;

        private System.Nullable<int> _RecurringRideID;

        private EntityRef<Location> _FromLocation;

        private EntityRef<Location> _ToLocation;

        private EntityRef<User> _User;

        private EntityRef<Ride> _Ride1;

        private EntityRef<RecurringRide> _RecurringRide;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnUserIDChanging(int value);
        partial void OnUserIDChanged();
        partial void OnFromLocationIDChanging(int value);
        partial void OnFromLocationIDChanged();
        partial void OnToLocationIDChanging(int value);
        partial void OnToLocationIDChanged();
        partial void OnDepartureTimeChanging(System.DateTime value);
        partial void OnDepartureTimeChanged();
        partial void OnArrivalTimeChanging(System.Nullable<System.DateTime> value);
        partial void OnArrivalTimeChanged();
        partial void OnReturnRideIDChanging(System.Nullable<int> value);
        partial void OnReturnRideIDChanged();
        partial void OnCreationDateChanging(System.Nullable<System.DateTime> value);
        partial void OnCreationDateChanged();
        partial void OnRecurringRideIDChanging(System.Nullable<int> value);
        partial void OnRecurringRideIDChanged();
        #endregion

        public Ride()
        {
            this._FromLocation = default(EntityRef<Location>);
            this._ToLocation = default(EntityRef<Location>);
            this._User = default(EntityRef<User>);
            this._Ride1 = default(EntityRef<Ride>);
            this._RecurringRide = default(EntityRef<RecurringRide>);
            OnCreated();
        }

        [Column(Storage = "_RideID", AutoSync = AutoSync.OnInsert, IsPrimaryKey = true, IsDbGenerated = true, UpdateCheck = UpdateCheck.Never)]
        public int RideID
        {
            get
            {
                return this._RideID;
            }
        }

        [Column(Storage = "_UserID")]
        public int UserID
        {
            get
            {
                return this._UserID;
            }
            set
            {
                if ((this._UserID != value))
                {
                    if (this._User.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnUserIDChanging(value);
                    this.SendPropertyChanging();
                    this._UserID = value;
                    this.SendPropertyChanged("UserID");
                    this.OnUserIDChanged();
                }
            }
        }

        [Column(Storage = "_FromLocationID")]
        public int FromLocationID
        {
            get
            {
                return this._FromLocationID;
            }
            set
            {
                if ((this._FromLocationID != value))
                {
                    if (this._FromLocation.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnFromLocationIDChanging(value);
                    this.SendPropertyChanging();
                    this._FromLocationID = value;
                    this.SendPropertyChanged("FromLocationID");
                    this.OnFromLocationIDChanged();
                }
            }
        }

        [Column(Storage = "_ToLocationID")]
        public int ToLocationID
        {
            get
            {
                return this._ToLocationID;
            }
            set
            {
                if ((this._ToLocationID != value))
                {
                    if (this._ToLocation.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnToLocationIDChanging(value);
                    this.SendPropertyChanging();
                    this._ToLocationID = value;
                    this.SendPropertyChanged("ToLocationID");
                    this.OnToLocationIDChanged();
                }
            }
        }

        [Column(Storage = "_DepartureTime")]
        public System.DateTime DepartureTime
        {
            get
            {
                return this._DepartureTime;
            }
            set
            {
                if ((this._DepartureTime != value))
                {
                    this.OnDepartureTimeChanging(value);
                    this.SendPropertyChanging();
                    this._DepartureTime = value;
                    this.SendPropertyChanged("DepartureTime");
                    this.OnDepartureTimeChanged();
                }
            }
        }

        [Column(Storage = "_ArrivalTime")]
        public System.Nullable<System.DateTime> ArrivalTime
        {
            get
            {
                return this._ArrivalTime;
            }
            set
            {
                if ((this._ArrivalTime != value))
                {
                    this.OnArrivalTimeChanging(value);
                    this.SendPropertyChanging();
                    this._ArrivalTime = value;
                    this.SendPropertyChanged("ArrivalTime");
                    this.OnArrivalTimeChanged();
                }
            }
        }

        [Column(Storage = "_ReturnRideID")]
        public System.Nullable<int> ReturnRideID
        {
            get
            {
                return this._ReturnRideID;
            }
            set
            {
                if ((this._ReturnRideID != value))
                {
                    if (this._Ride1.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnReturnRideIDChanging(value);
                    this.SendPropertyChanging();
                    this._ReturnRideID = value;
                    this.SendPropertyChanged("ReturnRideID");
                    this.OnReturnRideIDChanged();
                }
            }
        }

        [Column(Storage = "_CreationDate")]
        public System.Nullable<System.DateTime> CreationDate
        {
            get
            {
                return this._CreationDate;
            }
            set
            {
                if ((this._CreationDate != value))
                {
                    this.OnCreationDateChanging(value);
                    this.SendPropertyChanging();
                    this._CreationDate = value;
                    this.SendPropertyChanged("CreationDate");
                    this.OnCreationDateChanged();
                }
            }
        }

        [Column(Storage = "_RecurringRideID")]
        public System.Nullable<int> RecurringRideID
        {
            get
            {
                return this._RecurringRideID;
            }
            set
            {
                if ((this._RecurringRideID != value))
                {
                    if (this._RecurringRide.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnRecurringRideIDChanging(value);
                    this.SendPropertyChanging();
                    this._RecurringRideID = value;
                    this.SendPropertyChanged("RecurringRideID");
                    this.OnRecurringRideIDChanged();
                }
            }
        }

        [Association(Name = "Location_Ride", Storage = "_FromLocation", ThisKey = "FromLocationID", IsForeignKey = true)]
        public Location FromLocation
        {
            get
            {
                return this._FromLocation.Entity;
            }
            set
            {
                if ((this._FromLocation.Entity != value))
                {
                    this.SendPropertyChanging();
                    this._FromLocation.Entity = value;
                    this.SendPropertyChanged("FromLocation");
                }
            }
        }

        [Association(Name = "Location_Ride1", Storage = "_ToLocation", ThisKey = "ToLocationID", IsForeignKey = true)]
        public Location ToLocation
        {
            get
            {
                return this._ToLocation.Entity;
            }
            set
            {
                if ((this._ToLocation.Entity != value))
                {
                    this.SendPropertyChanging();
                    this._ToLocation.Entity = value;
                    this.SendPropertyChanged("ToLocation");
                }
            }
        }

        [Association(Name = "User_Ride", Storage = "_User", ThisKey = "UserID", IsForeignKey = true)]
        public User User
        {
            get
            {
                return this._User.Entity;
            }
            set
            {
                User previousValue = this._User.Entity;
                if (((previousValue != value)
                            || (this._User.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._User.Entity = null;
                        previousValue.Rides.Remove(this);
                    }
                    this._User.Entity = value;
                    if ((value != null))
                    {
                        value.Rides.Add(this);
                        this._UserID = value.UserID;
                    }
                    else
                    {
                        this._UserID = default(int);
                    }
                    this.SendPropertyChanged("User");
                }
            }
        }

        [Association(Name = "Ride_Ride", Storage = "_Ride1", ThisKey = "ReturnRideID", IsForeignKey = true)]
        public Ride ReturnRide
        {
            get
            {
                return this._Ride1.Entity;
            }
            set
            {
                if ((this._Ride1.Entity != value))
                {
                    this.SendPropertyChanging();
                    this._Ride1.Entity = value;
                    this.SendPropertyChanged("ReturnRide");
                }
            }
        }

        [Association(Name = "RecurringRide_Ride", Storage = "_RecurringRide", ThisKey = "RecurringRideID", IsForeignKey = true)]
        public RecurringRide RecurringRideInfo
        {
            get
            {
                return this._RecurringRide.Entity;
            }
            set
            {
                if ((this._RecurringRide.Entity != value))
                {
                    this.SendPropertyChanging();
                    this._RecurringRide.Entity = value;
                    this.SendPropertyChanged("RecurringRideInfo");
                }
            }
        }

        public event PropertyChangingEventHandler PropertyChanging;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            if ((this.PropertyChanging != null))
            {
                this.PropertyChanging(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(String propertyName)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

}
