using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MTRProject.Data;
using MTRProject.Models;
using Microsoft.AspNetCore.Identity;
using MTRProject.Repositories;
using MTRProject.Controllers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;


namespace MTRProject.Models
{
    public class SummaryViewModel
    {
        public SalesRepsController repController;
        public SalesController salesController;

        public ApplicationUser TheRep { get; set; }
        public decimal TodayTotal { get; set; }
        public decimal ThisWeekTotal { get; set; }
        public decimal LastWeekTotal { get; set; }
        public decimal ThisMonthTotal { get; set; }
        //public decimal YearToDate { get; set; }
    }

}
