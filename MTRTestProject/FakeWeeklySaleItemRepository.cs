using System;
using System.Collections.Generic;
using System.Text;
using MTRProject.Models;
using MTRProject.Repositories;
using System.Linq;

namespace MTRTestProject
{
	class FakeWeeklySaleItemRepository : IWeeklySaleItemRepository
	{
		
		public List<WeeklySaleItem> GetAllSaleItems()
		{
			var saleItems = new List<WeeklySaleItem>();
			saleItems.Add(new WeeklySaleItem() { WeeklySaleItemID = 123, ItemName = "Item 1", ItemNumber = "MTR-123", SaleStart = new DateTime(2018, 05, 27), SaleEnd = new DateTime(2018, 06, 02) });
			saleItems.Add(new WeeklySaleItem() { WeeklySaleItemID = 223, ItemName = "Item 2", ItemNumber = "MTR-223", SaleStart = new DateTime(2018, 05, 27), SaleEnd = new DateTime(2018, 06, 02) });
			saleItems.Add(new WeeklySaleItem() { WeeklySaleItemID = 323, ItemName = "Item 3", ItemNumber = "MTR-323", SaleStart = new DateTime(2018, 06, 03), SaleEnd = new DateTime(2018, 06, 09) });
            return saleItems;
		}

		public int AddSaleItem(WeeklySaleItem item)
		{
			throw new NotImplementedException();
		}

		public int DeleteSaleItem(int id)
		{
			throw new NotImplementedException();
		}

		public int EditSaleItem(WeeklySaleItem item)
		{
			throw new NotImplementedException();
		}

		//(TESTED)
		public WeeklySaleItem GetSaleItemById(int id)
		{
			var saleItems = GetAllSaleItems();
			return saleItems.First(b => b.WeeklySaleItemID == id);
		}

		// (TESTED)
		public WeeklySaleItem GetSaleItemByName(string name)
		{
			var saleItems = GetAllSaleItems();
			return saleItems.First(b => b.ItemName == name);
		}

		//(TESTED)
		public WeeklySaleItem GetSaleItemByItemNum(string num)
        {
			var saleItems = GetAllSaleItems();
			return saleItems.First(b => b.ItemNumber == num);

        }

		// (TESTED)
		//Returns current weeks sales total
        public List<WeeklySaleItem> ShowWeeklySales(DateTime date)
        {
            List<WeeklySaleItem> saleItems = GetAllSaleItems();
            List<WeeklySaleItem> weeklySales = new List<WeeklySaleItem>();

            // gets sunday of the week passed in for calculations
            var sundayOfWeek = date.AddDays(-(int)date.DayOfWeek);

            //access list of sale items and create list where date = this week
            foreach (WeeklySaleItem i in saleItems)
            {
                if (i.SaleStart == sundayOfWeek)
                    weeklySales.Add(i);

            }

            return weeklySales;
        }
	}
}
