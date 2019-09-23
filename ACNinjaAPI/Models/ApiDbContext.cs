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
            return await Database.SqlQuery<Household>("GetHousehold").ToListAsync();
        }
       
        //SQL Get Accounts
        public async Task<BankAccount> GetAccount(int accountId)
        {
            return await Database.SqlQuery<BankAccount>("GetAccounts @householdId",
                new SqlParameter("householdId", accountId)).FirstOrDefaultAsync();
        }

        public async Task<BankAccount> GetAccountDetails(int accountId)
        {
            return await Database.SqlQuery<BankAccount>("GetAccountDetail @accountId", 
                new SqlParameter("accountId", accountId)).FirstOrDefaultAsync();
        }

        public async Task<List<Budget>> GetBudgets()
        {
            return await Database.SqlQuery<Budget>("GetBudgets").ToListAsync();
        }

        public async Task<Budget> GetBudgetDetails(int accountId)
        {
            return await Database.SqlQuery<Budget>("GetAccountDetail @hh1",
                new SqlParameter("hh1", accountId)).FirstOrDefaultAsync();
        }

        public async Task<List<BudgetItem>> GetBudgetItems()
        {
            return await Database.SqlQuery<BudgetItem>("GetBudgetItems").ToListAsync();
        }

        public async Task<BudgetItem> GetBudgetItemDetails(int accountId)
        {
            return await Database.SqlQuery<BudgetItem>("GetAccountDetail @bitemsId",
                new SqlParameter("bitemsId", accountId)).FirstOrDefaultAsync();
        }

        public async Task<List<Transaction>> GetTransactions()
        {
            return await Database.SqlQuery<Transaction>("GetHousehold").ToListAsync();
        }

        public async Task<Transaction> GetTransactionDetails(int accountId)
        {
            return await Database.SqlQuery<Transaction>("GetTransactionDetails @transId",
                new SqlParameter("transId", accountId)).FirstOrDefaultAsync();
        }
    }
}