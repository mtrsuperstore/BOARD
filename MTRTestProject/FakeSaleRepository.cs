using System;
using System.Collections.Generic;
using System.Text;
using MTRProject.Models;
using MTRProject.Repositories;
using System.Linq;

namespace MTRTestProject
{
    class FakeSaleRepository : ISaleRepository
    {
		public List<Sale> sales = new List<Sale>();
		public Sale s1 = new Sale { SaleID = 111, SaleTotal = 100, DateEntered = new DateTime(2018, 04, 20), SaleDate = new DateTime(2018, 04, 27) };
		public Sale s2 = new Sale { SaleID = 222, SaleTotal = 200, DateEntered = DateTime.Now, SaleDate = DateTime.Now };
		public Sale s3 = new Sale { SaleID = 333, SaleTotal = 300, DateEntered = DateTime.Now, SaleDate = DateTime.Now };
        
        

        public int AddSale(Sale sale, string userID)
        {
            sales.Add(sale);
            Sale newSale = sales.Last();
            return newSale.SaleID;
        }

        public int DeleteSale(int id)
        {
            throw new NotImplementedException();
        }

        public int EditSale(Sale sale)
        {
            throw new NotImplementedException();
        }

        public List<Sale> GetAllSales()
        {
			sales.Add(s1);
			sales.Add(s2);
			sales.Add(s3);
            return sales;
        }

		public Sale GetSaleById(int id)
		{
			var sList = GetAllSales();
			return sList.First(b => b.SaleID == id);
		}

        public List<SaleViewModel> GetSalesByRep(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public List<SummaryViewModel> GetSummary()
        {
            throw new NotImplementedException();
        }




        // Methods below moved to SalesController

        //public List<Sale> GetSalesByDate(DateTime date)
        //     {
        //List<Sale> list = GetAllSales();
        //         List<Sale> dateSales = new List<Sale>();


        //foreach (Sale s in list)
        //         {

        //	if (s.SaleDate == date)
        //	    dateSales.Add(s);

        //         }

        //return dateSales;

        //}

        //public List<Sale> GetSalesByDateRange(DateTime date1, DateTime date2)
        //{

        //    //return DateRangeList;
        //    throw new NotImplementedException();
        //}


    }
}
