using NRDCLRazor.Models;
using System;
using System.Collections.Generic;

namespace NRDCLRazor.Services
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> Search(string SearchTerm);
        IEnumerable<Customer> GetAllCustomers();
        Customer GetCustomer(string id);
        Customer UpdateCustomer(Customer customer);
        Customer AddCustomer(Customer newcustomer);
        Customer DeleteCustomer(string id);
    }
}
