using System;
using Xunit;
using MTRProject.Models;
using System.Collections.Generic;
using MTRProject.Controllers;
using MTRProject.Repositories;

namespace MTRTestProject
{
    public class WeeklySaleItemTests
    {

		/********* CONSTRUCTOR TESTS ********/
        [Fact]
        public void SaleItemConstructorTest()
        {
            var s1 = new WeeklySaleItem();
            s1.ItemName = "TestItem";
            s1.ItemNumber = "MTR-12345";
            s1.CommissionRate = 25;
            s1.Cost = 100.00m;
            s1.SalePrice = 145.00m;
            s1.SaleStart = DateTime.Now;
            s1.SaleEnd = new DateTime(2018, 05, 29);

            //s1.SaleEnd = 
            Assert.Equal("MTR-12345", s1.ItemNumber);
            Assert.Equal(100.00m, s1.Cost);
        }

        //Globals
		public List<WeeklySaleItem> itemsFromRepo = new List<WeeklySaleItem>();
		public WeeklySaleItemController controller;


        
        [Fact]
		public void GetAllSaleItemTest()
		{
			var repository = new FakeWeeklySaleItemRepository();
            itemsFromRepo = repository.GetAllSaleItems();
			Assert.Equal("Item 1", itemsFromRepo[0].ItemName);
			Assert.Equal("Item 2", itemsFromRepo[1].ItemName);
			Assert.Equal("Item 3", itemsFromRepo[2].ItemName);
		}

		[Fact]
        public void ShowWeeklySalesTest()
		{
			List<WeeklySaleItem> thisWeeksSales = new List<WeeklySaleItem>();
			var repository = new FakeWeeklySaleItemRepository();
            var day = new DateTime(2018, 05, 31);
			//itemsFromRepo = repository.GetAllSaleItems();
                   

			thisWeeksSales = repository.ShowWeeklySales(day);

			Assert.Equal("Item 1", thisWeeksSales[0].ItemName);
			Assert.Equal("Item 2", thisWeeksSales[1].ItemName);
		}

		[Fact]
        public void GetSaleItemByIdTest()
        {
            var repository = new FakeWeeklySaleItemRepository();
			WeeklySaleItem output = repository.GetSaleItemById(223);

            Assert.Equal("Item 2", output.ItemName);
        }

		[Fact]
        public void GetSaleItemByItemNumTest()
		{
			var repository = new FakeWeeklySaleItemRepository();
			WeeklySaleItem output = repository.GetSaleItemByItemNum("MTR-123");
           
			Assert.Equal("Item 1", output.ItemName);
		}
        
		[Fact]
        public void GetSaleItemByItemNameTest()
        {
            var repository = new FakeWeeklySaleItemRepository();
            WeeklySaleItem output = repository.GetSaleItemByName("Item 1");

			Assert.Equal("MTR-123", output.ItemNumber);
        }

    }
}
