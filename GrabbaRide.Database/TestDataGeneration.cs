﻿using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Data;
using System.Reflection;
using System.Linq.Expressions;
using System.ComponentModel;
using System.Diagnostics;
using System;

namespace GrabbaRide.Database
{
    partial class GrabbaRideDBDataContext
    {
        private Random _random;

        private string[] _testUsernames = { "badguy69", "sillylady", "pissman", "duffman", "benjiMan", "Dogbrain",
                                       "BeerBarron", "Flanders", "AlGore", "BushRIP", "FACERIP", "DEATHDIVE",
                                       "Droid1", "Droid2", "Droid3", "Droid4", "C3P0", "YODA", "Chewie", "JabbaTheHut",
                                       "mrPotatoHead", "mrsPotatoHead", "BuzzLightYear", "SlinkyDinky",
                                       "Droid2008", "HellenClarke", "Bigbummum", "wintsonPeters", "Denmin_deamon",
                                       "Droid-1110082", "greesedUpDeaf_Guy", "PhillipJ_fry", "Turanga_Leela",
                                       "Bender_B_Rodriguez", "Prof_Hubert_Farnsworth", "Dr._John+Zoidberg", "pillic", "EddieSpagetti",
                                       "Droid52", "aspicegirl69", "HHH", "degenerationx","roadkill","wolfcreek",
                                       "rideyou","takeyouplaces","marslander","sailormoon","HappyTom","hankVon","Bigbird","fingers","BigWix",
                                       "rudeboy","mostlydead","zombie","stitchedUpBabyDoll","tightsandHeals","Suspenders"};

        private string[] _testFirstNames = {"Nacy", "Nikki","Nick","Nack","Norina","Mirina","Max","Snape","Sam","Samantha",
                                        "Sarah"," Suli","Ruli","Rowina","Tom","Amy","Nick","Karen","Ella","Leith","Bettina",
                                        "Wolfgang", "Hank","Craig","Jo","Jessy","Jessica","Harry","Jack","Maximilian","Kathyrn","Leasley","David","Bob",
                                        "Granis","Elsie","Ann","Dover","Samual","Ben","Adrian","Michelle","Darcy","Jevon@jevon.org"};

        private string[] _testLastNames = { "Murry", "Smith", "Camp", "Mcshit" };

        private void AddUsers()
        {
            foreach (string username in _testUsernames)
            {
                User u = new User(username);
                u.FirstName = RandomFirstname();
                u.LastName = RandomLastname();
                u.Gender = RandomGender();
                u.DateOfBirth = RandomDate(1955, 1990);
                u.CreationDate = RandomDate(2006, 2007);
                u.Password = "password";// cant test if i dont have a password
                u.Email = String.Format("{0}.gr@darcythomas.com", u.Username);
                u.ApplicationName = "GrabbaRide";

                this.Users.InsertOnSubmit(u);
            }
            this.SubmitChanges();
        }

        private string RandomFirstname()
        {
            return _testFirstNames[_random.Next(_testFirstNames.Length)];
        }

        private string RandomLastname()
        {
            return _testLastNames[_random.Next(_testLastNames.Length)];
        }

        private User RandomExistingUser()
        {
            List<User> usersList = this.Users.ToList();
            int i = new Random().Next(usersList.Count);
            return usersList[i];
        }

        private Gender RandomGender()
        {
            if (_random.Next(2) == 1) { return Gender.Male; }
            else { return Gender.Female; }
        }

        private double RandomLatLong()
        {
            return (_random.NextDouble() % 0.1) - 0.05;
        }

        private DateTime RandomDate(int fromYear, int toYear)
        {
            if (fromYear > toYear)
            {
                throw new ArgumentException("fromYear can't be after toYear!");
            }
            else
            {
                int diff = toYear - fromYear;
                DateTime result = new DateTime(
                    fromYear + _random.Next(diff),
                    _random.Next(12) + 1,
                    _random.Next(28) + 1,
                    _random.Next(24),
                    _random.Next(60),
                    _random.Next(60));

                return result;
            }
        }

        private TimeSpan RandomTimeSpan(int hours)
        {
            TimeSpan ts = new TimeSpan(_random.Next(hours), _random.Next(60), 0);
            return ts;
        }

        private Ride RandomRide()
        {
            var r1 = (RandomLatLong() - 40.355746);
            var r2 = (RandomLatLong() + 175.61219);
            var r3 = (RandomLatLong() - 40.355746);
            var r4 = (RandomLatLong() + 175.61219);

            Ride r = new Ride(r1, r2, r3, r4);
            r.User = RandomExistingUser();
            r.CreationDate = RandomDate(2008, 2008);
            r.StartDate = RandomDate(2007, 2008);
            r.EndDate = RandomDate(2009, 2010);
            r.DepartureTime = RandomTimeSpan(24);
            r.JourneyLength = RandomTimeSpan(3);
            r.NumSeats = _random.Next(6);

            r.RecurMon = _random.Next(2) == 1;
            r.RecurTue = _random.Next(2) == 1;
            r.RecurWed = _random.Next(2) == 1;
            r.RecurThu = _random.Next(2) == 1;
            r.RecurFri = _random.Next(2) == 1;
            r.RecurSat = _random.Next(4) == 1;
            r.RecurSun = _random.Next(4) == 1;

            return r;
        }

        private void AddRides(int num)
        {
            for (int i = 0; i < num; i++)
            {
                Ride r = RandomRide();
                this.Rides.InsertOnSubmit(r);
            }
            this.SubmitChanges();
        }

        /// <summary>
        /// All rides are from the sqaure to massey but no ones going home :(
        /// </summary>
        /// <param name="num"></param>
        private void AddFixedRides(int num)
        {
            for (int i = 0; i < num; i++)
            {
                Ride r = RandomRide();
                r.LocationFromLat = -40.355963256404124;
                r.LocationFromLong = 175.61147689819336;
                r.LocationToLat = -40.38434352539335;
                r.LocationToLong = 175.61705589294434;
                this.Rides.InsertOnSubmit(r);
            }
            this.SubmitChanges();
        }

        /// <summary>
        /// Fills up the database with some sample data for testing.
        /// </summary>
        public void InsertSampleData()
        {
            _random = new Random();

            AddUsers();
            AddRides(10000);
            AddFixedRides(50);
        }
    }
}