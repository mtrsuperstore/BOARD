using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MTRProject.Models;
using MTRProject.Data;

namespace MTRProject.Repositories
{
    public interface IWeeklySaleItemRepository
    {
        List<WeeklySaleItem> ShowWeeklySales(DateTime startDate);
		WeeklySaleItem GetSaleItemByName(string name);
        List<WeeklySaleItem> GetAllSaleItems();
        WeeklySaleItem GetSaleItemById(int id);
		WeeklySaleItem GetSaleItemByItemNum(string num);
        int AddSaleItem(WeeklySaleItem item);
		int EditSaleItem(WeeklySaleItem item);
        int DeleteSaleItem(int id);
    }
}
