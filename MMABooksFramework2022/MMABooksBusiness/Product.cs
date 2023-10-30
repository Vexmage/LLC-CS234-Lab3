using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MMABooksDB;
using MMABooksProps;
using MMABooksTools;

namespace MMABooksBusiness
{
    public class Product : BaseBusiness
    {
        //relevant properties
        //public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }

        protected override void SetRequiredRules()
        {
            if (string.IsNullOrEmpty(ProductName))
            {
                mRules.Add("ProductName cannot be null or empty.");
            }
        }

        protected override void SetDefaultProperties()
        {
            if (ProductPrice == default(decimal))
            {
                ProductPrice = 10.0m;
            }
        }
        protected override void SetUp()
        {
            mProps = new CustomerProps();
            mOldProps = new CustomerProps();

            mdbReadable = new CustomerDB();
            mdbWriteable = new CustomerDB();
        }

        public override object GetList()
        {
            List<Product> products = new List<Product>();
            List<ProductProps> props = (List<ProductProps>)mdbReadable.RetrieveAll();
            foreach (ProductProps prop in props)
            {
                Product productItem = new Product(prop);
                products.Add(productItem);
            }

            return products;
        }

        public int ProductID
        {
            get
            {
                return ((ProductProps)mProps).ProductID;
            }
            set
            {
                if (!(value == ((ProductProps)mProps).ProductID))
                    if (value >= 1)
                    {
                        mRules.RuleBroken("Abbreviation", false);
                        ((ProductProps)mProps).ProductID = value;
                        mIsDirty = true;
                    }

                    else
                    {
                        throw new ArgumentOutOfRangeException("Product Id must be more than 1 integer long.");
                    }
            } 

        }

        
        public Product()
        {
            mProps = new ProductProps();
        }

        public Product(object key) : base(key)
        {
            mProps = new ProductProps();
        }

        public string ProductCode
        {
            get
            {
                return ((ProductProps)mProps).ProductCode;
            }
            set
            {
                if (!(value == ((ProductProps)mProps).ProductCode))
                {
                    if (value.Trim().Length >= 1 && value.Trim().Length <= 30)
                    {
                        mRules.RuleBroken("ProductCode", false);
                        ((ProductProps)mProps).ProductCode = value;
                        mIsDirty = true;
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException("ProductCode must be no more than 30 characters long.");
                    }
                }
            }
        }

        public string Description
        {
            get
            {
                return ((ProductProps)mProps).Description;
            }
            set
            {
                if (!(value == ((ProductProps)mProps).Description))
                {
                    if (value.Trim().Length >= 1 && value.Trim().Length <= 50)
                    {
                        mRules.RuleBroken("Description", false);
                        ((ProductProps)mProps).Description = value;
                        mIsDirty = true;
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException("Description must be no more than 50 characters long.");
                    }
                }
            }
        }

        public decimal UnitPrice
        {
            get
            {
                return ((ProductProps)mProps).UnitPrice;
            }
            set
            {
                if (!(value == ((ProductProps)mProps).UnitPrice))
                {
                    if (value >= 0 && value <= 999999.99m)
                    {
                        mRules.RuleBroken("UnitPrice", false);
                        ((ProductProps)mProps).UnitPrice = value;
                        mIsDirty = true;
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException("UnitPrice must be between 0 and 999999.99.");
                    }
                }
            }
        }

        public int OnHandQuantity
        {
            get
            {
                return ((ProductProps)mProps).OnHandQuantity;
            }
            set
            {
                if (!(value == ((ProductProps)mProps).OnHandQuantity))
                {
                    if (value >= 0 && value <= 999999)
                    {
                        mRules.RuleBroken("OnHandQuantity", false);                          
                    }
                    else
                    {
                        throw new Exception("OnHandQuantity must be between 0 and 999999.");
                    }
                }
            }
        }
    }
}
