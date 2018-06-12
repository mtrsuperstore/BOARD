using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MTRProject.Models;
using MTRProject.Data;
using MTRProject.Controllers;

namespace MTRProject.Repositories
{
    public class WeeklySaleItemRepository : IWeeklySaleItemRepository
    {
        private ApplicationDbContext context;

        public WeeklySaleItemRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public int AddSaleItem(WeeklySaleItem item)
        {
			item.SaleStart = item.SaleStart.AddDays(-(int)item.SaleStart.DayOfWeek);
			item.SaleEnd = item.SaleStart.AddDays(6);   
            context.WeeklySaleItem.Add(item);
            return context.SaveChanges();
        }

        public int DeleteSaleItem(int id)
        {
            var saleItemFromDb = context.WeeklySaleItem.First(a => a.WeeklySaleItemID == id);
            context.Remove(saleItemFromDb);
            return context.SaveChanges();
        }
        
		public int EditSaleItem(WeeklySaleItem item)
        {
			context.Update(item);
			return context.SaveChanges();
            
        }                   
        
		public List<WeeklySaleItem> GetAllSaleItems()
        {
            var saleItems = new List<WeeklySaleItem>();

			foreach(WeeklySaleItem w in context.WeeklySaleItem)
			{
				saleItems.Add(w);
			}

            return saleItems;
        }

        public WeeklySaleItem GetSaleItemById(int id)
        {
			var saleItems = GetAllSaleItems();
            return saleItems.First(b => b.WeeklySaleItemID == id);
        }

        public WeeklySaleItem GetSaleItemByName(string name)
        {
			var saleItems = GetAllSaleItems();
            return saleItems.First(b => b.ItemName == name);
        }

		public WeeklySaleItem GetSaleItemByItemNum(string num)
        {
			var saleItems = GetAllSaleItems();
            return saleItems.First(b => b.ItemNumber == num);
        }

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
				if (i.SaleStart.Day == sundayOfWeek.Day)
                    weeklySales.Add(i);
                
            }

            return weeklySales;
        }

        
    }
}
