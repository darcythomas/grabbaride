﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.1434
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GrabbaRide.Database
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	public partial class GrabbaRideDBDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertRide(Ride instance);
    partial void UpdateRide(Ride instance);
    partial void DeleteRide(Ride instance);
    partial void InsertUser(User instance);
    partial void UpdateUser(User instance);
    partial void DeleteUser(User instance);
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
		
		public System.Data.Linq.Table<User> Users
		{
			get
			{
				return this.GetTable<User>();
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
	
	[Table(Name="Rides")]
	public partial class Ride : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _RideID = default(int);
		
		private int _UserID;
		
		private long _DepartureTime;
		
		private long _ArrivalTime;
		
		private System.DateTime _CreationDate;
		
		private System.DateTime _StartDate;
		
		private System.DateTime _EndDate;
		
		private int _NumSeats;
		
		private bool _RecurMon;
		
		private bool _RecurTue;
		
		private bool _RecurWed;
		
		private bool _RecurThu;
		
		private bool _RecurFri;
		
		private bool _RecurSat;
		
		private bool _RecurSun;
		
		private double _LocationFromLat;
		
		private double _LocationFromLong;
		
		private double _LocationToLat;
		
		private double _LocationToLong;
		
		private bool _Available;
		
		private EntityRef<User> _User;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnUserIDChanging(int value);
    partial void OnUserIDChanged();
    partial void OnDepartureTimeSrcChanging(long value);
    partial void OnDepartureTimeSrcChanged();
    partial void OnJourneyLengthSrcChanging(long value);
    partial void OnJourneyLengthSrcChanged();
    partial void OnCreationDateChanging(System.DateTime value);
    partial void OnCreationDateChanged();
    partial void OnStartDateChanging(System.DateTime value);
    partial void OnStartDateChanged();
    partial void OnEndDateChanging(System.DateTime value);
    partial void OnEndDateChanged();
    partial void OnNumSeatsChanging(int value);
    partial void OnNumSeatsChanged();
    partial void OnRecurMonChanging(bool value);
    partial void OnRecurMonChanged();
    partial void OnRecurTueChanging(bool value);
    partial void OnRecurTueChanged();
    partial void OnRecurWedChanging(bool value);
    partial void OnRecurWedChanged();
    partial void OnRecurThuChanging(bool value);
    partial void OnRecurThuChanged();
    partial void OnRecurFriChanging(bool value);
    partial void OnRecurFriChanged();
    partial void OnRecurSatChanging(bool value);
    partial void OnRecurSatChanged();
    partial void OnRecurSunChanging(bool value);
    partial void OnRecurSunChanged();
    partial void OnLocationFromLatChanging(double value);
    partial void OnLocationFromLatChanged();
    partial void OnLocationFromLongChanging(double value);
    partial void OnLocationFromLongChanged();
    partial void OnLocationToLatChanging(double value);
    partial void OnLocationToLatChanged();
    partial void OnLocationToLongChanging(double value);
    partial void OnLocationToLongChanged();
    partial void OnAvailableChanging(bool value);
    partial void OnAvailableChanged();
    #endregion
		
		public Ride()
		{
			this._User = default(EntityRef<User>);
			OnCreated();
		}
		
		[Column(Storage="_RideID", AutoSync=AutoSync.OnInsert, IsPrimaryKey=true, IsDbGenerated=true, UpdateCheck=UpdateCheck.Never)]
		public int RideID
		{
			get
			{
				return this._RideID;
			}
		}
		
		[Column(Storage="_UserID")]
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
		
		[Column(Name="DepartureTime", Storage="_DepartureTime")]
		protected long DepartureTimeSrc
		{
			get
			{
				return this._DepartureTime;
			}
			set
			{
				if ((this._DepartureTime != value))
				{
					this.OnDepartureTimeSrcChanging(value);
					this.SendPropertyChanging();
					this._DepartureTime = value;
					this.SendPropertyChanged("DepartureTimeSrc");
					this.OnDepartureTimeSrcChanged();
				}
			}
		}
		
		[Column(Name="JourneyLength", Storage="_ArrivalTime")]
		protected long JourneyLengthSrc
		{
			get
			{
				return this._ArrivalTime;
			}
			set
			{
				if ((this._ArrivalTime != value))
				{
					this.OnJourneyLengthSrcChanging(value);
					this.SendPropertyChanging();
					this._ArrivalTime = value;
					this.SendPropertyChanged("JourneyLengthSrc");
					this.OnJourneyLengthSrcChanged();
				}
			}
		}
		
		[Column(Storage="_CreationDate")]
		public System.DateTime CreationDate
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
		
		[Column(Storage="_StartDate")]
		public System.DateTime StartDate
		{
			get
			{
				return this._StartDate;
			}
			set
			{
				if ((this._StartDate != value))
				{
					this.OnStartDateChanging(value);
					this.SendPropertyChanging();
					this._StartDate = value;
					this.SendPropertyChanged("StartDate");
					this.OnStartDateChanged();
				}
			}
		}
		
		[Column(Storage="_EndDate")]
		public System.DateTime EndDate
		{
			get
			{
				return this._EndDate;
			}
			set
			{
				if ((this._EndDate != value))
				{
					this.OnEndDateChanging(value);
					this.SendPropertyChanging();
					this._EndDate = value;
					this.SendPropertyChanged("EndDate");
					this.OnEndDateChanged();
				}
			}
		}
		
		[Column(Storage="_NumSeats")]
		public int NumSeats
		{
			get
			{
				return this._NumSeats;
			}
			set
			{
				if ((this._NumSeats != value))
				{
					this.OnNumSeatsChanging(value);
					this.SendPropertyChanging();
					this._NumSeats = value;
					this.SendPropertyChanged("NumSeats");
					this.OnNumSeatsChanged();
				}
			}
		}
		
		[Column(Storage="_RecurMon")]
		public bool RecurMon
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
		
		[Column(Storage="_RecurTue")]
		public bool RecurTue
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
		
		[Column(Storage="_RecurWed")]
		public bool RecurWed
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
		
		[Column(Storage="_RecurThu")]
		public bool RecurThu
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
		
		[Column(Storage="_RecurFri")]
		public bool RecurFri
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
		
		[Column(Storage="_RecurSat")]
		public bool RecurSat
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
		
		[Column(Storage="_RecurSun")]
		public bool RecurSun
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
		
		[Column(Storage="_LocationFromLat")]
		public double LocationFromLat
		{
			get
			{
				return this._LocationFromLat;
			}
			set
			{
				if ((this._LocationFromLat != value))
				{
					this.OnLocationFromLatChanging(value);
					this.SendPropertyChanging();
					this._LocationFromLat = value;
					this.SendPropertyChanged("LocationFromLat");
					this.OnLocationFromLatChanged();
				}
			}
		}
		
		[Column(Storage="_LocationFromLong")]
		public double LocationFromLong
		{
			get
			{
				return this._LocationFromLong;
			}
			set
			{
				if ((this._LocationFromLong != value))
				{
					this.OnLocationFromLongChanging(value);
					this.SendPropertyChanging();
					this._LocationFromLong = value;
					this.SendPropertyChanged("LocationFromLong");
					this.OnLocationFromLongChanged();
				}
			}
		}
		
		[Column(Storage="_LocationToLat")]
		public double LocationToLat
		{
			get
			{
				return this._LocationToLat;
			}
			set
			{
				if ((this._LocationToLat != value))
				{
					this.OnLocationToLatChanging(value);
					this.SendPropertyChanging();
					this._LocationToLat = value;
					this.SendPropertyChanged("LocationToLat");
					this.OnLocationToLatChanged();
				}
			}
		}
		
		[Column(Storage="_LocationToLong")]
		public double LocationToLong
		{
			get
			{
				return this._LocationToLong;
			}
			set
			{
				if ((this._LocationToLong != value))
				{
					this.OnLocationToLongChanging(value);
					this.SendPropertyChanging();
					this._LocationToLong = value;
					this.SendPropertyChanged("LocationToLong");
					this.OnLocationToLongChanged();
				}
			}
		}
		
		[Column(Storage="_Available")]
		public bool Available
		{
			get
			{
				return this._Available;
			}
			set
			{
				if ((this._Available != value))
				{
					this.OnAvailableChanging(value);
					this.SendPropertyChanging();
					this._Available = value;
					this.SendPropertyChanged("Available");
					this.OnAvailableChanged();
				}
			}
		}
		
		[Association(Name="User_Ride", Storage="_User", ThisKey="UserID", IsForeignKey=true)]
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
	
	[Table(Name="Users")]
	public partial class User : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _UserID = default(int);
		
		private string _FirstName;
		
		private string _LastName;
		
		private Gender _Gender;
		
		private System.Nullable<System.DateTime> _DOB;
		
		private string _Occupation;
		
		private string _Username;
		
		private string _Password;
		
		private string _Email;
		
		private string _ApplicationName = default(string);
		
		private string _PasswordQuestion;
		
		private string _PasswordAnswer;
		
		private bool _IsApproved;
		
		private System.Nullable<System.DateTime> _LastActvityDate;
		
		private System.Nullable<System.DateTime> _LastLogIn;
		
		private System.Nullable<System.DateTime> _LastPasswordChangedDate;
		
		private System.DateTime _CreationDate;
		
		private bool _IsLockedOut;
		
		private string _Comment;
		
		private System.Nullable<System.DateTime> _LastLockoutDate;
		
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
    partial void OnDateOfBirthChanging(System.Nullable<System.DateTime> value);
    partial void OnDateOfBirthChanged();
    partial void OnOccupationChanging(string value);
    partial void OnOccupationChanged();
    partial void OnUsernameChanging(string value);
    partial void OnUsernameChanged();
    partial void OnPasswordChanging(string value);
    partial void OnPasswordChanged();
    partial void OnEmailChanging(string value);
    partial void OnEmailChanged();
    partial void OnPasswordQuestionChanging(string value);
    partial void OnPasswordQuestionChanged();
    partial void OnPasswordAnswerChanging(string value);
    partial void OnPasswordAnswerChanged();
    partial void OnIsApprovedChanging(bool value);
    partial void OnIsApprovedChanged();
    partial void OnLastActvityDateChanging(System.Nullable<System.DateTime> value);
    partial void OnLastActvityDateChanged();
    partial void OnLastLoginDateChanging(System.Nullable<System.DateTime> value);
    partial void OnLastLoginDateChanged();
    partial void OnLastPasswordChangedDateChanging(System.Nullable<System.DateTime> value);
    partial void OnLastPasswordChangedDateChanged();
    partial void OnCreationDateChanging(System.DateTime value);
    partial void OnCreationDateChanged();
    partial void OnIsLockedOutChanging(bool value);
    partial void OnIsLockedOutChanged();
    partial void OnCommentChanging(string value);
    partial void OnCommentChanged();
    partial void OnLastLockoutDateChanging(System.Nullable<System.DateTime> value);
    partial void OnLastLockoutDateChanged();
    #endregion
		
		public User()
		{
			this._Rides = new EntitySet<Ride>(new Action<Ride>(this.attach_Rides), new Action<Ride>(this.detach_Rides));
			this._OpenIDs = new EntitySet<OpenID>(new Action<OpenID>(this.attach_OpenIDs), new Action<OpenID>(this.detach_OpenIDs));
			OnCreated();
		}
		
		[Column(Storage="_UserID", AutoSync=AutoSync.OnInsert, IsPrimaryKey=true, IsDbGenerated=true, UpdateCheck=UpdateCheck.Never)]
		public int UserID
		{
			get
			{
				return this._UserID;
			}
		}
		
		[Column(Storage="_FirstName")]
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
		
		[Column(Storage="_LastName")]
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
		
		[Column(Storage="_Gender", CanBeNull=true)]
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
		
		[Column(Storage="_DOB")]
		public System.Nullable<System.DateTime> DateOfBirth
		{
			get
			{
				return this._DOB;
			}
			set
			{
				if ((this._DOB != value))
				{
					this.OnDateOfBirthChanging(value);
					this.SendPropertyChanging();
					this._DOB = value;
					this.SendPropertyChanged("DateOfBirth");
					this.OnDateOfBirthChanged();
				}
			}
		}
		
		[Column(Storage="_Occupation")]
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
		
		[Column(Storage="_Username", CanBeNull=false)]
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
		
		[Column(Storage="_Password", CanBeNull=false)]
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
		
		[Column(Storage="_Email", CanBeNull=false)]
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
		
		[Column(Storage="_ApplicationName", UpdateCheck=UpdateCheck.Never)]
		public string ApplicationName
		{
			get
			{
				return this._ApplicationName;
			}
		}
		
		[Column(Storage="_PasswordQuestion")]
		public string PasswordQuestion
		{
			get
			{
				return this._PasswordQuestion;
			}
			set
			{
				if ((this._PasswordQuestion != value))
				{
					this.OnPasswordQuestionChanging(value);
					this.SendPropertyChanging();
					this._PasswordQuestion = value;
					this.SendPropertyChanged("PasswordQuestion");
					this.OnPasswordQuestionChanged();
				}
			}
		}
		
		[Column(Storage="_PasswordAnswer")]
		public string PasswordAnswer
		{
			get
			{
				return this._PasswordAnswer;
			}
			set
			{
				if ((this._PasswordAnswer != value))
				{
					this.OnPasswordAnswerChanging(value);
					this.SendPropertyChanging();
					this._PasswordAnswer = value;
					this.SendPropertyChanged("PasswordAnswer");
					this.OnPasswordAnswerChanged();
				}
			}
		}
		
		[Column(Storage="_IsApproved")]
		public bool IsApproved
		{
			get
			{
				return this._IsApproved;
			}
			set
			{
				if ((this._IsApproved != value))
				{
					this.OnIsApprovedChanging(value);
					this.SendPropertyChanging();
					this._IsApproved = value;
					this.SendPropertyChanged("IsApproved");
					this.OnIsApprovedChanged();
				}
			}
		}
		
		[Column(Storage="_LastActvityDate")]
		public System.Nullable<System.DateTime> LastActvityDate
		{
			get
			{
				return this._LastActvityDate;
			}
			set
			{
				if ((this._LastActvityDate != value))
				{
					this.OnLastActvityDateChanging(value);
					this.SendPropertyChanging();
					this._LastActvityDate = value;
					this.SendPropertyChanged("LastActvityDate");
					this.OnLastActvityDateChanged();
				}
			}
		}
		
		[Column(Storage="_LastLogIn")]
		public System.Nullable<System.DateTime> LastLoginDate
		{
			get
			{
				return this._LastLogIn;
			}
			set
			{
				if ((this._LastLogIn != value))
				{
					this.OnLastLoginDateChanging(value);
					this.SendPropertyChanging();
					this._LastLogIn = value;
					this.SendPropertyChanged("LastLoginDate");
					this.OnLastLoginDateChanged();
				}
			}
		}
		
		[Column(Storage="_LastPasswordChangedDate")]
		public System.Nullable<System.DateTime> LastPasswordChangedDate
		{
			get
			{
				return this._LastPasswordChangedDate;
			}
			set
			{
				if ((this._LastPasswordChangedDate != value))
				{
					this.OnLastPasswordChangedDateChanging(value);
					this.SendPropertyChanging();
					this._LastPasswordChangedDate = value;
					this.SendPropertyChanged("LastPasswordChangedDate");
					this.OnLastPasswordChangedDateChanged();
				}
			}
		}
		
		[Column(Storage="_CreationDate")]
		public System.DateTime CreationDate
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
		
		[Column(Storage="_IsLockedOut")]
		public bool IsLockedOut
		{
			get
			{
				return this._IsLockedOut;
			}
			set
			{
				if ((this._IsLockedOut != value))
				{
					this.OnIsLockedOutChanging(value);
					this.SendPropertyChanging();
					this._IsLockedOut = value;
					this.SendPropertyChanged("IsLockedOut");
					this.OnIsLockedOutChanged();
				}
			}
		}
		
		[Column(Storage="_Comment")]
		public string Comment
		{
			get
			{
				return this._Comment;
			}
			set
			{
				if ((this._Comment != value))
				{
					this.OnCommentChanging(value);
					this.SendPropertyChanging();
					this._Comment = value;
					this.SendPropertyChanged("Comment");
					this.OnCommentChanged();
				}
			}
		}
		
		[Column(Storage="_LastLockoutDate")]
		public System.Nullable<System.DateTime> LastLockoutDate
		{
			get
			{
				return this._LastLockoutDate;
			}
			set
			{
				if ((this._LastLockoutDate != value))
				{
					this.OnLastLockoutDateChanging(value);
					this.SendPropertyChanging();
					this._LastLockoutDate = value;
					this.SendPropertyChanged("LastLockoutDate");
					this.OnLastLockoutDateChanged();
				}
			}
		}
		
		[Association(Name="User_Ride", Storage="_Rides", OtherKey="UserID")]
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
		
		[Association(Name="User_OpenID", Storage="_OpenIDs", OtherKey="UserID")]
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
	
	[Table(Name="OpenIDs")]
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
		
		[Column(Storage="_OpenIDUrl", CanBeNull=false, IsPrimaryKey=true)]
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
		
		[Column(Storage="_UserID")]
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
		
		[Association(Name="User_OpenID", Storage="_User", ThisKey="UserID", IsForeignKey=true)]
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
#pragma warning restore 1591
