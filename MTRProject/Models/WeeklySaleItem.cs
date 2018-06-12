using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace MTRProject.Models
{
    public class WeeklySaleItem
    {
        public int WeeklySaleItemID { get; set; }
        // ItemNumber is MTR item number in their system
        [Required]
        [Display(Name = "Item Number")]
        public string ItemNumber { get; set; }

        [Required]
        [Display(Name = "Item Name")]
        public string ItemName { get; set; }
        public decimal Cost { get; set; }
        [Required]
        [Display(Name = "Sale Price")]
        public decimal SalePrice { get; set; }

        [Required]
        [Display(Name = "Commission Rate")]
        public decimal CommissionRate { get; set; }
        //SaleStart refers to the sunday at the beginning of the week for the sake of calculations.
        //The AddSale Method automatically calculates the sunday prior to the day entered.
        [BindNever]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        [Display(Name = "Sale Start")]
        public DateTime SaleStart { get; set; }
		[BindNever]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        [Display(Name = "Sale End")]
        public DateTime SaleEnd { get; set; }
    }
}
