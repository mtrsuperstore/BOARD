using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MTRProject.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsSalesRep { get; set; }

        private List<Customer> customers = new List<Customer>();
        public List<Customer> Customers { get { return customers; } }

        private List<Sale> sales = new List<Sale>();
        public List<Sale> Sales { get { return sales; } }
    }
}
