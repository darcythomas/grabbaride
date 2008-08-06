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
   
    public partial class User 
    {  

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


        
    }
}
