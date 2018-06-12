using MTRProject.Models;
using MTRProject.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MTRTestProject
{
    class FakeCustomerRepository : ICustomerRepository
    {
        public List<Customer> GetAllCustomers()
        {
            var customers = new List<Customer>();
            customers.Add(new Customer()
            {
                CustomerID = 100,
                FirstName = "John",
                LastName = "Smith",
                DeptName = "Eugene/Springfield",
                Email = "JSmith@Eugenefire.org",
                Phone = "541-555-1234",
                Comment = "Local Customer"
            });
            customers.Add(new Customer()
            {
                CustomerID = 200,
                FirstName = "Robin",
                LastName = "Cool",
                DeptName = "Portland Sales",
                Email = "RCool@Socks.com",
                Phone = "541-555-5678",
                Comment = ""
            });
            customers.Add(new Customer()
            {
                CustomerID = 300,
                FirstName = "Steve",
                LastName = "Rogers",
                DeptName = "Brooklyn Office",
                Email = "steverogers@army.gov",
                Phone = "541-555-1111",
                Comment = "Local Customer"
            });
            return customers;
        }

        public int AddCustomer(Customer cust, string userID)
        {
            throw new NotImplementedException();
        }

        public int DeleteCustomer(int id)
        {
            throw new NotImplementedException();
        }

        public int EditCustomer(Customer cust)
        {
            throw new NotImplementedException();
        }


        public Customer GetCustomerById(int id)
        {
            var customers = GetAllCustomers();
            return customers.First(c => c.CustomerID == id);
        }

        public List<CustomerViewModel> GetCustomersByRep(ApplicationUser user)
        {
            throw new NotImplementedException();
        }
    }
}
