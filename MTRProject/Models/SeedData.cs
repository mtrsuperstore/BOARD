using Microsoft.Extensions.DependencyInjection;
using MTRProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MTRProject.Models;

namespace MTRProject.Models
{
    public class SeedData
    {
        
        public static void Initialize(IServiceProvider services)
        {
            ApplicationDbContext context = services.GetRequiredService<ApplicationDbContext>();
            context.Database.EnsureCreated();

            
            if (!context.Sale.Any())
            {
                ApplicationUser u1 = new ApplicationUser
                {
                    FirstName = "Cody",
                    LastName = "West",
                    IsSalesRep = true,
                    Email = "cody@mtrsuperstore.com"
                };
                context.Add(u1);
                context.SaveChanges();
                
                Sale sale1 = new Sale
                {
                    SaleTotal = 100,
                    DateEntered = DateTime.Now,
                    SaleDate = DateTime.Now
                };
                context.Sale.Add(sale1);
                u1.Sales.Add(sale1);
                context.SaveChanges();

                Customer customer1 = new Customer
                {
                    FirstName = "John",
                    LastName = "Smith",
                    DeptName = "Eugene/Springfield",
                    Email = "JSmith@Eugenefire.org",
                    Phone = "541-555-1234",
                    Comment = "Local Customer"

                };
                context.Customer.Add(customer1);
                u1.Customers.Add(customer1);
                context.SaveChanges();

                ApplicationUser u2 = new ApplicationUser
                {
                    FirstName = "Jessica",
                    LastName = "Hatch",
                    IsSalesRep = true,
                    Email = "jessica@mtrsuperstore.com"
                };
                //fix me
                context.Add(u2);
                context.SaveChanges();

                Sale sale2 = new Sale
                {
                    SaleTotal = 200,
                    DateEntered = DateTime.Now,
                    SaleDate = DateTime.Now
                };
                context.Sale.Add(sale2);
                u2.Sales.Add(sale2);
                context.SaveChanges();

                Sale sale3 = new Sale
                {
                    SaleTotal = 300,
                    DateEntered = DateTime.Now,
                    SaleDate = DateTime.Now,
                };
                context.Sale.Add(sale3);
                u2.Sales.Add(sale3);
                context.SaveChanges();

                Customer customer2 = new Customer
                {
                    FirstName = "Inspector",
                    LastName = "Gadget",
                    DeptName = "AMR",
                    Email = "IG@AMR.com",
                    Phone = "999-123-4567",
                    Comment = "Not Local Customer"

                };
                context.Customer.Add(customer2);
                u2.Customers.Add(customer2);
                context.SaveChanges();

                ApplicationUser u3 = new ApplicationUser
                {
                    FirstName = "Mikey",
                    LastName = "Coombs",
                    IsSalesRep = true,
                    Email = "mcoombs@mtrsuperstore.com"
                };
                context.Add(u3);
                context.SaveChanges();

                ApplicationUser u4 = new ApplicationUser
                {
                    FirstName = "Brian",
                    LastName = "Stevenson",
                    IsSalesRep = false,
                    Email = "brian@mtrsuperstore.com"
                };

                Vendor vendor1 = new Vendor
                {
                    Name = "McKesson",
                    Phone = "760-111-2222",
                    LoginName = "MTR",
                    LoginPassword = "MTR2018",
                    Comment = ""

                };
                context.Vendor.Add(vendor1);
                context.SaveChanges();

                Vendor vendor2 = new Vendor
                {
                    Name = "Braun and McGaw",
                    Phone = "000-333-4444",
                    LoginName = "MTR",
                    LoginPassword = "MTR2018",
                    Comment = "Solutions"

                };
                context.Vendor.Add(vendor2);
                context.SaveChanges();

                WeeklySaleItem saleItem1 = new WeeklySaleItem
                {
                    ItemNumber = "MTR-1234",
                    ItemName = "Backboard",
                    Cost  = 44.00m,
                    SalePrice = 99.99m,
                    CommissionRate = 15,
                    SaleStart = DateTime.Parse("01/01/2018 11:00"),
                    SaleEnd = DateTime.Parse("01/07/2018 11:00")

                };
                context.WeeklySaleItem.Add(saleItem1);
                context.SaveChanges();

                WeeklySaleItem saleItem2 = new WeeklySaleItem
                {
                    ItemNumber = "84003",
                    ItemName = "Nitrile Gloves",
                    Cost = 32.00m,
                    SalePrice = 65.00m,
                    CommissionRate = 20,
                    SaleStart = DateTime.Parse("01/01/2018 11:00"),
                    SaleEnd = DateTime.Parse("01/07/2018 11:00")

                };
                context.WeeklySaleItem.Add(saleItem2);
                context.SaveChanges();

				WeeklySaleItem saleItem3 = new WeeklySaleItem
                {
                    ItemNumber = "MTR-555555",
                    ItemName = "Stuff",
                    Cost = 44.00m,
                    SalePrice = 99.99m,
                    CommissionRate = 15,
                    SaleStart = DateTime.Parse("05/27/2018 11:00"),
                    SaleEnd = DateTime.Parse("06/02/2018 11:00")

                };
                context.WeeklySaleItem.Add(saleItem3);
                context.SaveChanges();

                WeeklySaleItem saleItem4 = new WeeklySaleItem
                {
                    ItemNumber = "000000",
                    ItemName = "Vinyl Gloves",
                    Cost = 32.00m,
                    SalePrice = 65.00m,
                    CommissionRate = 20,
					SaleStart = DateTime.Parse("05/27/2018 11:00"),
                    SaleEnd = DateTime.Parse("06/02/2018 11:00")

                };
                context.WeeklySaleItem.Add(saleItem4);
                context.SaveChanges();
            }

        }

        }
}
