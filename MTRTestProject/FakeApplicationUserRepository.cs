using System;
using System.Collections.Generic;
using System.Text;
using MTRProject.Models;
using MTRProject.Repositories;
using System.Linq;

namespace MTRTestProject
{
    class FakeApplicationUserRepository : IApplicationUserRepository
    {

		public List<ApplicationUser> users = new List<ApplicationUser>();
        
        public FakeApplicationUserRepository()
        {
			ApplicationUser u1 = new ApplicationUser { FirstName = "Jessica", LastName = "Hatch", Email = "jessica@mtrsuperstore.com", UserName = "jessica@mtrsuperstore.com" };
			ApplicationUser u2 = new ApplicationUser { FirstName = "Mickey", LastName = "Mouse", Email = "Mouse@mtrsuperstore.com", UserName = "Mouse@mtrsuperstore.com" };
			ApplicationUser u3 = new ApplicationUser { FirstName = "Steve", LastName = "Stiffler", Email = "Stiffy@mtrsuperstore.com", UserName = "Stiffy@mtrsuperstore.com" };


            Sale sale2 = new Sale
            {
                SaleTotal = 200,
                DateEntered = DateTime.Now,
                SaleDate = DateTime.Now
            };
            u1.Sales.Add(sale2);

            Sale sale3 = new Sale
            {
                SaleTotal = 300,
                DateEntered = DateTime.Now,
                SaleDate = DateTime.Now
            };
            u2.Sales.Add(sale3);

            Sale sale1 = new Sale
            {
                SaleTotal = 100,
                DateEntered = DateTime.Now,
                SaleDate = DateTime.Now
            };
            u2.Sales.Add(sale1);
            

            Sale sale4 = new Sale
            {
                SaleTotal = 400,
                DateEntered = DateTime.Now,
                SaleDate = DateTime.Now,
            };
            u3.Sales.Add(sale4);

            Sale sale5 = new Sale
            {
                SaleTotal = 500,
                DateEntered = DateTime.Now,
                SaleDate = DateTime.Now,
            };
            u3.Sales.Add(sale5);

            Sale sale6 = new Sale
            {
                SaleTotal = 600,
                DateEntered = DateTime.Now,
                SaleDate = new DateTime(2018, 05, 01),
            };
            u3.Sales.Add(sale6);

            Customer cust1 = new Customer
            {
                CustomerID = 100,
                FirstName = "John",
                LastName = "Smith",
                DeptName = "Eugene/Springfield",
                Email = "JSmith@Eugenefire.org",
                Phone = "541-555-1234",
                Comment = "Local Customer"
            };
            u1.Customers.Add(cust1);

            Customer cust2 = new Customer
            {
                CustomerID = 200,
                FirstName = "Robin",
                LastName = "Cool",
                DeptName = "Portland Sales",
                Email = "RCool@Socks.com",
                Phone = "541-555-5678",
                Comment = ""
            };
            u1.Customers.Add(cust2);

            Customer cust3 = new Customer
            {
                CustomerID = 300,
                FirstName = "Steve",
                LastName = "Rogers",
                DeptName = "Brooklyn Office",
                Email = "steverogers@army.gov",
                Phone = "541-555-1111",
                Comment = "Local Customer"
            };
            u2.Customers.Add(cust3);
            users.Add(u1);
            users.Add(u2);
            users.Add(u3);
        }

       
        public int AddUser(ApplicationUser u)
        {
            users.Add(u);
            ApplicationUser newUser = users.Last();
            return users.Count;
        }

        public int DeleteUser(string id)
        {
            throw new NotImplementedException();
        }

        public int EditUser(ApplicationUser u)
        {
            throw new NotImplementedException();
        }

        public List<ApplicationUser> GetAllReps()
        {
            return users;
        }

        
        public ApplicationUser GetUserByUserName(string uName)
        {

            ApplicationUser testUser = users.First( u => u.UserName == uName);
            return testUser;
        }

		public List<Customer> GetRepCustomerList(ApplicationUser u)
        {

			return (from a in u.Customers
					select a).ToList();
                
        }

		public List<Sale> GetRepSalesList(ApplicationUser u)
        {
            
			return (from s in u.Sales
                    select s).ToList();

        }

		public List<Sale> GetRepSalesByDateList(ApplicationUser u, DateTime day)
        {
            
            return (from s in u.Sales
			        where s.SaleDate.Day.Equals(day.Day)
                    select s).ToList();

        }
        
	}
}
