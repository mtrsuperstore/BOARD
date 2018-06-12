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

namespace MTRProject.Controllers
{
    public class SalesRepsController : Controller
    {
        private IApplicationUserRepository userRepo;
        private UserManager<ApplicationUser> userManager;

        public SalesRepsController(UserManager<ApplicationUser> um, IApplicationUserRepository repo)
        {
             userManager = um;
            userRepo = repo;
        }

        // GET: SalesReps
        public IActionResult Index()
        {
           
			return View(userRepo.GetAllReps());

        }

        public IActionResult Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = userRepo.GetUserByUserName(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        //(TESTED)
        public ApplicationUser GetUserByUserName(string uName)
        {
            return userRepo.GetUserByUserName(uName);
        }

        // ****Method didn't work and didn't pull any sales, moved to SaleRepo and updated
        // Calculates total sales for a day from rep sale list property (TESTED)
        //public decimal GetRepDailySales(string uName, DateTime day)
        //      {
        //          //find rep passed in
        //	ApplicationUser rep = userRepo.GetUserByUserName(uName);
        //          decimal totalSales = 0;

        //	//access list of user sales 
        //	List<Sale> userSales = rep.Sales;

        //          //iterate through list and total each sale
        //          foreach (Sale s in userSales)
        //          {
        //		if(s.SaleDate == day)
        //                  totalSales += s.SaleTotal;
        //          }
        //          //return total
        //          return totalSales;
        //      }

        // ****Method didn't work and didn't pull any sales, moved to SaleRepo and updated
        // Calculates total sales for the week from rep sale list property (TESTED)
        //NOTE: written for current week only
        //NOTE get sales range written below
        //     public decimal GetRepWeeklySalesTotal(ApplicationUser salesRep, DateTime day)
        //     {

        //         decimal totalSales = 0;

        //         // gets sunday for calculations
        //var sunday = day.AddDays(-(int)day.DayOfWeek);
        //var userSales = userRepo.GetRepSalesList(salesRep);

        //         //iterate through list and total each sale
        //         foreach (Sale s in userSales)
        //         {
        //	if (s.SaleDate >= sunday && s.SaleDate <= day)
        //                 totalSales += s.SaleTotal;
        //         }
        //         //return total
        //         return totalSales;

        //     }
        // ****Method didn't work and didn't pull any sales, moved to SaleRepo and updated
        //NOTE: The following method is written assuming the position of wanting  
        // current month to date.
        // Get current Monthly sales for given rep (TESTED)
        //public decimal GetRepMonthlySalesTotal(ApplicationUser salesRep, DateTime day)
        //      {
        //          decimal totalSales = 0;


        //	//determines 1st of month for calculations
        //	var first = new DateTime(day.Year, day.Month, 1);

        //	var userSales = userRepo.GetRepSalesList(salesRep);

        //          //iterate through list and total each sale
        //          foreach (Sale s in userSales)
        //          {
        //		if (s.SaleDate >= first && s.SaleDate <= day)
        //                  totalSales += s.SaleTotal;
        //          }

        //          return totalSales;
        //      }

        // Calculates total sales for current year to date from rep sale list property (TESTED)
        public decimal GetRepYtdSalesTotal(ApplicationUser salesRep, DateTime day)
        {
			decimal totalSales = 0;


            //determines 1st of month for calculations
            var first = new DateTime(day.Year,  1, 1);

            var userSales = userRepo.GetRepSalesList(salesRep);

            //iterate through list and total each sale
            foreach (Sale s in userSales)
            {
                if (s.SaleDate >= first && s.SaleDate <= day)
                    totalSales += s.SaleTotal;
            }

            return totalSales;
        }

        // ****Method didn't work and didn't pull any sales, moved to SaleRepo and updated
        // Calculates total sales for the given date range from rep sale list property (TESTED)
        //public decimal GetRepSalesTotalByDateRange(ApplicationUser salesRep, DateTime first, DateTime last)
        //      {
        //	decimal totalSales = 0;

        //          var userSales = userRepo.GetRepSalesList(salesRep);

        //          //iterate through list and total each sale
        //          foreach (Sale s in userSales)
        //          {
        //              if (s.SaleDate >= first && s.SaleDate <= last)
        //                  totalSales += s.SaleTotal;
        //          }

        //          return totalSales;
        //      }

        // Get Monthly sales by rep for previous year this month   (TESTED)
        // Expecing day to be current month (if not current date)
        public decimal GetRepLastYearThisMonthSalesTotal(ApplicationUser salesRep, DateTime day)
        {
			decimal totalSales = 0;

            var userSales = userRepo.GetRepSalesList(salesRep);

			var firstOfMonthLastYear = new DateTime(day.Year - 1, day.Month, 01);
			var lastOfMonthLastYear = new DateTime(day.Year - 1, day.Month, DateTime.DaysInMonth(day.Year - 1, day.Month));
            //iterate through list and total each sale
            foreach (Sale s in userSales)
            {
				if (s.SaleDate >= firstOfMonthLastYear && s.SaleDate <= lastOfMonthLastYear)
                    totalSales += s.SaleTotal;
            }

            return totalSales;
        }


        // Last one untested below...

        //Reorder list of reps by last month sales
        //for use on sales view
		public List<ApplicationUser> OrderRepsByLastMonthSales(DateTime day)
		{
			//assign variables to determine last months first and last days
            var today = DateTime.Today;
            var firstOfMonth = new DateTime(today.Year, today.Month, 1);
			var last = new DateTime(today.Year, today.Month, DateTime.DaysInMonth(today.Year, today.Month));
            
			// create list of all users
			List<ApplicationUser> reps = new List<ApplicationUser>();
			List<Decimal> monthlyTotals = new List<Decimal>();

			var allUsers = userRepo.GetAllReps();

			foreach(ApplicationUser a in allUsers)
			{
				if (a.IsSalesRep == true)
					reps.Add(a);
			}
            
			//should return a list ordered from lowest total to highest if things went right. Will  have to reverse the order 
            //To display from highest to lowest.
			reps.OrderBy(x => x.Sales);

			//I'm hoping this reverses the list to start with highest total
			reps.Reverse();

			return reps;
		}
        
    }
}
