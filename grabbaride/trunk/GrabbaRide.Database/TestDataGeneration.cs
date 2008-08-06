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


      

        public static List<User> generateTestUsers(int numUsers)
        {
            List<User> userList = new List<User>();
            for (int i = 0; i < numUsers; i++)
            {
                userList.Add();
            }

                    
        }

        private static User generateNewUser()
        {
            string userName=randomUserName();
            // for test users, the password will be the same as the user name
            return new User(randomFirstname(),randomLastname(),randomGender(),randomDate(),randomUserName(),userName,userName,"a.palamountain@gmail.com");
        }

        private static int getRandomNumber(int max)
        {
            System.Random r= new System.Random(0,max);
            return r.Next();
        }

        private static string randomUserName(){
           return TestDataGeneration.randomUserName
               [TestDataGeneration.getRandomNumber(TestDataGeneration.testUserNames.Length)];
        }

        private static string randomFirstname(){
         return TestDataGeneration.randomFirstName
               [TestDataGeneration.getRandomNumber(TestDataGeneration.testFirstNames.Length)];
        }

        private static string randomLastname(){
         return TestDataGeneration.randomLastName
               [TestDataGeneration.getRandomNumber(TestDataGeneration.testLastNames.Length)];
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
        /// <summary>
        /// Adds Sample locations to database for testing
        /// </summary>
        private void GenerateSampleLocations()
        {
               List<Location> locations = new List<Location>(); 
               locations.Add(new Location("Vegas", -115.136719, 36.196633));
               locations.Add(new Location("Monte Carlo", 43.7398, 7.4272));
               locations.Add(new Location("Atlantis", -180, 180));
               locations.Add(new Location("South Pole", 175.617230, -180));
               locations.Add(new Location("Mt Doom, Mordor", 75.526240, -39.304700));
               locations.Add(new Location("New Washington", 44.395752, 33.299313));
               locations.Add(new Location("Massey", 175.617779, -40.385765));
           
        }


    }
}