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
    public class EditModel : PageModel
    {
        private readonly ICustomerRepository customerRepository;

        public EditModel(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }
        [BindProperty]
        public Customer customer{ get; set; }
#nullable enable
        public IActionResult OnGet(string? id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                customer = customerRepository.GetCustomer(id);
            }
            else
            {
                customer = new Customer();
            }
            
            if (customer == null)
            {
                return RedirectToPage("/NotFound");
            }
            return Page();
        }
        public IActionResult OnPost() 
        {

            if (ModelState.IsValid)
            {
                if(Convert.ToInt32(customer.Id) > 0)
                {
                    customerRepository.UpdateCustomer(customer);
                }
                else
                {
                    customerRepository.AddCustomer(customer);
                }
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
