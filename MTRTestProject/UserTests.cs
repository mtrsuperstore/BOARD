using System;
using Xunit;
using MTRProject.Models;
using System.Collections.Generic;
using MTRProject.Controllers;
using MTRProject.Repositories;
using Microsoft.AspNetCore.Identity;

namespace MTRTestProject
{

    public class UserTests
    {
        // CONSTRUCTOR TESTS 
        [Fact]
        public void UserConstructorTests()
        {
            var u1 = new ApplicationUser();
            u1.FirstName = "Jessica";
            u1.LastName = "Rabbit";
			u1.Email = "Jess@rabbit.com";

            var s1 = new Sale();
            s1.SaleTotal = 100m;
            u1.Sales.Add(s1);

            var s2 = new Sale();
            s1.SaleTotal = 200m;
            u1.Sales.Add(s2);

            var c1 = new Customer();
            c1.DeptName = "Test";
            u1.Customers.Add(c1);

            var c2 = new Customer();
            c2.DeptName = "Second";
            u1.Customers.Add(c2);

            Assert.Equal(u1.FirstName, "Jessica");
            Assert.Equal(2, u1.Sales.Count);
            Assert.Equal(2, u1.Customers.Count);
        }


		FakeApplicationUserRepository repository = new FakeApplicationUserRepository();


        [Fact]
        public void GetUserByUserNameTest()
        {
            Assert.Equal(repository.GetUserByUserName("jessica@mtrsuperstore.com"), repository.users[0]);
        }

        //Left off working on this one 
		[Fact]
        public void GetRepDailySalesTest()
        {
			var u2 = new ApplicationUser();
            u2.FirstName = "Mike";
            u2.LastName = "Modrich";
            u2.Email = "Mike@mtrsuperstore.com";
			u2.UserName = "Mike";
            
            var s3 = new Sale();
            s3.SaleTotal = 100;
			s3.SaleDate =  new DateTime(2018, 01, 01);
            u2.Sales.Add(s3);
            
            var s4 = new Sale();
            s4.SaleTotal = 200;
			s4.SaleDate = new DateTime(2018, 01, 01);
            u2.Sales.Add(s4);

			repository.AddUser(u2);

			//SalesRepsController controller = new SalesRepsController(repository);         
                    
			//var userDailyTotal = controller.GetRepDailySales("Mike", new DateTime(2018/01/01));
            
			//Assert.Equal( )
            

            
        }

        
		[Fact]
        public void GetRepCustomerListTest()
		{
			var r = repository.GetUserByUserName("jessica@mtrsuperstore.com");

			var custList = repository.GetRepCustomerList(r);

			Assert.Equal(2, custList.Count);

            //Assert.Equal(2, u1.Sales.Count);
            //Assert.Equal(2, u1.Customers.Count);
		}

		[Fact]
        public void GetRepSaleListTest()
        {
			var r = repository.GetUserByUserName("Stiffy@mtrsuperstore.com");

            var saleList = repository.GetRepSalesList(r);
            
            Assert.Equal(3, saleList.Count);

            //Assert.Equal(2, u1.Sales.Count);
            //Assert.Equal(2, u1.Customers.Count);
        }

		[Fact]
        public void GetRepSaleByDateListTest()
        {
            var r = repository.GetUserByUserName("Stiffy@mtrsuperstore.com");
			var d = new DateTime(2018, 05, 01);
            
			var saleList = repository.GetRepSalesByDateList(r, d);
            
            Assert.Equal(1, saleList.Count);

            //Assert.Equal(2, u1.Sales.Count);
            //Assert.Equal(2, u1.Customers.Count);
        }

		[Fact]
        public void GetRepWeeklySalesTotalTest()
        {
			var u = new ApplicationUser { UserName = "Test" };
			// NOTE: Since this method tests CURRENT week total, the date entered below must be
            // altered to be TODAY or EARLIER IN THE CURRENT WEEK to be counted.
			var s = new Sale() { SaleTotal = 50, SaleDate = new DateTime(2018, 05, 23) };
			u.Sales.Add(s);
			repository.AddUser(u);
			//SalesRepsController controller = new SalesRepsController(repository);
           

			var user = repository.GetUserByUserName("Test");

			var d = DateTime.Today;
            
			//var saleTotal = controller.GetRepWeeklySalesTotal(user, d);
            
            //Assert.Equal(50, saleTotal);

            //Assert.Equal(2, u1.Sales.Count);
            //Assert.Equal(2, u1.Customers.Count);
        }

		[Fact]
        public void GetRepMonthlylySalesTotalTest()
        {
            var u = new ApplicationUser { UserName = "Test" };
            // NOTE: Since this method tests CURRENT week total, the date entered below must be
            // altered to be TODAY or EARLIER IN THE CURRENT WEEK to be counted.
            var s = new Sale() { SaleTotal = 50, SaleDate = new DateTime(2018, 05, 23) };
			var w = new Sale() { SaleTotal = 100, SaleDate = new DateTime(2018, 05, 23) };
            u.Sales.Add(s);
			u.Sales.Add(w);
            repository.AddUser(u);
            //SalesRepsController controller = new SalesRepsController(repository);


            var user = repository.GetUserByUserName("Test");

            var d = DateTime.Today;

            //var saleTotal = controller.GetRepMonthlySalesTotal(user, d);

            //Assert.Equal(150, saleTotal);

        }

