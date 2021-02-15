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
    public class IndexModel : PageModel
    {
        private readonly ICustomerRepository customerRepository;
        public IEnumerable<Customer> customers { get; set; }
        [BindProperty(SupportsGet =true)]
        public string SearchTerm { get; set; }
        public IndexModel(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }
        public void OnGet()
        {
            customers = customerRepository.Search(SearchTerm);
        }
    }
}
