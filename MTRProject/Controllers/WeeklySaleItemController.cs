using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MTRProject.Data;
using MTRProject.Models;
using MTRProject.Repositories;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MTRProject.Controllers
{
    public class WeeklySaleItemController : Controller
    {
        
		private IWeeklySaleItemRepository repo;
        
        
		public WeeklySaleItemController(IWeeklySaleItemRepository repo)
        {
			this.repo = repo;
        }


        // GET: /<controller>/
		// Index returns this weeks sales (untested)
        public IActionResult Index()
        {
			DateTime today = DateTime.Today;
			var thisWeek = repo.ShowWeeklySales(today);
			return View(thisWeek);
        }



		// create entry
        public IActionResult Create()
        {
            return View();
        }

		// see all items
        public IActionResult SeeAll()
        {
			List<WeeklySaleItem> all = repo.GetAllSaleItems();
            return View(all);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
		public IActionResult Create([Bind("ItemNumber,ItemName,Cost,SalePrice,CommissionRate,SaleStart,SaleEnd")] WeeklySaleItem item)
        {
			item.SaleStart = DateTime.Today;
			item.SaleEnd = DateTime.Today.AddDays(6);

			if (ModelState.IsValid)
			{
				repo.AddSaleItem(item);
				return RedirectToAction(nameof(Create));
			}
            
			return RedirectToAction(nameof(Index));
        }
        
        // GET: 
        public IActionResult Edit(int id)
        {

			var item = repo.GetSaleItemById(id); 
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        
		[HttpPost]
        [ValidateAntiForgeryToken]
		public IActionResult Edit(int id, [Bind("ItemNumber,ItemName,Cost,SalePrice,CommissionRate,SaleStart,SaleEnd")] WeeklySaleItem item)
        {
			repo.EditSaleItem(item);
			return RedirectToAction(nameof(Index));
        }
        

        public IActionResult Delete(int id)
        {

			var item = repo.GetSaleItemById(id);
			if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {

			repo.DeleteSaleItem(id);
            return RedirectToAction(nameof(Index));
        }
              
    }
}
