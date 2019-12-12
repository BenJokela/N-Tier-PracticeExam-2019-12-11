using Models;
using Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CustomerBL
    {
        CustomerRepo repo = new CustomerRepo();

        public List<Customer> GetCustomers()
        {
            List<Customer> customers = repo.RetrieveCustomers();
            return customers;
        }

        public Customer GetCustomer(string id)
        {
            return repo.RetrieveSingleCustomer(id);
        }

        public int EditCustomer(Customer c)
        {
            int retVal=0;
            try
            {
                retVal = repo.UpdateCustomer(c);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return retVal;
        }

        public int CreateCustomer(Customer c)
        {
            int retVal = 0;
            try
            {
                retVal = repo.InsertCustomer(c);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return retVal;
        }
    }
}
