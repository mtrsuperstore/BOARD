using MTRProject.Data;
using MTRProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MTRProject.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        private ApplicationDbContext context;
        private IApplicationUserRepository userRepo;

        public SaleRepository(ApplicationDbContext ctx, IApplicationUserRepository uRepo)
        {
            context = ctx;
            userRepo = uRepo;
        }

        public int AddSale(Sale sale, string userID)
        {
            context.Sale.Add(sale);
            ApplicationUser user = userRepo.GetUserByUserName(userID);
            user.Sales.Add(sale);
            return context.SaveChanges();
        }

        public int EditSale(Sale sale)
        {
            var saleFromDb = GetSaleById(sale.SaleID);
            saleFromDb.SaleTotal = sale.SaleTotal;
            saleFromDb.SaleDate = sale.SaleDate;
            saleFromDb.DateEntered = sale.DateEntered;
            return context.SaveChanges();
        }
        public int DeleteSale(int id)
        {
            var saleFromDb = context.Sale.First(s => s.SaleID == id);
            context.Remove(saleFromDb);
            return context.SaveChanges();
        }
        public List<Sale> GetAllSales()
        {
            return context.Sale.ToList();
        }

        public List<SaleViewModel> GetSalesByRep(ApplicationUser user)
        {
            var sales = new List<SaleViewModel>();
            ApplicationUser rep;
            foreach (Sale sale in context.Sale)
            {
                rep = (from r in userRepo.GetAllReps()
                       where r.Sales.Any(s => s.SaleID == sale.SaleID)
                       select r).FirstOrDefault<ApplicationUser>();
                if (rep == user)
                {
                    sales.Add(new SaleViewModel { TheSale = sale, TheRep = rep });
                }
            }
            return sales;
        }

        public List<SummaryViewModel> GetSummary()
        {
            var summary = new List<SummaryViewModel>();
            List<ApplicationUser> reps = userRepo.GetAllReps();
            decimal todaytotal;
            decimal weektotal;
            decimal lastweektotal;
            decimal monthtotal;
            var lastsunday = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek);
            foreach (ApplicationUser u in reps)
            {
                monthtotal = GetRepMonthlySalesTotal(u, DateTime.Today);
                lastweektotal = GetRepSalesTotalByDateRange(u, lastsunday.AddDays(-6), lastsunday.AddDays(-1));
                weektotal = GetRepWeeklySales(u, DateTime.Today);
                todaytotal = GetRepDailySales(u, DateTime.Today);
                summary.Add(new SummaryViewModel
                    { TheRep = u,
                      TodayTotal = todaytotal,
                      ThisWeekTotal = weektotal,
                      LastWeekTotal = lastweektotal,
                      ThisMonthTotal = monthtotal
                    });

            }
            return summary;
        }

        public Sale GetSaleById(int id)
        {
            return context.Sale.First(s => s.SaleID == id);
        }

        public decimal GetRepDailySales(ApplicationUser rep, DateTime day)
        {
            decimal totalSales = 0;

            //access list of user sales 
            List<SaleViewModel> sales = GetSalesByRep(rep);

            //iterate through list and total each sale
            foreach (var s in sales)
            {
                if (s.TheSale.SaleDate.Date == day.Date)
                    totalSales += s.TheSale.SaleTotal;
            }
            //return total
            return totalSales;
        }

        public decimal GetRepWeeklySales(ApplicationUser rep, DateTime day)
        {

            decimal totalSales = 0;

            // gets sunday for calculations
            var sunday = day.AddDays(-(int)day.DayOfWeek);
            List<SaleViewModel> sales = GetSalesByRep(rep);

            //iterate through list and total each sale
            foreach (var s in sales)
            {
                if (s.TheSale.SaleDate >= sunday && s.TheSale.SaleDate <= day)
                    totalSales += s.TheSale.SaleTotal;
            }
            //return total
            return totalSales;

        }

        public decimal GetRepSalesTotalByDateRange(ApplicationUser rep, DateTime first, DateTime last)
        {
            decimal totalSales = 0;

            List<SaleViewModel> sales = GetSalesByRep(rep);

            //iterate through list and total each sale
            foreach (var s in sales)
            {
                if (s.TheSale.SaleDate >= first && s.TheSale.SaleDate <= last)
                    totalSales += s.TheSale.SaleTotal;
            }

            return totalSales;
        }

        // Get current Monthly sales for given rep (TESTED)
        public decimal GetRepMonthlySalesTotal(ApplicationUser rep, DateTime day)
        {
            decimal totalSales = 0;


            //determines 1st of month for calculations
            var first = new DateTime(day.Year, day.Month, 1);

            List<SaleViewModel> sales = GetSalesByRep(rep);

            //iterate through list and total each sale
            foreach (var s in sales)
            {
                if (s.TheSale.SaleDate >= first && s.TheSale.SaleDate <= day)
                    totalSales += s.TheSale.SaleTotal;
            }

            return totalSales;
        }
    }
}
