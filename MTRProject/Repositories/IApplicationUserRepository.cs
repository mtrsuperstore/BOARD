using MTRProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MTRProject.Repositories
{
    public interface IApplicationUserRepository
    {
        //int AddUser(ApplicationUser u);
        int EditUser(ApplicationUser u);
        int DeleteUser(string id);
        List<ApplicationUser> GetAllReps();
        ApplicationUser GetUserByUserName(string uName);
        List<Sale> GetRepSalesList(ApplicationUser user);

        List<Sale> GetRepSalesByDateList(ApplicationUser u, DateTime day);
        //decimal GetRepDailySales(string uName, DateTime day);
        //decimal GetAllRepsDailySales(DateTime day);
    }
}
