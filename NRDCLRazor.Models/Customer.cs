using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NRDCLRazor.Models
{
    public class Customer
    {
        public string Id { get; set; }

        [Required]
        [MinLength(3, ErrorMessage ="Minimum length should be 3")]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        public string Mobile { get; set; }
    }
}
