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
    public class DetailsModel : PageModel
    {
        private readonly ICustomerRepository customerRepository;

        public DetailsModel(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public Customer customer { get; private set; }

        public IActionResult OnGet(string id)
        {
            customer =  customerRepository.GetCustomer(id);
            if (customer == null)
            {
                return RedirectToPage("/NotFound");
            }
            return Page();
        }
    }
}
