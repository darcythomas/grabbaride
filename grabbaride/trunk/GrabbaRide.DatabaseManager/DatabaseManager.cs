using System;
using GrabbaRide.Database;

namespace GrabbaRide.DatabaseManager
{
    class DatabaseManager
    {
        /// <summary>
        /// Deletes and recreates the database.
        /// This is a seperate executable so that it can be run as an administrator when
        /// deploying on a server.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.Write("Getting database context...");
            GrabbaRideDBDataContext dc = new GrabbaRideDBDataContext();
            Console.WriteLine(" success!");

            if (dc.DatabaseExists())
            {
                Console.Write("Database exists, deleting...");
                dc.DeleteDatabase();
                Console.WriteLine(" success!");
            }

            Console.Write("Creating database...");
            dc.CreateDatabase();
            
            if (dc.DatabaseExists())
            {
                Console.WriteLine(" success!");
            }
            else
            {
                Console.WriteLine(" failed!");
            }

            Console.Write("Inputting sample data...");
            TestDataGeneration.InputSampleData();
            Console.WriteLine(" success!");

            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
