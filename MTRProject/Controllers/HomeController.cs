using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MTRProject.Data;
using MTRProject.Models;

namespace MTRProject.Controllers
{
    public class HomeController : Controller
    {

        private readonly ApplicationDbContext _context;
         public IActionResult Index()
         {
            return RedirectToRoute(new
            {
                controller = "Account",
                action = "Login"
                
            });
        }

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Sales()
        {
            return View(await _context.Sale.ToListAsync());
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        
        public IActionResult AddSale()
        {
            return View();
        }

        public IActionResult DeleteSale()
        {
            return View();
        }

        public IActionResult EditSale()
        {
            return View();
        }

        public IActionResult ShowAllReps()
        {
            return View();
        }




        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }




    }
}
