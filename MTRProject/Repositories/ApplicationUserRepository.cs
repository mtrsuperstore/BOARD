using Microsoft.AspNetCore.Identity;
using MTRProject.Data;
using MTRProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MTRProject.Repositories
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        
        private ApplicationDbContext context;
        private UserManager<ApplicationUser> userManager;

        public ApplicationUserRepository(ApplicationDbContext ctx, UserManager<ApplicationUser> um)
        {
            context = ctx;
            userManager = um;
        }
        
        

        public int EditUser(ApplicationUser u)
        {
            var userFromDb = GetUserByUserName(u.Id);
            userFromDb.FirstName = u.FirstName;
            userFromDb.LastName = u.LastName;
            userFromDb.UserName = u.UserName;
            userFromDb.Email = u.Email;
            userFromDb.IsSalesRep = u.IsSalesRep;
            //userFromDb.PasswordHash = u.PasswordHash;
            return context.SaveChanges();  
        }

        public int DeleteUser(string id)
		{
            var userFromDb = GetUserByUserName(id);
            context.Remove(userFromDb);
            return context.SaveChanges();
            
        }

        public List<ApplicationUser> GetAllReps()
		{
            return (from u in userManager.Users
                    where u.IsSalesRep
                    select u).ToList();

            //return userManager.Users.ToList();
            //throw new NotImplementedException();
        }

        //Method shouldn't be used. GetSalesByRep() in SaleRepository is the one that works.
        public List<Sale> GetRepSalesList(ApplicationUser user)
        {
            throw new NotImplementedException();
        }


        public ApplicationUser GetUserByUserName(string uID)
		{
			//find the user with matching username
			ApplicationUser user = GetAllReps().First(u => u.Id == uID);

            //return it
			return user;
        }
        
        
		public List<Sale> GetRepSalesByDateList(ApplicationUser u, DateTime day)
        {

            return (from s in u.Sales
                    where s.SaleDate.Day.Equals(day.Day)
                    select s).ToList();

        }
        
	}
}
