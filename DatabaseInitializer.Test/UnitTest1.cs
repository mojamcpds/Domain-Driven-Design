using System;
using System.Data.Entity;
using System.Linq;
using DMS.DataInitializer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DatabaseInitializer.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        //Create Database from here because all the fully qualified domain model has been defined
        //inside DMS.DataInitializer and all fully qualified dbset hsa been defined DmsContext
        public void CanCreateDatabase()
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<DmsContext>());
            using (var databaseContext = new DmsContext())
            {
                Assert.AreEqual(0, databaseContext.Books.Count());       
            }
        }
    }
}
