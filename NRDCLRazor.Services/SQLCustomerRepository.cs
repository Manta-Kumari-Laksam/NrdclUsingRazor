using NRDCLRazor.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace NRDCLRazor.Services
{
    public class SQLCustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext context;

        public SQLCustomerRepository(AppDbContext context)
        {
            this.context = context;
        }
        public Customer AddCustomer(Customer newcustomer)
        {
            newcustomer.Id = Convert.ToString(Convert.ToInt32(context.Customers.Max(customerlist => customerlist.Id)) + 1);
            context.Customers.Add(newcustomer);
            context.SaveChanges();
            return newcustomer;
        }

        public Customer DeleteCustomer(string id)
        {
            Customer customer = context.Customers.Find(id);
            if (customer != null)
            {
                context.Customers.Remove(customer);
                context.SaveChanges();
            }
            return customer;
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return context.Customers;
        }

        public Customer GetCustomer(string id)
        {
            return context.Customers.Find(id);
        }

        public IEnumerable<Customer> Search(string SearchTerm)
        {
            if (string.IsNullOrEmpty(SearchTerm))
            {
                return context.Customers;
            }

            return context.Customers.Where(customer => customer.Name.Contains(SearchTerm) || customer.Email.Contains(SearchTerm));
        }

        public Customer UpdateCustomer(Customer customer)
        {
            var customerUpdate= context.Customers.Attach(customer);
            customerUpdate.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return customer;
        }
    }
}
