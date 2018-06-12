using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MTRProject.Models;

namespace MTRProject.Repositories
{
    public interface ICustomerRepository
    {
        int AddCustomer(Customer cust, string userID);
        int EditCustomer(Customer cust);
        int DeleteCustomer(int id);
        List<Customer> GetAllCustomers();
        Customer GetCustomerById(int id);
        List<CustomerViewModel> GetCustomersByRep(ApplicationUser user);
    }
}
