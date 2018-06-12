using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MTRProject.Models
{
    public class Vendor
    {
        public int VendorID { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public string Phone { get; set; }

        [Display(Name = "Login Name")]
        public string LoginName { get; set; }

        [Display(Name = "Login Password")]
        public string LoginPassword { get; set; }
        public string Comment { get; set; }
    }
}
