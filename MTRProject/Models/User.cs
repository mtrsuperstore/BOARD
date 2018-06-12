using Microsoft.AspNetCore.Identity;
using MTRProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MTRProject.Model
{
    public class MTRUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsRep { get; set; }

        private List<Customer> customers = new List<Customer>();
        public List<Customer> Customers { get { return customers; } }

        private List<Sale> sales = new List<Sale>();
        public List<Sale> Sales { get { return sales; } }
    }
}
