using NRDCLRazor.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NRDCLRazor.Services
{
    public class MockCustomerRepository : ICustomerRepository
    {
        private List<Customer> customerlist;

        public MockCustomerRepository()
        {
            customerlist = new List<Customer>()
            {
                new Customer(){ Id = "1", Name = "manta", Email = "manta@gmail.com", Mobile = "1234"},
                new Customer(){ Id = "2", Name = "tashi", Email = "tashi@gmail.com", Mobile = "1111"},
                new Customer(){ Id = "3", Name = "yangchen", Email = "yangcchen@gmail.com", Mobile = "5678"},
                new Customer(){ Id = "4", Name = "dorji", Email = "dorji@gmail.com", Mobile = "8888"},
                new Customer(){ Id = "5", Name = "pema", Email = "pema@gmail.com", Mobile = "9999"}

            };
        }

        public Customer AddCustomer(Customer newcustomer)
        {
            newcustomer.Id =Convert.ToString(customerlist.Max(customerlist => customerlist.Id) + 1);
            customerlist.Add(newcustomer);
            return newcustomer;
        }

        public Customer DeleteCustomer(string id)
        {
            Customer customerToDelete = customerlist.FirstOrDefault(customer => customer.Id == id);
            if (customerToDelete != null)
            {
                customerlist.Remove(customerToDelete);
            }
            return customerToDelete;
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return customerlist;
        }

        public Customer GetCustomer(string id)
        {
            return customerlist.FirstOrDefault(Customer => Customer.Id == id);
        }

        public IEnumerable<Customer> Search(string SearchTerm)
        {
            if (string.IsNullOrEmpty(SearchTerm))
            {
                return customerlist;
            }

            return customerlist.Where(customer => customer.Name.Contains(SearchTerm) || customer.Email.Contains(SearchTerm));
        }

        public Customer UpdateCustomer(Customer UpdatedCustomer)
        {
            Customer customerdata = customerlist.FirstOrDefault(customer=>customer.Id==UpdatedCustomer.Id);
            if (customerdata != null)
            {
                customerdata.Name = UpdatedCustomer.Name;
                customerdata.Email = UpdatedCustomer.Email;
                customerdata.Mobile = UpdatedCustomer.Mobile;
            }
            return customerdata;
        }
    }
}
