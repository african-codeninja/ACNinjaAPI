using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ACNinjaAPI.Models
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext() : base("ACNPortalAPI") { }  

        public static ApiDbContext Create()
        {
            return new ApiDbContext();
        }

        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<Household> Households { get; set; }
        public DbSet<Budget> MyBudget { get; set; }
        public DbSet<BudgetItem> BudgetItems { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        public async Task<List<Household>> GetAllHouseholdData()
        {
            return await Database.SqlQuery<Household>("Gethousehold").ToListAsync();
        }

        //SQL Get Accounts
        public async Task<BankAccount> GetAccount(int accountId)
        {
            return await Database.SqlQuery<BankAccount>("GetAccountDetail @accountId",
                new SqlParameter("accountId", accountId)).FirstOrDefaultAsync();
        }

        public async Task<BankAccount> GetAccountDetails(int accountId)
        {
            return await Database.SqlQuery<BankAccount>("GetAccountDetail @accountId", 
                new SqlParameter("accountId", accountId)).FirstOrDefaultAsync();
        }
    }
}