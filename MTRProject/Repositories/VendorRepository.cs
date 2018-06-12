using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MTRProject.Models;
using MTRProject.Data;

namespace MTRProject.Repositories
{
    public class VendorRepository : IVendorRepository
    {
        private ApplicationDbContext context;

        public VendorRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public int AddVendor(Vendor vendor)
        {
            context.Vendor.Add(vendor);
            return context.SaveChanges();
        }

        public int DeleteVendor(int id)
        {
            var vendorFromDb = context.Vendor.First(a => a.VendorID == id);
            context.Remove(vendorFromDb);
            return context.SaveChanges();
        }

        public int EditVendor(Vendor vendor)
        {
            var vendorFromDb = GetVendorById(vendor.VendorID);
            vendorFromDb.Name = vendor.Name;
            vendorFromDb.Phone = vendor.Phone;
            vendorFromDb.LoginName = vendor.LoginName;
            vendorFromDb.LoginPassword = vendor.LoginPassword;
            vendorFromDb.Comment = vendor.Comment;
            return context.SaveChanges();
        }
        
		public List<Vendor> GetAllVendors()
		{
			List<Vendor> vendors = context.Vendor.ToList<Vendor>();
            
			return vendors;
		}

		public Vendor GetVendorById(int id)
        {
            return context.Vendor.First(a => a.VendorID == id);
        }

    }
}
