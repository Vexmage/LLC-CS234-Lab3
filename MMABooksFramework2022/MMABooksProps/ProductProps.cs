﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System;
using MMABooksTools;
using DBDataReader = MySql.Data.MySqlClient.MySqlDataReader;

namespace MMABooksProps
{
    [Serializable()]
    public class ProductProps : IBaseProps
    {
        #region Auto-implemented Properties
        public int ProductID { get; set; } = 0;

        public string ProductCode { get; set; } = "";

        public string Description { get; set; } = "";

        public decimal UnitPrice { get; set; } = 0m;

        public int OnHandQuantity { get; set; } = 0;

        /// <summary>
        /// ConcurrencyID. Don't manipulate directly.
        /// </summary>
        public int ConcurrencyID { get; set; } = 0;
        #endregion

        public object Clone()
        {
            ProductProps p = new ProductProps();
            p.ProductID = this.ProductID;
            p.ProductCode = this.ProductCode;
            p.Description = this.Description;
            p.UnitPrice = this.UnitPrice;
            p.OnHandQuantity = this.OnHandQuantity;
            p.ConcurrencyID = this.ConcurrencyID;
            return p;
        }

        public string GetState()
        {
            string jsonString;
            jsonString = JsonSerializer.Serialize(this);
            return jsonString;
        }

        public void SetState(string jsonString)
        {
            ProductProps p = JsonSerializer.Deserialize<ProductProps>(jsonString);
            this.ProductID = p.ProductID;
            this.ProductCode = p.ProductCode;
            this.Description = p.Description;
            this.UnitPrice = p.UnitPrice;
            this.OnHandQuantity = p.OnHandQuantity;
            this.ConcurrencyID = p.ConcurrencyID;
        }

        public void SetState(DBDataReader dr)
        {
            this.ProductID = (Int32)dr["ProductID"];
            this.ProductCode = ((string)dr["ProductCode"]).Trim();
            this.Description = (string)dr["Description"];
            this.UnitPrice = (decimal)dr["UnitPrice"];
            this.OnHandQuantity = (Int32)dr["OnHandQuantity"];
            this.ConcurrencyID = (Int32)dr["ConcurrencyID"];
        }
    }
}
