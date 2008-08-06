using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Data;
using System.Reflection;
using System.Linq.Expressions;
using System.ComponentModel;

namespace GrabbaRide.Database
{
    [Table(Name="")]
	public partial class Location : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _LocationID = default(int);
		
		private string _Name;
		
		private double _Long;
		
		private double _Lat;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnLongChanging(double value);
    partial void OnLongChanged();
    partial void OnLatChanging(double value);
    partial void OnLatChanged();
    #endregion
		
		public Location()
		{
			OnCreated();
		}


        public Location(string locationName_, long lat_, long long_)
        {
            this.Name = locationName_;
            this.Lat = lat_;
            this.Long = long_;
            OnCreated();
        }
		
		[Column(Storage="_LocationID", AutoSync=AutoSync.OnInsert, IsPrimaryKey=true, IsDbGenerated=true, UpdateCheck=UpdateCheck.Never)]
		public int LocationID
		{
			get
			{
				return this._LocationID;
			}
		}
		
		[Column(Storage="_Name", CanBeNull=false)]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[Column(Storage="_Long")]
		public double Long
		{
			get
			{
				return this._Long;
			}
			set
			{
				if ((this._Long != value))
				{
					this.OnLongChanging(value);
					this.SendPropertyChanging();
					this._Long = value;
					this.SendPropertyChanged("Long");
					this.OnLongChanged();
				}
			}
		}
		
		[Column(Storage="_Lat")]
		public double Lat
		{
			get
			{
				return this._Lat;
			}
			set
			{
				if ((this._Lat != value))
				{
					this.OnLatChanging(value);
					this.SendPropertyChanging();
					this._Lat = value;
					this.SendPropertyChanged("Lat");
					this.OnLatChanged();
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
		
		protected virtual void SendPropertyChanged(string propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
