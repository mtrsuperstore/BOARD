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

namespace MTRProject.Controllers
{
    public class VendorController : Controller
    {
        private IVendorRepository vendorRepo;

        public VendorController(IVendorRepository repo)
        {
            vendorRepo = repo;
        }

        // GET: Vendors


        public IActionResult Index()
        {
            return View(vendorRepo.GetAllVendors());
        }

        // GET: Sales/Details/5
        public IActionResult Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendor = vendorRepo.GetVendorById(id);
            if (vendor == null)
            {
                return NotFound();
            }

            return View(vendor);
        }

        // GET: Vendor/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("VendorID,Name,Phone,LoginName,LoginPassword,Comment")] Vendor vendor)
        {
            if (ModelState.IsValid)
            {
                vendorRepo.AddVendor(vendor);
                return RedirectToAction(nameof(Index));
            }
            return View(vendor);
        }

        // GET: Vendor/Edit/5
        public IActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendor = vendorRepo.GetVendorById(id);
            if (vendor == null)
            {
                return NotFound();
            }
            return View(vendor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("VendorID,Name,Phone,LoginName,LoginPassword,Comment")] Vendor vendor)
        {
            if (id != vendor.VendorID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    vendorRepo.EditVendor(vendor);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VendorExists(vendor.VendorID))
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
            return View(vendor);
        }

        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendor = vendorRepo.GetVendorById(id);
            if (vendor == null)
            {
                return NotFound();
            }

            return View(vendor);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var vendor = vendorRepo.DeleteVendor(id);
            return RedirectToAction(nameof(Index));
        }

        private bool VendorExists(int id)
        {
            Vendor vendor = vendorRepo.GetVendorById(id);
            if (vendor != null)
                return true;
            else
                return false;
        }

    }
}