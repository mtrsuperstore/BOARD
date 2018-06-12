using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MTRProject.Models
{
    public class SaleViewModel
    {
        public Sale TheSale { get; set; }
        public ApplicationUser TheRep { get; set; }
    }
}
