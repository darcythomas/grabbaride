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
                try
                {
                    dc.DeleteDatabase();
                    Console.WriteLine(" success!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine();
                    Console.WriteLine(ex.Message);
                    End();
                    return;
                }
            }

            Console.Write("Creating database...");
            try
            {
                dc.CreateDatabase();
                Console.WriteLine(" success!");
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine(ex.Message);
                End();
                return;
            }

            Console.Write("Inputting sample data...");
            try
            {
                dc.InsertSampleData();
                Console.WriteLine(" success!");
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine(ex.Message);
                End();
                return;
            }

            // success!
            End();
        }

        static void End()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
