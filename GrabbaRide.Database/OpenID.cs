using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GrabbaRide.Database
{
    [Table(Name = "")]
    public partial class OpenID : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private string _OpenIDUrl;

        private int _UserID;

        private EntityRef<User> _User;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnOpenIDUrlChanging(string value);
        partial void OnOpenIDUrlChanged();
        partial void OnUserIDChanging(int value);
        partial void OnUserIDChanged();
        #endregion

        public OpenID()
        {
            this._User = default(EntityRef<User>);
            OnCreated();
        }

        [Column(Storage = "_OpenIDUrl", CanBeNull = false, IsPrimaryKey = true)]
        public string OpenIDUrl
        {
            get
            {
                return this._OpenIDUrl;
            }
            set
            {
                if ((this._OpenIDUrl != value))
                {
                    this.OnOpenIDUrlChanging(value);
                    this.SendPropertyChanging();
                    this._OpenIDUrl = value;
                    this.SendPropertyChanged("OpenIDUrl");
                    this.OnOpenIDUrlChanged();
                }
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

        [Association(Name = "User_OpenID", Storage = "_User", ThisKey = "UserID", IsForeignKey = true)]
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
                        previousValue.OpenIDs.Remove(this);
                    }
                    this._User.Entity = value;
                    if ((value != null))
                    {
                        value.OpenIDs.Add(this);
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
