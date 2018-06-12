using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using MTRProject.Models;
using MTRProject.Controllers;

namespace MTRTestProject
{
    public class CustomerTests
    {
        public List<Customer> customersFromRepo = new List<Customer>();
        public CustomerController controller;

        [Fact]
        public void GetAllCustomersTest()
        {
            var repository = new FakeCustomerRepository();
            customersFromRepo = repository.GetAllCustomers();
            Assert.Equal(100, customersFromRepo[0].CustomerID);
            Assert.Equal(200, customersFromRepo[1].CustomerID);
            Assert.Equal(300, customersFromRepo[2].CustomerID);
        }

        [Fact]
        public void GetCustomerByIDTest()
        {
            var repository = new FakeCustomerRepository();
            Customer output = repository.GetCustomerById(200);
            Assert.Equal("Robin", output.FirstName);
        }
    }
}
 