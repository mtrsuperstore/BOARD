using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MTRProject.Models
{
    public class Sale
    {

        public int SaleID { get; set; }
        [Required]
        [Display(Name = "Sale Total")]
        public decimal SaleTotal { get; set; }
        //will default to sysdate and is the date the sale was entered 
        //into the system
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Required]
        [Display(Name = "Date Entered")]
        [DataType(DataType.Date)]
        public DateTime DateEntered { get; set; }
        //the date the sales was made.  will default to sysdate
        //and will be rarely changed to yesterday's date
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Required]
        [Display(Name = "Sale Date")]
        [DataType(DataType.Date)]
        public DateTime SaleDate { get; set; }

    }
}
