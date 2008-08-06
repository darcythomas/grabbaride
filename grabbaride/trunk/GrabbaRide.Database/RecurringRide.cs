using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GrabbaRide.Database
{
    [Table(Name = "")]
    public partial class RecurringRide : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _RecurringRideID = default(int);

        private string _Interval;

        private System.Nullable<bool> _RecurMon;

        private System.Nullable<bool> _RecurTue;

        private System.Nullable<bool> _RecurWed;

        private System.Nullable<bool> _RecurThu;

        private System.Nullable<bool> _RecurFri;

        private System.Nullable<bool> _RecurSat;

        private System.Nullable<bool> _RecurSun;

        private System.Nullable<System.DateTime> _EndByDate;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnRecurIntervalChanging(string value);
        partial void OnRecurIntervalChanged();
        partial void OnRecurMonChanging(System.Nullable<bool> value);
        partial void OnRecurMonChanged();
        partial void OnRecurTueChanging(System.Nullable<bool> value);
        partial void OnRecurTueChanged();
        partial void OnRecurWedChanging(System.Nullable<bool> value);
        partial void OnRecurWedChanged();
        partial void OnRecurThuChanging(System.Nullable<bool> value);
        partial void OnRecurThuChanged();
        partial void OnRecurFriChanging(System.Nullable<bool> value);
        partial void OnRecurFriChanged();
        partial void OnRecurSatChanging(System.Nullable<bool> value);
        partial void OnRecurSatChanged();
        partial void OnRecurSunChanging(System.Nullable<bool> value);
        partial void OnRecurSunChanged();
        partial void OnRecurEndByDateChanging(System.Nullable<System.DateTime> value);
        partial void OnRecurEndByDateChanged();
        #endregion

        public RecurringRide()
        {
            OnCreated();
        }

        [Column(Storage = "_RecurringRideID", AutoSync = AutoSync.OnInsert, IsPrimaryKey = true, IsDbGenerated = true, UpdateCheck = UpdateCheck.Never)]
        public int RecurringRideID
        {
            get
            {
                return this._RecurringRideID;
            }
        }

        [Column(Name = "Interval", Storage = "_Interval", CanBeNull = false)]
        public string RecurInterval
        {
            get
            {
                return this._Interval;
            }
            set
            {
                if ((this._Interval != value))
                {
                    this.OnRecurIntervalChanging(value);
                    this.SendPropertyChanging();
                    this._Interval = value;
                    this.SendPropertyChanged("RecurInterval");
                    this.OnRecurIntervalChanged();
                }
            }
        }

        [Column(Storage = "_RecurMon")]
        public System.Nullable<bool> RecurMon
        {
            get
            {
                return this._RecurMon;
            }
            set
            {
                if ((this._RecurMon != value))
                {
                    this.OnRecurMonChanging(value);
                    this.SendPropertyChanging();
                    this._RecurMon = value;
                    this.SendPropertyChanged("RecurMon");
                    this.OnRecurMonChanged();
                }
            }
        }

        [Column(Storage = "_RecurTue")]
        public System.Nullable<bool> RecurTue
        {
            get
            {
                return this._RecurTue;
            }
            set
            {
                if ((this._RecurTue != value))
                {
                    this.OnRecurTueChanging(value);
                    this.SendPropertyChanging();
                    this._RecurTue = value;
                    this.SendPropertyChanged("RecurTue");
                    this.OnRecurTueChanged();
                }
            }
        }

        [Column(Storage = "_RecurWed")]
        public System.Nullable<bool> RecurWed
        {
            get
            {
                return this._RecurWed;
            }
            set
            {
                if ((this._RecurWed != value))
                {
                    this.OnRecurWedChanging(value);
                    this.SendPropertyChanging();
                    this._RecurWed = value;
                    this.SendPropertyChanged("RecurWed");
                    this.OnRecurWedChanged();
                }
            }
        }

        [Column(Storage = "_RecurThu")]
        public System.Nullable<bool> RecurThu
        {
            get
            {
                return this._RecurThu;
            }
            set
            {
                if ((this._RecurThu != value))
                {
                    this.OnRecurThuChanging(value);
                    this.SendPropertyChanging();
                    this._RecurThu = value;
                    this.SendPropertyChanged("RecurThu");
                    this.OnRecurThuChanged();
                }
            }
        }

        [Column(Storage = "_RecurFri")]
        public System.Nullable<bool> RecurFri
        {
            get
            {
                return this._RecurFri;
            }
            set
            {
                if ((this._RecurFri != value))
                {
                    this.OnRecurFriChanging(value);
                    this.SendPropertyChanging();
                    this._RecurFri = value;
                    this.SendPropertyChanged("RecurFri");
                    this.OnRecurFriChanged();
                }
            }
        }

        [Column(Storage = "_RecurSat")]
        public System.Nullable<bool> RecurSat
        {
            get
            {
                return this._RecurSat;
            }
            set
            {
                if ((this._RecurSat != value))
                {
                    this.OnRecurSatChanging(value);
                    this.SendPropertyChanging();
                    this._RecurSat = value;
                    this.SendPropertyChanged("RecurSat");
                    this.OnRecurSatChanged();
                }
            }
        }

        [Column(Storage = "_RecurSun")]
        public System.Nullable<bool> RecurSun
        {
            get
            {
                return this._RecurSun;
            }
            set
            {
                if ((this._RecurSun != value))
                {
                    this.OnRecurSunChanging(value);
                    this.SendPropertyChanging();
                    this._RecurSun = value;
                    this.SendPropertyChanged("RecurSun");
                    this.OnRecurSunChanged();
                }
            }
        }

        [Column(Name = "EndByDate", Storage = "_EndByDate")]
        public System.Nullable<System.DateTime> RecurEndByDate
        {
            get
            {
                return this._EndByDate;
            }
            set
            {
                if ((this._EndByDate != value))
                {
                    this.OnRecurEndByDateChanging(value);
                    this.SendPropertyChanging();
                    this._EndByDate = value;
                    this.SendPropertyChanged("RecurEndByDate");
                    this.OnRecurEndByDateChanged();
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
