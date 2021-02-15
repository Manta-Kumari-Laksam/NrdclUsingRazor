using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NRDCLRazor.Models;
using NRDCLRazor.Services;

namespace NRDCLRazor.Pages.Customers
{
    public class DeleteModel : PageModel
    {
        private readonly ICustomerRepository customerRepository;

        public DeleteModel(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }
        [BindProperty]
        public Customer customer { get; set; }
        public IActionResult OnGet(string id)
        {
            customer = customerRepository.GetCustomer(id);
            if(customer == null)
            {
                return RedirectToPage("/NotFound");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            Customer customerToDelete = customerRepository.DeleteCustomer(customer.Id);
            if(customerToDelete == null)
            {
                return RedirectToPage("/NotFound");
            }
            return RedirectToPage("Index");
        }
    }
}
