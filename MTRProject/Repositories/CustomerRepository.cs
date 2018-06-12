using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MTRProject.Data;
using MTRProject.Models;

namespace MTRProject.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private ApplicationDbContext context;
        private IApplicationUserRepository userRepo;

        public CustomerRepository(ApplicationDbContext ctx, IApplicationUserRepository uRepo)
        {
            context = ctx;
            userRepo = uRepo;
        }


        public int AddCustomer(Customer cust, string userID)
        {
            context.Customer.Add(cust);
            ApplicationUser user = userRepo.GetUserByUserName(userID);
            user.Customers.Add(cust);
            return context.SaveChanges();
        }

        public int EditCustomer(Customer cust)
        {
            
            var custFromDb = GetCustomerById(cust.CustomerID);
            custFromDb.FirstName = cust.FirstName;
            custFromDb.LastName = cust.LastName;
            custFromDb.DeptName = cust.DeptName;
            custFromDb.Email = cust.Email;
            custFromDb.Phone = cust.Phone;
            custFromDb.Comment = cust.Comment;
            return context.SaveChanges();
        }

        public int DeleteCustomer(int id)
        {
            
            var custFromDb = context.Customer.First(c => c.CustomerID == id);
            context.Remove(custFromDb);
            return context.SaveChanges();
        }

        public List<Customer> GetAllCustomers()
        {
            List<Customer> customer = context.Customer.ToList<Customer>();
            return customer;
        }

        public List<CustomerViewModel> GetCustomersByRep(ApplicationUser user)
        {
            var customers = new List<CustomerViewModel>();
            ApplicationUser rep;
            foreach (Customer customer in context.Customer)
            {
                rep = (from r in userRepo.GetAllReps()
                       where r.Customers.Any(c => c.CustomerID == customer.CustomerID)
                       select r).FirstOrDefault<ApplicationUser>();
                if(rep == user)
                {
                    customers.Add(new CustomerViewModel { TheCustomer = customer, TheRep = rep });
                }
            }
            return customers;
        }


        public Customer GetCustomerById(int id)
        {
            return context.Customer.First(c => c.CustomerID == id);
        }

        
    }
}
