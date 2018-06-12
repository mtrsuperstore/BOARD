using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MTRProject.Data;
using MTRProject.Models;
using Microsoft.AspNetCore.Identity;
using MTRProject.Repositories;
using System.Security.Claims;



// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MTRProject.Controllers
{
    public class CustomerController : Controller
    {
        //private readonly ApplicationDbContext _context;
        private ICustomerRepository customerRepo;
        private IApplicationUserRepository userRepo;
        private readonly UserManager<ApplicationUser> _userManager;


        public CustomerController(ICustomerRepository repo, UserManager<ApplicationUser> userManager, IApplicationUserRepository uRepo)
        {
            customerRepo = repo;
            _userManager = userManager;
            userRepo = uRepo;
        }

        public string GetCurrentUserId() => _userManager.GetUserAsync(HttpContext.User).Result.Id ?? 0.ToString();

        // GET: /<controller>/
        public IActionResult Index()
        {
            var id = GetCurrentUserId();
            ApplicationUser user = userRepo.GetUserByUserName(id);
            return View(customerRepo.GetCustomersByRep(user));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("CustomerID,FirstName,LastName,DeptName,Email,Phone,Comment")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                var id = GetCurrentUserId();
                customerRepo.AddCustomer(customer, id);
                return RedirectToAction(nameof(Index));       
            }
            return View(customer);
        }

        // GET: Customer/Edit/5
        public IActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = customerRepo.GetCustomerById(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("CustomerID,FirstName,LastName,DeptName,Email,Phone,Comment")] Customer customer)
        {
            if (id != customer.CustomerID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    customerRepo.EditCustomer(customer);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.CustomerID))
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
            return View(customer);
        }

        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = customerRepo.GetCustomerById(id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var customer = customerRepo.DeleteCustomer(id);
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(int id)
        {
            Customer customer = customerRepo.GetCustomerById(id);
            if (customer != null)
                return true;
            else
                return false;
        }


    }
}
