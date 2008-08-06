using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Data;
using System.Reflection;
using System.Linq.Expressions;
using System.ComponentModel;
using System;

namespace GrabbaRide.Database
{
    [Table(Name = "")]
    public partial class User : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _UserID = default(int);

        private string _FirstName;

        private string _LastName;

        private Gender _Gender;

        private System.DateTime _DOB;

        private string _Occupation;

        private string _Username;

        private string _Password;

        private string _Email;

        private EntitySet<Ride> _Rides;

        private EntitySet<OpenID> _OpenIDs;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnFirstNameChanging(string value);
        partial void OnFirstNameChanged();
        partial void OnLastNameChanging(string value);
        partial void OnLastNameChanged();
        partial void OnGenderChanging(Gender value);
        partial void OnGenderChanged();
        partial void OnDOBChanging(System.DateTime value);
        partial void OnDOBChanged();
        partial void OnOccupationChanging(string value);
        partial void OnOccupationChanged();
        partial void OnUsernameChanging(string value);
        partial void OnUsernameChanged();
        partial void OnPasswordChanging(string value);
        partial void OnPasswordChanged();
        partial void OnEmailChanging(string value);
        partial void OnEmailChanged();
        #endregion

        public User()
        {
            this._Rides = new EntitySet<Ride>(new Action<Ride>(this.attach_Rides), new Action<Ride>(this.detach_Rides));
            this._OpenIDs = new EntitySet<OpenID>(new Action<OpenID>(this.attach_OpenIDs), new Action<OpenID>(this.detach_OpenIDs));
            OnCreated();
        }

        public User(string firstName, string lastName, Gender gender, DateTime DOB, string username,
            string password, string email)
        {
            this._Rides = new EntitySet<Ride>(new Action<Ride>(this.attach_Rides), new Action<Ride>(this.detach_Rides));
            this._OpenIDs = new EntitySet<OpenID>(new Action<OpenID>(this.attach_OpenIDs), new Action<OpenID>(this.detach_OpenIDs));
            OnCreated();
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Gender = gender;
            this.DOB = DOB;
            this.Username = username;
            this.Password = password;
            this.Email = email;
            OnCreated();
        }


        [Column(Storage = "_UserID", AutoSync = AutoSync.OnInsert, IsPrimaryKey = true, IsDbGenerated = true, UpdateCheck = UpdateCheck.Never)]
        public int UserID
        {
            get
            {
                return this._UserID;
            }
        }

        [Column(Storage = "_FirstName", CanBeNull = false)]
        public string FirstName
        {
            get
            {
                return this._FirstName;
            }
            set
            {
                if ((this._FirstName != value))
                {
                    this.OnFirstNameChanging(value);
                    this.SendPropertyChanging();
                    this._FirstName = value;
                    this.SendPropertyChanged("FirstName");
                    this.OnFirstNameChanged();
                }
            }
        }

        [Column(Storage = "_LastName", CanBeNull = false)]
        public string LastName
        {
            get
            {
                return this._LastName;
            }
            set
            {
                if ((this._LastName != value))
                {
                    this.OnLastNameChanging(value);
                    this.SendPropertyChanging();
                    this._LastName = value;
                    this.SendPropertyChanged("LastName");
                    this.OnLastNameChanged();
                }
            }
        }

        [Column(Storage = "_Gender", CanBeNull = false)]
        public Gender Gender
        {
            get
            {
                return this._Gender;
            }
            set
            {
                if ((this._Gender != value))
                {
                    this.OnGenderChanging(value);
                    this.SendPropertyChanging();
                    this._Gender = value;
                    this.SendPropertyChanged("Gender");
                    this.OnGenderChanged();
                }
            }
        }

        [Column(Storage = "_DOB")]
        public System.DateTime DOB
        {
            get
            {
                return this._DOB;
            }
            set
            {
                if ((this._DOB != value))
                {
                    this.OnDOBChanging(value);
                    this.SendPropertyChanging();
                    this._DOB = value;
                    this.SendPropertyChanged("DOB");
                    this.OnDOBChanged();
                }
            }
        }

        [Column(Storage = "_Occupation")]
        public string Occupation
        {
            get
            {
                return this._Occupation;
            }
            set
            {
                if ((this._Occupation != value))
                {
                    this.OnOccupationChanging(value);
                    this.SendPropertyChanging();
                    this._Occupation = value;
                    this.SendPropertyChanged("Occupation");
                    this.OnOccupationChanged();
                }
            }
        }

        [Column(Storage = "_Username", CanBeNull = false)]
        public string Username
        {
            get
            {
                return this._Username;
            }
            set
            {
                if ((this._Username != value))
                {
                    this.OnUsernameChanging(value);
                    this.SendPropertyChanging();
                    this._Username = value;
                    this.SendPropertyChanged("Username");
                    this.OnUsernameChanged();
                }
            }
        }

        [Column(Storage = "_Password", CanBeNull = false)]
        public string Password
        {
            get
            {
                return this._Password;
            }
            set
            {
                if ((this._Password != value))
                {
                    this.OnPasswordChanging(value);
                    this.SendPropertyChanging();
                    this._Password = value;
                    this.SendPropertyChanged("Password");
                    this.OnPasswordChanged();
                }
            }
        }

        [Column(Storage = "_Email", CanBeNull = false)]
        public string Email
        {
            get
            {
                return this._Email;
            }
            set
            {
                if ((this._Email != value))
                {
                    this.OnEmailChanging(value);
                    this.SendPropertyChanging();
                    this._Email = value;
                    this.SendPropertyChanged("Email");
                    this.OnEmailChanged();
                }
            }
        }

        [Association(Name = "User_Ride", Storage = "_Rides", OtherKey = "UserID")]
        public EntitySet<Ride> Rides
        {
            get
            {
                return this._Rides;
            }
            set
            {
                this._Rides.Assign(value);
            }
        }

        [Association(Name = "User_OpenID", Storage = "_OpenIDs", OtherKey = "UserID")]
        public EntitySet<OpenID> OpenIDs
        {
            get
            {
                return this._OpenIDs;
            }
            set
            {
                this._OpenIDs.Assign(value);
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

        private void attach_Rides(Ride entity)
        {
            this.SendPropertyChanging();
            entity.User = this;
        }

        private void detach_Rides(Ride entity)
        {
            this.SendPropertyChanging();
            entity.User = null;
        }

        private void attach_OpenIDs(OpenID entity)
        {
            this.SendPropertyChanging();
            entity.User = this;
        }

        private void detach_OpenIDs(OpenID entity)
        {
            this.SendPropertyChanging();
            entity.User = null;
        }
    }
}
