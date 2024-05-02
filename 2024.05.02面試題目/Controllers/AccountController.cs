using _2024._05._02面試題目.Models;
using _2024._05._02面試題目.Models.EFModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace _2024._05._02面試題目.Controllers
{
    public class AccountController : Controller
    {

        private readonly BankManagementSystemContext _dbContext;
        public AccountController(BankManagementSystemContext dbContext) 
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {

            // 資料庫包含Owner，查詢NationalId 為 "K18888886" 的資料
            var query = _dbContext.Accounts
                .Include(x=>x.Owner)
                .Where(x => x.Owner.NationalId.Equals("K18888886"))
                .Select(x => new
                {
                    NationalID = x.Owner.NationalId,
                    BranchID = x.BranchId,
                    AcctSerialID = x.AcctSerialId
                })
                .ToList();

            return View(query);
        }
       
    }
}
