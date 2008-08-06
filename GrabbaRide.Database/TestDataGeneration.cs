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
    public static class TestDataGeneration
    {
        //********* User Data  private variables***************//

        public static string[] testUserNames = { "badguy69", "sillylady", "pissman", "duffman", "benjiMan", "Dogbrain",
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
        
        public static string[] testFirstNames = {"Nacy", "Nikki","Nick","Nack","Norina","Mirina","Max","Snape","Sam","Samantha",
                                        "Sarah"," Suli","Ruli","Rowina","Tom","Amy","Nick","Karen","Ella","Leith","Bettina",
                                        "Wolfgang", "Hank","Craig","Jo","Jessy","Jessica","Harry","Jack","Maximilian","Kathyrn","Leasley","David","Bob",
                                        "Granis","Elsie","Ann","Dover","Samual","Ben","Adrian","Michelle","Darcy","Jevon@jevon.org"};

        public static string[] testLastNames = { "Murry", "Smith", "Camp", "Mcshit" };

        public static void addTestUsers(int num)
        {
            GrabbaRideDBDataContext context = new GrabbaRideDBDataContext();
            context.Users.InsertAllOnSubmit(generateTestUsers(num));
            context.SubmitChanges();


        }
      

        public static List<User> generateTestUsers(int numUsers)
        {
            List<User> userList = new List<User>();
            for (int i = 0; i < numUsers; i++)
            {
                userList.Add(generateNewUser());
            }
            return userList;

                    
        }

        private static User generateNewUser()
        {
            string userName=randomUserName();
            // for test users, the password will be the same as the user name
            return new User(randomFirstname(),randomLastname(),randomGender(),randomDate(),userName,userName,"a.palamountain@gmail.com");
        }

        private static int getRandomNumber(int max)
        {
            System.Random r= new System.Random();
            return r.Next(0,max);
        }

        private static string randomUserName(){
            return TestDataGeneration.testUserNames[TestDataGeneration.getRandomNumber(TestDataGeneration.testUserNames.Length)];
             
        }

        private static string randomFirstname(){
         return TestDataGeneration.testFirstNames[TestDataGeneration.getRandomNumber(TestDataGeneration.testFirstNames.Length)];
        }

        private static string randomLastname(){
         return TestDataGeneration.testLastNames[TestDataGeneration.getRandomNumber(TestDataGeneration.testLastNames.Length)];
        }

        private static Gender randomGender()
        {
            if (getRandomNumber(1) == 1)
                return Gender.Male;
            else return Gender.Female;
        }

        private static System.DateTime randomDate()
        {
            return new System.DateTime();
        }



        //******Location Data *******

        private static Location[] testLocations = {(new Location("Vegas", -115.136719,36.1966330)),
                                                  (new Location("Monte Carlo", 43.7398, 7.4272)),
                                                  new Location("Atlantis", -180, 180),
                                                  new Location("South Pole", 175.617230, -180),
                                                  new Location("Mt Doom, Mordor", 75.526240, -39.304700),
                                                  new Location("New Washington", 44.395752, 33.299313),
                                                  new Location("Massey", 175.617779, -40.3857650)};

        /// <summary>
        /// Adds Sample locations to database for testing
        /// </summary>
      
      



        //**** Ride Dummy Data****





    }
}