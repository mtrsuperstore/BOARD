using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MTRProject.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Department")]
        public string DeptName { get; set; }
        [Required]
        public string Email { get; set; }
        //Add format to Phone to only accept (###) ###-###
        [Required]
        [RegularExpression(@"^\(\d{3}\)\s\d{3}-\d{4}", ErrorMessage = "Please use the following format: (###) ###-####")]
        public string Phone { get; set; }
        public string Comment { get; set; }
    }
}
