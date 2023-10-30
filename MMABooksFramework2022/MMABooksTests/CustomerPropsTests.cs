using MMABooksProps;
using NUnit.Framework;
using System;

namespace MMABooksTests
{
    [TestFixture]
    public class CustomerPropsTests
    {
        CustomerProps props;

        [SetUp]
        public void Setup()
        {
            props = new CustomerProps();
            props.ID = 11;
            props.Name = "John Smith";
            props.Address = "123 Clearwater St.";
            props.Email = "johnsmith@email.com";
        }

        [Test]
        public void TestGetState()
        {
            string jsonString = props.GetState();
            Assert.IsTrue(jsonString.Contains(props.ID.ToString()));
            Assert.IsTrue(jsonString.Contains(props.Name));
            Assert.IsTrue(jsonString.Contains(props.Address));
            Assert.IsTrue(jsonString.Contains(props.Email));
        }

        [Test]
        public void TestSetState()
        {
            string jsonString = props.GetState();
            CustomerProps newProps = new CustomerProps();
            newProps.SetState(jsonString);
            Assert.AreEqual(props.ID, newProps.ID);  
            Assert.AreEqual(props.Name, newProps.Name);
            Assert.AreEqual(props.Address, newProps.Address);
            Assert.AreEqual(props.Email, newProps.Email);
            Assert.AreEqual(props.ConcurrencyID, newProps.ConcurrencyID);
        }

        [Test]
        public void TestClone()
        {
            CustomerProps newProps = (CustomerProps)props.Clone();
            Assert.AreEqual(props.ID, newProps.ID); 
            Assert.AreEqual(props.Name, newProps.Name);
            Assert.AreEqual(props.Address, newProps.Address);
            Assert.AreEqual(props.Email, newProps.Email);
            Assert.AreEqual(props.ConcurrencyID, newProps.ConcurrencyID);
        }
    }
}