		[Fact]
        public void GetRepYtdTotalTest()
        {
            var u = new ApplicationUser { UserName = "Test" };
            // NOTE: Since this method tests CURRENT week total, the date entered below must be
            // altered to be TODAY or EARLIER IN THE CURRENT WEEK to be counted.
            var s = new Sale() { SaleTotal = 50, SaleDate = new DateTime(2018, 05, 23) };
            var w = new Sale() { SaleTotal = 100, SaleDate = new DateTime(2018, 05, 10) };
			var q = new Sale() { SaleTotal = 150, SaleDate = new DateTime(2018, 04, 23) };
            u.Sales.Add(s);
            u.Sales.Add(w);
			u.Sales.Add(q);
            repository.AddUser(u);
            //SalesRepsController controller = new SalesRepsController(repository);


            var user = repository.GetUserByUserName("Test");

            var d = DateTime.Today;

			//var saleTotal = controller.GetRepYtdSalesTotal(user, d);

            //Assert.Equal(300, saleTotal);
            
        }

		[Fact]
		public void GetRepSalesTotalByDateRangeTest()
		{
			var u = new ApplicationUser { UserName = "Test" };
            // NOTE: Since this method tests CURRENT week total, the date entered below must be
            // altered to be TODAY or EARLIER IN THE CURRENT WEEK to be counted.
            var s = new Sale() { SaleTotal = 50, SaleDate = new DateTime(2018, 05, 23) };
            var w = new Sale() { SaleTotal = 100, SaleDate = new DateTime(2018, 05, 10) };
            var q = new Sale() { SaleTotal = 150, SaleDate = new DateTime(2018, 04, 23) };
			var a = new Sale() { SaleTotal = 200, SaleDate = new DateTime(2018, 03, 23) };
            u.Sales.Add(s);
            u.Sales.Add(w);
            u.Sales.Add(q);
			u.Sales.Add(a);
            repository.AddUser(u);
            //SalesRepsController controller = new SalesRepsController(repository);


            var user = repository.GetUserByUserName("Test");

			var first = new DateTime(2018, 03, 01);
			var last = new DateTime(2018, 05, 11);

			//var saleTotal = controller.GetRepSalesTotalByDateRange(user, first, last);

            //Assert.Equal(450, saleTotal);
		}

		[Fact]
        public void RepLastYearThisMonthTest()
		{
			var u = new ApplicationUser { UserName = "Test" };
            // NOTE: Since this method tests CURRENT week total, the date entered below must be
            // altered to be TODAY or EARLIER IN THE CURRENT WEEK to be counted.
            var s = new Sale() { SaleTotal = 50, SaleDate = new DateTime(2018, 05, 23) };
            var w = new Sale() { SaleTotal = 100, SaleDate = new DateTime(2018, 05, 10) };
            var q = new Sale() { SaleTotal = 150, SaleDate = new DateTime(2018, 04, 23) };
            var a = new Sale() { SaleTotal = 200, SaleDate = new DateTime(2018, 03, 23) };
			var e = new Sale() { SaleTotal = 50, SaleDate = new DateTime(2017, 05, 23) };
            var r = new Sale() { SaleTotal = 100, SaleDate = new DateTime(2017, 05, 10) };
            u.Sales.Add(s);
            u.Sales.Add(w);
            u.Sales.Add(q);
            u.Sales.Add(a);
			u.Sales.Add(e);
            u.Sales.Add(r);
            repository.AddUser(u);
            //SalesRepsController controller = new SalesRepsController(repository);


            var user = repository.GetUserByUserName("Test");

			var day = DateTime.Today;

			//var saleTotal = controller.GetRepLastYearThisMonthSalesTotal(user, day);

            //Assert.Equal(150, saleTotal);
		}

		[Fact]
        public void OrderRepsByLastMonthSalesTest()
		{
			var u = new ApplicationUser { UserName = "Test", IsSalesRep = true };
			var u2 = new ApplicationUser { UserName = "AlCapone" , IsSalesRep = true };
			var u3 = new ApplicationUser { UserName = "WhiteyBulger" , IsSalesRep = true };
            // NOTE: Since this method tests CURRENT week total, the date entered below must be
            // altered to be TODAY or EARLIER IN THE CURRENT WEEK to be counted.
            var s = new Sale() { SaleTotal = 50, SaleDate = new DateTime(2018, 04, 23),  };
            var w = new Sale() { SaleTotal = 50, SaleDate = new DateTime(2018, 04, 10) };
            var q = new Sale() { SaleTotal = 50, SaleDate = new DateTime(2018, 04, 23) };
            var a = new Sale() { SaleTotal = 50, SaleDate = new DateTime(2018, 04, 23) };
            var e = new Sale() { SaleTotal = 50, SaleDate = new DateTime(2018, 04, 23) };
            var r = new Sale() { SaleTotal = 50, SaleDate = new DateTime(2018, 04, 10) };
            u.Sales.Add(s);
            u2.Sales.Add(w);
            u2.Sales.Add(q);
            u3.Sales.Add(a);
            u3.Sales.Add(e);
            u3.Sales.Add(r);
            repository.AddUser(u);
			repository.AddUser(u2);
			repository.AddUser(u3);

            //SalesRepsController controller = new SalesRepsController(repository);

			var day = DateTime.Today;

			//var orderedList = controller.OrderRepsByLastMonthSales(day);

			//Assert.Equal(u3, orderedList[0]);
			//Assert.Equal(u2, orderedList[1]);
			//Assert.Equal(u, orderedList[2]);
                                     
		}

    }
    
}
