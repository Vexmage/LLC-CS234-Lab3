using System;
using MMABooksTools;
using DBDataReader = MySql.Data.MySqlClient.MySqlDataReader;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace MMABooksProps
{
    [Serializable()]
    public class CustomerProps : IBaseProps
    {
        #region Auto-implemented Properties
        public int ID { get; set; } = 0;
        public int CustomerID { get; set; } = 0;  

        public string Name { get; set; } = ""; 

        public string Address { get; set; } = "";  

        public string Email { get; set; } = "";  
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        /// <summary>
        /// ConcurrencyID. Don't manipulate directly.
        /// </summary>
        public int ConcurrencyID { get; set; } = 0;
        #endregion

        public object Clone()
        {
            CustomerProps p = new CustomerProps();
            p.ID = this.ID;
            p.Name = this.Name;
            p.Address = this.Address;
            p.Email = this.Email;
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
            CustomerProps p = JsonSerializer.Deserialize<CustomerProps>(jsonString);
            this.ID = p.ID;
            this.Name = p.Name;
            this.Address = p.Address;
            this.Email = p.Email;
            this.ConcurrencyID = p.ConcurrencyID;
        }

        public void SetState(DBDataReader dr)
        {
            this.ID = (Int32)dr["CustomerID"];
            this.Name = (string)dr["CustomerName"];
            this.Address = (string)dr["Address"];
            this.Email = (string)dr["Email"];
            this.ConcurrencyID = (Int32)dr["ConcurrencyID"];
        }
    }
}
