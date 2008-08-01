using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using GrabbaRide.Database;


namespace ApplicationTests
{
    [TestFixture]
    public class LinqDatabaseCreationTests
    {
        [Test] 
        public void CreationTest()
        {
            GrabbaRideDBDataContext context = new GrabbaRideDBDataContext();
            context.CreateDatabase();
            Assert.IsTrue(context.DatabaseExists());
          
        }

    }
}
