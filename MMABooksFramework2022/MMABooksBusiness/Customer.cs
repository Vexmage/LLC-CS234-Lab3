using System;
using System.Collections.Generic;
using MMABooksDB;
using MMABooksProps;
using MMABooksTools;

namespace MMABooksBusiness
{
    public class Customer : BaseBusiness
    {
        public int CustomerID
        {
            get
            {
                return ((CustomerProps)mProps).CustomerID;
            }
        }

        public String Name
        {
            get
            {
                return ((CustomerProps)mProps).Name;
            }

            set
            {
                if (!(value.Trim().Length == ((CustomerProps)mProps).Name.Length))
                {
                    if (value.Trim().Length <= 100)
                    {
                        mRules.RuleBroken("Name", false);
                        ((CustomerProps)mProps).Name = value;
                        mIsDirty = true;
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException("Name must be under 101 characters long.");
                    }
                }
            }
        }

        public String Address
        {
            get
            {
                return ((CustomerProps)mProps).Address;
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value) && value.Trim().Length <= 100) // Assuming 100 is the max length
                {
                    mRules.RuleBroken("Address", false);
                    ((CustomerProps)mProps).Address = value.Trim();
                    mIsDirty = true;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Address must be under 101 characters long and not empty.");
                }
            }
        }

        public String City
        {
            get
            {
                return ((CustomerProps)mProps).City;
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value) && value.Trim().Length <= 50) // Assuming 50 is the max length for city
                {
                    mRules.RuleBroken("City", false);
                    ((CustomerProps)mProps).City = value.Trim();
                    mIsDirty = true;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("City must be under 51 characters long and not empty.");
                }
            }
        }

        public String State
        {
            get
            {
                return ((CustomerProps)mProps).State;
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value) && value.Trim().Length <= 2) // Assuming 2 is the max length for state abbreviation
                {
                    mRules.RuleBroken("State", false);
                    ((CustomerProps)mProps).State = value.Trim();
                    mIsDirty = true;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("State must be 1 or 2 characters long and not empty.");
                }
            }
        }

        public String ZipCode
        {
            get
            {
                return ((CustomerProps)mProps).ZipCode;
            }
            set
            {
                // Assuming 5-9 characters for ZipCode (standard and Zip+4)
                if (!string.IsNullOrWhiteSpace(value) && (value.Trim().Length == 5 || value.Trim().Length == 9))
                {
                    mRules.RuleBroken("ZipCode", false);
                    ((CustomerProps)mProps).ZipCode = value.Trim();
                    mIsDirty = true;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("ZipCode must be 5 or 9 characters long and not empty.");
                }
            }
        }


        public override object GetList()
        {
            List<Customer> customers = new List<Customer>();
            List<CustomerProps> props = (List<CustomerProps>)mdbReadable.RetrieveAll();
            foreach (CustomerProps prop in props)
            {
                Customer customerItem = new Customer(prop);
                customers.Add(customerItem);
            }

            return customers;
        }

        protected override void SetDefaultProperties()
        {
            ((CustomerProps)mProps).Address = "1066 Sky Street";
            ((CustomerProps)mProps).City = "Ubiq";
            ((CustomerProps)mProps).State = "Texas";
            ((CustomerProps)mProps).ZipCode = "12345";
            ((CustomerProps)mProps).Name = "Gill Longerm";
        }


        protected override void SetRequiredRules()
        {
            mRules.RuleBroken("CustomerID", true);
            mRules.RuleBroken("Name", true);
            mRules.RuleBroken("Address", true);
            mRules.RuleBroken("City", true);
            mRules.RuleBroken("State", true);
            mRules.RuleBroken("ZipCode", true);
        }

        protected override void SetUp()
        {
            mProps = new CustomerProps();
            mOldProps = new CustomerProps();

            mdbReadable = new CustomerDB();
            mdbWriteable = new CustomerDB();
        }

        #region constructors

        public Customer() : base()
        {
        }

        public Customer(string key)
            : base(key)
        {
        }

        private Customer(CustomerProps props)
            : base(props)
        {
        }

        #endregion
    }
}
