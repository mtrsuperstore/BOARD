using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MTRProject.Models;

namespace MTRProject.Repositories
{
    public interface IVendorRepository
    {
        Vendor GetVendorById(int id);
        int AddVendor(Vendor vendor);
        int EditVendor(Vendor vendor);
        int DeleteVendor(int id);
		List<Vendor> GetAllVendors();
    }
}
