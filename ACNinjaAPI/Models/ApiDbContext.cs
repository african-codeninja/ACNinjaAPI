using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ACNinjaAPI.Models
{
    /// <summary>
    /// Main Database connector
    /// </summary>
    public class ApiDbContext : DbContext
    {
        /// <summary>
        /// 
        /// </summary>
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

        /// <summary>
        /// Returns a list of all Households in database
        /// </summary>
        /// <returns></returns>
        public async Task<List<Household>> GetAllHouseholdData()
        {
            return await Database.SqlQuery<Household>("GetHousehold").ToListAsync();
        }
       
        /// <summary>
        /// Sql statement that Retrieves all accounts in the Account Table
        /// </summary>
        /// <returns>Gets All account Data</returns>
        public async Task<List<BankAccount>> GetAllAccountData()
        {
            return await Database.SqlQuery<BankAccount>("GetAccounts").ToListAsync();           
        }

        /// <summary>
        /// Runs query that get account
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns>Gets Account data associated with a specific Account Id</returns>
        public async Task<BankAccount> GetAccountDetails(int accountId)
        {
            return await Database.SqlQuery<BankAccount>("GetAccountsDetails @accountId", 
                new SqlParameter("accountId", accountId)).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Returns a list of all Budgets
        /// </summary>
        /// <returns></returns>
        public async Task<List<Budget>> GetBudgets()
        {
            return await Database.SqlQuery<Budget>("GetBudgets").ToListAsync();
        }

        /// <summary>
        /// Return a list of a specific budget associated with an Id
        /// </summary>
        /// <param name="budgetId"></param>
        /// <returns></returns>
        public async Task<Budget> GetBudgetDetails(int budgetId)
        {
            return await Database.SqlQuery<Budget>("GetBudgetDetails @hh1",
                new SqlParameter("hh1", budgetId)).FirstOrDefaultAsync();
        }


        /// <summary>
        /// Returns a list of all Budget items
        /// </summary>
        /// <returns>Getbudgetitems</returns>
        public async Task<List<BudgetItem>> GetBudgetItems()
        {
            return await Database.SqlQuery<BudgetItem>("GetBudgetItems").ToListAsync();
        }

        /// <summary>
        /// return a specific budet item Id 
        /// </summary>
        /// <param name="budgetItemId"></param>
        /// <returns>Getbudgetitemdetails</returns>
        public async Task<BudgetItem> GetBudgetItemDetails(int budgetItemId)
        {
            return await Database.SqlQuery<BudgetItem>("GetBudgetItemDetails @bitemsId",
                new SqlParameter("bitemsId", budgetItemId)).FirstOrDefaultAsync();
        }

        /// <summary>
        /// gets a list of all recorded transaction
        /// </summary>
        /// <returns></returns>
        public async Task<List<Transaction>> GetTransactions()
        {
            return await Database.SqlQuery<Transaction>("GetTransactions").ToListAsync();
        }

        /// <summary>
        /// gets a specific transaction against a specific id
        /// </summary>
        /// <param name="transactionId"></param>
        /// <returns></returns>
        public async Task<Transaction> GetTransactionDetails(int transactionId)
        {
            return await Database.SqlQuery<Transaction>("GetTransactionsDetails @transId",
                new SqlParameter("transId", transactionId)).FirstOrDefaultAsync();
        }
    }
}