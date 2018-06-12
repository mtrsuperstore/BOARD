using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MTRProject.Models
{
    public class CustomerViewModel
    {
        public Customer TheCustomer { get; set; }
        public ApplicationUser TheRep { get; set; }
    }
}
