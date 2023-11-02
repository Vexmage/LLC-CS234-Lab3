using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Data;
using MMABooksBusiness;
using MMABooksDB;
using NUnit.Framework;

namespace MMABooksTests
{
    [TestFixture]
    public class ProductTests
    {
        Product product;

        [SetUp]
        public void Setup()
        {
            product = new Product();
        }

        [Test]
        public void CreateProductTest()
        {
            product.ProductCode = "PROD01";
            product.Description = "Sample Product";
            product.UnitPrice = 10.0m;
            product.OnHandQuantity = 50;

            bool isCreated = product.Save();


            Assert.IsTrue(isCreated);
        }

        [Test]
        public void UpdateProductTest()
        {
            Product existingProduct = new Product(1393);

            existingProduct.Description = "Updated Product";

            bool isUpdated = existingProduct.Save();

            Assert.IsTrue(isUpdated);
        }

        [Test]
        public void RetrieveProductTest()
        {
            try
            {
                Product retrievedProduct = new Product(1406);


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            

        }

        [Test]
        public void DeleteProductTest()
        {
            Product existingProduct = new Product(1393);

            bool isDeleted = existingProduct.Delete();

            Assert.IsTrue(isDeleted);
        }




        /*
        [TearDown]
        public void Cleanup()
        {
            // Code to cleanup any changes made during tests (e.g., delete test records)
        }
        */
    }
}
