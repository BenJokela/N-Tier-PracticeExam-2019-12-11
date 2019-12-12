using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Types;

namespace Repo
{
    public class CustomerRepo
    {
        DataAccess da = new DataAccess();

        public List<Customer> RetrieveCustomers()
        {
            List<Customer> customers = new List<Customer>();
            string sql = "SELECT * FROM Customers";
            DataTable dt = new DataTable();
            dt = da.Execute(sql, CommandType.Text, null);
            foreach (DataRow row in dt.Rows)
            {
                Customer c = CreateCustomerFromRow(row);
                customers.Add(c);
            }
            return customers;
        }

        public Customer RetrieveSingleCustomer(string id)
        {
            Customer c = new Customer();
            string sql = $"SELECT * FROM Customers WHERE CustomerID = '{id}'";
            DataTable dt = new DataTable();

            dt = da.Execute(sql, CommandType.Text, null);
            c = CreateCustomerFromRow(dt.Rows[0]);
            return c;
        }

        public int UpdateCustomer(Customer c)
        {
            List<ParmStruct> parmsList = new List<ParmStruct>();
            parmsList.Add(new ParmStruct("@CustomerID", c.CustomerID, 5, SqlDbType.NChar, ParameterDirection.Input));
            parmsList.Add(new ParmStruct("@CompanyName", c.CompanyName, 40, SqlDbType.NVarChar, ParameterDirection.Input));
            parmsList.Add(new ParmStruct("@ContactName", c.ContactName, 30, SqlDbType.NVarChar, ParameterDirection.Input));
            parmsList.Add(new ParmStruct("@ContactTitle", c.ContactTitle, 30, SqlDbType.NVarChar, ParameterDirection.Input));
            parmsList.Add(new ParmStruct("@Address", c.Address, 60, SqlDbType.NVarChar, ParameterDirection.Input));
            parmsList.Add(new ParmStruct("@City", c.City, 15, SqlDbType.NVarChar, ParameterDirection.Input));
            parmsList.Add(new ParmStruct("@Region", c.Region, 15, SqlDbType.NVarChar, ParameterDirection.Input));
            parmsList.Add(new ParmStruct("@PostalCode", c.PostalCode, 10, SqlDbType.NVarChar, ParameterDirection.Input));
            parmsList.Add(new ParmStruct("@Country", c.Country, 15, SqlDbType.NVarChar, ParameterDirection.Input));
            parmsList.Add(new ParmStruct("@Phone", c.Phone, 24, SqlDbType.NVarChar, ParameterDirection.Input));
            parmsList.Add(new ParmStruct("@Fax", c.Fax, 24, SqlDbType.NVarChar, ParameterDirection.Input));

            return da.ExecuteNonQuery("usp_UpdateCustomer", CommandType.StoredProcedure, parmsList);

        }

        public int InsertCustomer(Customer c)
        {
            try
            {

                List<ParmStruct> parmsList = new List<ParmStruct>();
                parmsList.Add(new ParmStruct("@CustomerID", c.CustomerID, 5, SqlDbType.NChar, ParameterDirection.Input));
                parmsList.Add(new ParmStruct("@CompanyName", c.CompanyName, 40, SqlDbType.NVarChar, ParameterDirection.Input));
                parmsList.Add(new ParmStruct("@ContactName", c.ContactName, 30, SqlDbType.NVarChar, ParameterDirection.Input));
                parmsList.Add(new ParmStruct("@ContactTitle", c.ContactTitle, 30, SqlDbType.NVarChar, ParameterDirection.Input));
                parmsList.Add(new ParmStruct("@Address", c.Address, 60, SqlDbType.NVarChar, ParameterDirection.Input));
                parmsList.Add(new ParmStruct("@City", c.City, 15, SqlDbType.NVarChar, ParameterDirection.Input));
                parmsList.Add(new ParmStruct("@Region", c.Region, 15, SqlDbType.NVarChar, ParameterDirection.Input));
                parmsList.Add(new ParmStruct("@PostalCode", c.PostalCode, 10, SqlDbType.NVarChar, ParameterDirection.Input));
                parmsList.Add(new ParmStruct("@Country", c.Country, 15, SqlDbType.NVarChar, ParameterDirection.Input));
                parmsList.Add(new ParmStruct("@Phone", c.Phone, 24, SqlDbType.NVarChar, ParameterDirection.Input));
                parmsList.Add(new ParmStruct("@Fax", c.Fax, 24, SqlDbType.NVarChar, ParameterDirection.Input));

                return da.ExecuteNonQuery("usp_InsertCustomer", CommandType.StoredProcedure, parmsList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Customer CreateCustomerFromRow(DataRow row)
        {
            Customer c = new Customer();
            c.CustomerID = row["CustomerID"].ToString();
            c.CompanyName = row["CompanyName"].ToString();
            c.ContactName = row["ContactName"].ToString();
            c.ContactTitle = row["ContactTitle"].ToString();
            c.Address = row["Address"].ToString();
            c.City = row["City"].ToString();
            c.Region = row["Region"].ToString();
            c.PostalCode = row["PostalCode"].ToString();
            c.Country = row["Country"].ToString();
            c.Phone = row["Phone"].ToString();
            c.Fax = row["Fax"].ToString();
            return c;
        }
    }
}
