using Microsoft.EntityFrameworkCore;
using NRDCLRazor.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NRDCLRazor.Services
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
    }
}
