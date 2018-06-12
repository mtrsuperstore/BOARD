using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MTRProject.Data;
using MTRProject.Models;
using MTRProject.Repositories;
using Microsoft.AspNetCore.Identity;


namespace MTRProject.Controllers
{
    public class SalesController : Controller
    {

        private ISaleRepository saleRepo;
        private IApplicationUserRepository userRepo;
        private readonly UserManager<ApplicationUser> _userManager;

        //I added the following 3 lines of code to see if we could use both variations of this code(above and below)
        public SalesController(ISaleRepository repo, UserManager<ApplicationUser> userManager, IApplicationUserRepository uRepo)
        {
            saleRepo = repo;
            _userManager = userManager;
            userRepo = uRepo;
        }

        public string GetCurrentUserId() => _userManager.GetUserAsync(HttpContext.User).Result.Id ?? 0.ToString();

        // GET: Sales

		public IActionResult Summary()
        {
            return View(saleRepo.GetSummary());
            //return View(repController.OrderRepsByLastMonthSales(DateTime.Today));
        }
        
        public IActionResult Index()
        {
            var id = GetCurrentUserId();
            ApplicationUser user = userRepo.GetUserByUserName(id);
            return View(saleRepo.GetSalesByRep(user));
        }

        // GET: Sales/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sale = saleRepo.GetSaleById(id.GetValueOrDefault());
            if (sale == null)
            {
                return NotFound();
            }

            return View(sale);
        }

        // GET: Sales/Create
        public IActionResult Create()
        {
            Sale sale = new Sale();
            sale.DateEntered = DateTime.Today;
            sale.SaleDate = DateTime.Today;
            return View(sale);
        }

        // POST: Sales/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("SaleID,SaleTotal,DateEntered,SaleDate")] Sale sale)
        {
            if (ModelState.IsValid)
            {
                var id = GetCurrentUserId();
                saleRepo.AddSale(sale, id);
                return RedirectToAction(nameof(Index));
            }
            return View(sale);
        }

        // GET: Sales/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sale = saleRepo.GetSaleById(id.GetValueOrDefault());
            if (sale == null)
            {
                return NotFound();
            }

