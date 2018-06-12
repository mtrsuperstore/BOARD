using MTRProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MTRProject.Repositories
{
    public interface ISaleRepository
    {
        int AddSale(Sale sale, string userID);
        int EditSale(Sale sale);
        int DeleteSale(int id);
		Sale GetSaleById(int id);
        List<Sale> GetAllSales();
        List<SaleViewModel> GetSalesByRep(ApplicationUser user);
        List<SummaryViewModel> GetSummary();
        //List<Sale> GetSalesByDate(DateTime date);
        //List<Sale> GetSalesByDateRange(DateTime date1, DateTime date2);
    }
}
