using NUnit.Framework;
using MMABooksBusiness;
using System;

namespace MMABooksTests
{
    [TestFixture]
    public class CustomerTests
    {
        [Test]
        public void Test_CustomerNameSetGet()
        {
            Customer customer = new Customer();
            customer.Name = "John Doe";
            Assert.AreEqual("John Doe", customer.Name);
        }

        [Test]
        public void Test_CustomerNameExceedsMaxLength()
        {
            Customer customer = new Customer();
            string longName = new string('a', 101);
            Assert.Throws<ArgumentOutOfRangeException>(() => customer.Name = longName);
        }

        [Test]
        public void Test_CustomerAddressSetGet()
        {
            Customer customer = new Customer();
            customer.Address = "1234 Elm Street";
            Assert.AreEqual("1234 Elm Street", customer.Address);
        }

        [Test]
        public void Test_CustomerAddressExceedsMaxLength()
        {
            Customer customer = new Customer();
            string longAddress = new string('a', 101);
            Assert.Throws<ArgumentOutOfRangeException>(() => customer.Address = longAddress);
        }

        [Test]
        public void Test_CustomerCitySetGet()
        {
            Customer customer = new Customer();
            customer.City = "Springfield";
            Assert.AreEqual("Springfield", customer.City);
        }

        [Test]
        public void Test_CustomerCityExceedsMaxLength()
        {
            Customer customer = new Customer();
            string longCity = new string('a', 51);
            Assert.Throws<ArgumentOutOfRangeException>(() => customer.City = longCity);
        }

        [Test]
        public void Test_CustomerStateSetGet()
        {
            Customer customer = new Customer();
            customer.State = "TX";
            Assert.AreEqual("TX", customer.State);
        }

        [Test]
        public void Test_CustomerStateExceedsMaxLength()
        {
            Customer customer = new Customer();
            string longState = new string('a', 3);
            Assert.Throws<ArgumentOutOfRangeException>(() => customer.State = longState);
        }

        [Test]
        public void Test_CustomerZipCodeSetGet()
        {
            Customer customer = new Customer();
            customer.ZipCode = "12345";
            Assert.AreEqual("12345", customer.ZipCode);
        }

        [Test]
        public void Test_CustomerZipCodeInvalidLength()
        {
            Customer customer = new Customer();
            Assert.Throws<ArgumentOutOfRangeException>(() => customer.ZipCode = "123456");
        }

    }
}
