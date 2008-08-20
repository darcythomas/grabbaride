using System.Collections.Generic;
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
    public class TestDataGeneration
    {
        GrabbaRideDBDataContext _dataContext;
        Random _random;

        private TestDataGeneration()
        {
            _dataContext = new GrabbaRideDBDataContext();
            _random = new Random();
        }

        private string[] _testUserNames = { "badguy69", "sillylady", "pissman", "duffman", "benjiMan", "Dogbrain",
                                       "BeerBarron", "Flanders", "AlGore", "BushRIP", "FACERIP", "DEATHDIVE",
                                       "Shitwolf", "Nick", "Thomas", "Adrian", "Michelle", "Darcy", "Tokenblackguy",
                                       "Droid1", "Droid2", "Droid3", "Droid4", "3cp0", "YODA", "Chewie", "JabbaTheHut",
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

        private void AddUsers(int num)
        {
            for (int i = 0; i < num; i++)
            {
                User u = RandomUser();
                _dataContext.Users.InsertOnSubmit(u);
            }
            _dataContext.SubmitChanges();
        }

        private User RandomUser()
        {
            return new User(RandomFirstname(),
                RandomLastname(),
                RandomGender(),
                RandomDate(),
                RandomUsername(),
                "password",
                RandomEmail());
        }

        private string RandomEmail()
        {
            return "a.palamountain@gmail.com";
        }

        private string RandomUsername()
        {
            return _testUserNames[_random.Next(_testUserNames.Length)];
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
            List<User> usersList = _dataContext.Users.ToList();
            int i = new Random().Next(usersList.Count);
            return usersList[i];
        }

        private Gender RandomGender()
        {
            if (_random.Next(2) == 1) { return Gender.Male; }
            else { return Gender.Female; }
        }

        private DateTime RandomDate()
        {
            return new DateTime(2008 ,
                _random.Next(4) + 8,
                _random.Next(28) + 1);
        }

        //**** Ride Dummy Data****

        private Ride RandomRide()
        {
            Ride r = new Ride();
            r.User = RandomExistingUser();
            return r;
        }

        private void AddRides(int num)
        {
            for (int i = 0; i < num; i++)
            {
                _dataContext.Rides.InsertOnSubmit(RandomRide());
            }
            _dataContext.SubmitChanges();
        }

        /// <summary>
        /// Fills up the database with some sample data for testing.
        /// </summary>
        public static void InputSampleData()
        {
            TestDataGeneration dg = new TestDataGeneration();
            dg.AddUsers(30);
            dg.AddRides(100);
        }
    }
}