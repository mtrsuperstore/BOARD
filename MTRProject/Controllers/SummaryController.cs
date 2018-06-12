
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MTRProject.Models;

namespace MTRProject.Controllers
{
    public class SummaryController : Controller
    {
        private UserManager<ApplicationUser> userManager;
        public SummaryController(UserManager<ApplicationUser> um, RoleManager<IdentityRole> rm)
        {
            userManager = um;

        }

        public IActionResult Index()
        {
            return View(userManager.Users);
        }

    }
}