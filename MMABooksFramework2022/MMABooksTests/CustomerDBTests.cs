using NUnit.Framework;
using MMABooksProps;
using MMABooksDB;
using DBCommand = MySql.Data.MySqlClient.MySqlCommand;
using System.Data;
using System.Collections.Generic;
using System;
using MySql.Data.MySqlClient;

namespace MMABooksTests
{
    public class CustomerDBTests
    {
        CustomerDB db;

        [SetUp]
        public void ResetData()
        {
            db = new CustomerDB();
            DBCommand command = new DBCommand();
            command.CommandText = "usp_testingResetCustomer1Data";
            command.CommandType = CommandType.StoredProcedure;
            db.RunNonQueryProcedure(command);
        }

        [Test]
        public void TestRetrieve()
        {
            CustomerProps p = (CustomerProps)db.Retrieve(1); 
            Assert.AreEqual(1, p.CustomerID);
            Assert.AreEqual("Sample Name", p.Name); 
        }

        [Test]
        public void TestRetrieveAll()
        {
            List<CustomerProps> list = (List<CustomerProps>)db.RetrieveAll();
            Assert.AreEqual(10, list.Count);
        }

        [Test]
        public void TestDelete()
        {
            CustomerProps p = (CustomerProps)db.Retrieve(2); 
            Assert.True(db.Delete(p));
            Assert.Throws<Exception>(() => db.Retrieve(2));
        }

        [Test]
        public void TestUpdate()
        {
            CustomerProps p = (CustomerProps)db.Retrieve(3); 
            p.Name = "Updated Name";
            Assert.True(db.Update(p));
            p = (CustomerProps)db.Retrieve(3);
            Assert.AreEqual("Updated Name", p.Name);
        }



        [Test]
        public void TestCreate()
        {
            CustomerProps p = new CustomerProps();
            p.Name = "Zac Red";
            p.Address = "123 New St.";
            p.City = "New City";
            p.State = "NC";
            p.ZipCode = "12345";
            db.Create(p);
            CustomerProps p2 = (CustomerProps)db.Retrieve(p.CustomerID);
            Assert.AreEqual(p.GetState(), p2.GetState());
        }

        [Test]
        public void TestCreatePrimaryKeyViolation()
        {
            CustomerProps p = new CustomerProps();
            p.CustomerID = 1; // Assuming 1 is an existing CustomerID
            p.Name = "Duplicate Customer";
            Assert.Throws<MySqlException>(() => db.Create(p));
        }
    }
}
