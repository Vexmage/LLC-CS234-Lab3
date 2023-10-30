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


            //Assert.IsTrue(isCreated);
        }

        [Test]
        public void UpdateProductTest()
        {

            Product existingProduct = new Product(1);


            existingProduct.Description = "Updated Product";


            void isUpdated = existingProduct.Save();


            //Assert.IsTrue(isUpdated);
        }

        [Test]
        public void DeleteProductTest()
        {

            Product existingProduct = new Product(1);


            void isDeleted = existingProduct.Delete(); 


            //Assert.IsTrue(isDeleted);
        }

        [Test]
        public void RetrieveProductTest()
        {

            int productId = 1;


            Product retrievedProduct = new Product(productId);


            Assert.AreEqual("PROD01", retrievedProduct.ProductCode);
            Assert.AreEqual("Sample Product", retrievedProduct.Description);
        }

        [Test]
        public void RetrieveAllProductsTest()
        {

            var products = product.GetList();


            //Assert.IsTrue(products.Count > 0);
        }

    }
}