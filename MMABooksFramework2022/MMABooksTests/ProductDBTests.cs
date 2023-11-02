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
    [TestFixture]
    public class ProductDBTests
    {
        ProductDB db;

        [SetUp]
        public void ResetData()
        {
            db = new ProductDB();
            DBCommand command = new DBCommand();
            command.CommandText = "usp_testingResetData";
            command.CommandType = CommandType.StoredProcedure;
            db.RunNonQueryProcedure(command);
        }

        [Test]
        public void TestRetrieve()
        {
            ProductProps p = (ProductProps)db.Retrieve(1749);
            Assert.AreEqual("CRFC", p.ProductCode);
            //Assert.AreEqual("Sample Product", p.Description);
            Assert.AreEqual(10.0m, p.UnitPrice);
        }

        [Test]
        public void TestRetrieveAll()
        {
            List<ProductProps> products = (List<ProductProps>)db.RetrieveAll();
            Assert.GreaterOrEqual(products.Count, 1); // Assuming you have at least one product in DB after reset
            Assert.AreEqual("PROD01", products[0].ProductCode); // And assuming PROD01 is the first product
                                                                // ... Add further checks for other products if needed
        }

        [Test]
        public void TestUpdate()
        {
            ProductProps p = (ProductProps)db.Retrieve(1393);
            p.Description = "Updated Product";
            Assert.True(db.Update(p));
            ProductProps p2 = (ProductProps)db.Retrieve(1393);
            Assert.AreEqual("Updated Product", p2.Description);
        }

        [Test]
        public void TestDelete()
        {
            ProductProps p = (ProductProps)db.Retrieve(1393);
            Assert.True(db.Delete(p));
            Assert.Throws<Exception>(() => db.Retrieve(1393));
        }

        [Test]
        public void TestCreate()
        {
            ProductProps p = new ProductProps();
            p.ProductCode = "PROD02";
            p.Description = "Another Product";
            p.UnitPrice = 20.0m;
            p.OnHandQuantity = 10;

            db.Create(p);
            ProductProps p2 = (ProductProps)db.Retrieve(p.ProductID);
            Assert.AreEqual(p.ProductCode, p2.ProductCode);
            Assert.AreEqual(p.Description, p2.Description);
            Assert.AreEqual(p.UnitPrice, p2.UnitPrice);
        }

        [Test]
        public void TestConcurrencyOnUpdate()
        {
            ProductProps p1 = (ProductProps)db.Retrieve(1393);
            ProductProps p2 = (ProductProps)db.Retrieve(1393);

            p1.Description = "Concurrency Test 1";
            db.Update(p1);
            p2.Description = "Concurrency Test 2";

            Assert.Throws<Exception>(() => db.Update(p2));
        }

        [Test]
        public void TestConcurrencyOnDelete()
        {
            ProductProps p1 = (ProductProps)db.Retrieve(1393);
            ProductProps p2 = (ProductProps)db.Retrieve(1393);

            db.Delete(p1);

            Assert.Throws<Exception>(() => db.Delete(p2));
        }
    }
}