            return View(sale);

        }

        // POST: Sales/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("SaleID,SaleTotal,DateEntered,SaleDate")] Sale sale)
        {
            if (id != sale.SaleID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    saleRepo.EditSale(sale);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SaleExists(sale.SaleID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(sale);
        }

        // GET: Sales/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sale = saleRepo.GetSaleById(id.GetValueOrDefault());
            if (sale == null)
            {
                return NotFound();
            }

            return View(sale);
        }

        // POST: Sales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var sale = saleRepo.DeleteSale(id);
            return RedirectToAction(nameof(Index));
        }

        private bool SaleExists(int id)
        {
            Sale sale = saleRepo.GetSaleById(id);
            if (sale != null)
                return true;
            else
                return false;
        }


        /******* CALCULATIONS *******/

        // returns CURRENT weekly total (TESTED )
        public decimal WeeklyTotal()
        {
			// gets "today"
			DateTime day = DateTime.Today;

            // calculates "this week" total and returns it
			return GetAllRepsWeeklySales(day);             
        }

		//Returns CURRENT month total (TESTED)
		public decimal MonthlyTotal()
        {
            // gets "today"
            DateTime day = DateTime.Today;

			// calculates "this month" total and returns it
			return GetAllRepsMonthlySalesTotal(day);
        }

		// This method returns the total sales for a day (TESTED)
		public decimal GetAllRepsDailySales(DateTime day)
        {
            decimal totalSales = 0;
            
			List<Sale> allSales = saleRepo.GetAllSales();
            
			//iterate through list and total each sale
            foreach (Sale s in allSales)
            {
				if(s.SaleDate == day)
                    totalSales += s.SaleTotal;
            }
            //return total
            return totalSales;
        }

		//This method returns the SalesEntered total per week for all reps (TESTED)
        public decimal GetAllRepsWeeklySales(DateTime day)
        {
            decimal totalSales = 0;

			//Gets day of week represented as an integer
			int dayOfWeek = (int)day.DayOfWeek;

            //determines sunday for calculations for the week
			var sunday = day.AddDays(-(int)DateTime.Today.DayOfWeek);
            
			List<Sale> allSales = saleRepo.GetAllSales();
			//iterate through list and total each sale
            foreach (Sale s in allSales)
            {
				if (s.SaleDate >= sunday && s.SaleDate <= sunday.AddDays(6))
				{
					totalSales += s.SaleTotal;
				}
					  
            }
            
            //return total
            return totalSales;
        }

		// Takes in a day and gets total from first of month to that day (TESTED)
		public decimal GetAllRepsMonthlySalesTotal(DateTime day)
        {
            decimal totalSales = 0;

            //Gets day of week represented as an integer
            int dayOfWeek = (int)day.DayOfWeek;
                        
			//determines 1st of month for calculations
			var firstOfMonth = new DateTime(day.Year, day.Month, 1);

			//access list of sales and create list where date range is "this" month 
			List<Sale> MonthlySales = saleRepo.GetAllSales();

            //iterate through list and total each sale
            foreach (Sale s in MonthlySales)
            {
				if(s.SaleDate <= day && s.SaleDate >= firstOfMonth)
                    totalSales += s.SaleTotal;
            }
            
            return totalSales;
        }

		// gets current year to date total for all reps (TESTED) 
		// -- needs code for year Changed in method for testing purposes --
		public decimal GetAllRepsYearSalesToDate()
		{
			decimal totalSales = 0;
           
			//determines 1st of year
			DateTime nowDate = DateTime.Today;

            // Fake nowDate for testing. Using DateTime.Now got 
			//tricky because the seed data came into play. (Passed)
			//DateTime nowDate = new DateTime(2016, 06, 01);

			DateTime first = new DateTime(nowDate.Year, 1, 1);

			//access list of sales 
			var all = saleRepo.GetAllSales();

			var ytdSales = GetSalesByDateRange(first, nowDate) as List<Sale>;

			foreach (Sale l in ytdSales)
			{
				totalSales += l.SaleTotal;
			}

			return totalSales;
		}
        

		// Get Monthly sales by rep for previous year (TESTED)
        public decimal GetLastYearThisMonthSalesTotal(DateTime day)
        {
            decimal totalSales = 0;
          
            //Gets day of week represented as an integer
            int dayOfWeek = (int)day.DayOfWeek;

            //determines 1st of month for calculations
            var lastYearFirst = new DateTime(day.Year - 1, 01, 01);
            var lastYearDays = DateTime.DaysInMonth(day.Year - 1, day.Month);
            var lastYearLast = new DateTime(day.Year - 1 , day.Month, lastYearDays);
            
			var lastYearMonth = GetSalesByDateRange(lastYearFirst, lastYearLast) as List<Sale>;

			foreach(Sale l in lastYearMonth)
			{
				totalSales += l.SaleTotal;
			}

            return totalSales;
        }
        

		// Calculates total sales for a given date (TESTED)
		public List<Sale> GetSalesByDate(DateTime date)
        {
            List<Sale> list = saleRepo.GetAllSales();
            List<Sale> dateSales = new List<Sale>();


            foreach (Sale s in list)
            {

                if (s.SaleDate == date)
                    dateSales.Add(s);

            }

            return dateSales;

        }

		// Calculates total sales for a given date range (TESTED)
        public List<Sale> GetSalesByDateRange(DateTime date1, DateTime date2)
        {
			List<Sale> list = saleRepo.GetAllSales();
            List<Sale> dateSales = new List<Sale>();

			foreach (Sale s in list)
            {

				if (s.SaleDate >= date1 && s.SaleDate <= date2)
                    dateSales.Add(s);

            }

            return dateSales;
        }
    }
}
