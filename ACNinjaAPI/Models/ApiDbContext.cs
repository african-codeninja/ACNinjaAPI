using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace ACNinjaAPI.Models
{
    /// <summary>
    /// Custom Db Connector
    /// </summary>
    public class ApiDbContext : DbContext
    {
        /// <summary>
        /// Pass Connection String label to DBContext
        /// </summary>
        public ApiDbContext() : base("ACNPortalAPI") { }  
        /// <summary>
        /// Creat a new DB Context
        /// </summary>
        /// <returns></returns>
        public static ApiDbContext Create()
        {
            return new ApiDbContext();
        }

        /// <summary>
        /// Bank Account DBSet
        /// </summary>
        public DbSet<BankAccount> BankAccounts { get; set; }
        /// <summary>
        /// Households DBset
        /// </summary>
        public DbSet<Household> Households { get; set; }
        /// <summary>
        /// Budgets DBset
        /// </summary>
        public DbSet<Budget> MyBudget { get; set; }
        /// <summary>
        /// BUdget Items DBset
        /// </summary>
        public DbSet<BudgetItem> BudgetItems { get; set; }
        /// <summary>
        /// Transactions DBset
        /// </summary>
        public DbSet<Transaction> Transactions { get; set; }

        /// <summary>
        /// Returns a list of all Households in database
        /// </summary>
        /// <returns></returns>
        public async Task<List<Household>> GetAllHouseholdData()
        {
            return await Database.SqlQuery<Household>("GetHouseHold").ToListAsync();
        }
       
        /// <summary>
        /// Sql statement that Retrieves all accounts in the Account Table
        /// </summary>
        /// <returns>Gets All account Data</returns>
        public async Task<List<BankAccount>> GetAllAccountData()
        {
            return await Database.SqlQuery<BankAccount>("GetAllAccounts").ToListAsync();           
        }

        /// <summary>
        /// Runs query that get account
        /// </summary>
        /// <param name="accountId">Bank Account Id</param>
        /// <returns>Gets Account data associated with a specific Account Id</returns>
        public async Task<BankAccount> GetAccountDetails(int accountId)
        {
            return await Database.SqlQuery<BankAccount>("GetBankAccountDetails @bankId", 
                new SqlParameter("bankId", accountId)).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Returns a list of all Budgets
        /// </summary>
        /// <returns>GetallBudgets</returns>
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
            return await Database.SqlQuery<Budget>("GetBudgetDetails @budgetId",
                new SqlParameter("@budgetId", budgetId)).FirstOrDefaultAsync();
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
            return await Database.SqlQuery<BudgetItem>("GetBudgetItemDetails @budgetItemsId",
                new SqlParameter("budgetItemsId", budgetItemId)).FirstOrDefaultAsync();
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
            return await Database.SqlQuery<Transaction>("GetTransactionDetails @transId",
                new SqlParameter("transId", transactionId)).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Adding a bank acount to the Bank Account table
        /// </summary>
        /// <param name="householdId"></param>
        /// <param name="accountName"></param>
        /// <param name="accountType"></param>
        /// <param name="startingBalance"></param>
        /// <param name="lowBalanceLevel"></param>
        /// <param name="currentBalance"></param>
        /// <returns></returns>
        public async Task<int> AddAccount(
                                        int householdId, 
                                        string accountName, 
                                        int accountType, 
                                        decimal startingBalance, 
                                        decimal lowBalanceLevel, 
                                        decimal currentBalance
                                        )
        {
            return await Database.ExecuteSqlCommandAsync("AddAccount @householdId, @accountName, @accountType, @startingBalance, @lowBalanceLevel, @currentBalance",
                new SqlParameter("householdId", householdId),
                new SqlParameter("accountName", accountName),
                new SqlParameter("accountType", accountType),
                new SqlParameter("startingBalance", startingBalance),
                new SqlParameter("lowBalanceLevel", lowBalanceLevel),
                new SqlParameter("currentBalance", currentBalance)
                );
        }

        /// <summary>
        /// Adding a budget category to the budget table
        /// </summary>
        /// <param name="householdId"></param>
        /// <param name="budgetCategoryName"></param>
        /// <param name="targetAmount"></param>
        /// <returns></returns>
        public async Task<int> AddBudget(
                                        int householdId, 
                                        string budgetCategoryName, 
                                        decimal targetAmount)
        {
            return await Database.ExecuteSqlCommandAsync("AddBudget @householdId, @budgetCategoryName, @targetAmount",
                new SqlParameter("householdId", householdId),
                new SqlParameter("budgetCategoryName", budgetCategoryName),
                new SqlParameter("targetAmount", targetAmount)
                );
        }

        /// <summary>
        /// Adding a Transaction to the transactions table
        /// </summary>
        /// <param name="bankAccountId"></param>
        /// <param name="budgetCategoryItemId"></param>
        /// <param name="createdById"></param>
        /// <param name="amount"></param>
        /// <param name="transactionType"></param>
        /// <param name="payee"></param>
        /// <param name="memo"></param>
        /// <param name="created"></param>
        /// <param name="reconciled"></param>
        /// <param name="reconciledDate"></param>
        /// <returns></returns>
        public async Task<int> AddTransaction(
                                        int bankAccountId, 
                                        int? budgetCategoryItemId, 
                                        string createdById, 
                                        decimal amount, 
                                        int transactionType, 
                                        string payee, 
                                        string memo, 
                                        DateTimeOffset created, 
                                        bool reconciled, 
                                        DateTimeOffset? reconciledDate)
        {
            return await Database.ExecuteSqlCommandAsync("AddTransaction @bankAccountId, @budgetCategoryItemId, @createdById, @amount, @transactionType, @payee, @memo, @created, @reconciled, @reconciledDate",
                new SqlParameter("bankAccountId", bankAccountId),
                new SqlParameter("budgetCategoryItemId", budgetCategoryItemId),
                new SqlParameter("createdById", createdById),
                new SqlParameter("amount", amount),
                new SqlParameter("transactionType", transactionType),
                new SqlParameter("payee", payee),
                new SqlParameter("memo", memo),
                new SqlParameter("created", created),
                new SqlParameter("reconciled", reconciled),
                new SqlParameter("reconciledDate", reconciledDate)
                );
        }

        /// <summary>
        /// Api for Updating account update
        /// </summary>
        /// <param name="id"></param>
        /// <param name="transAmount"></param>
        /// <param name="transType"></param>
        /// <returns></returns>
        public async Task<int> UpdateAccount(
                                            int id, 
                                            decimal transAmount, 
                                            int transType
                                            )
        {
            return await Database.ExecuteSqlCommandAsync("UpdateAccount @id, @transAmount, @transType",
                new SqlParameter("id", id),
                new SqlParameter("transAmount", transAmount),
                new SqlParameter("transType", transType)
                );
        }

        /// <summary>
        /// Api for Deleting a transaction entry
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<int> DeleteTransaction(int id)
        {
            return await Database.ExecuteSqlCommandAsync("DeleteTransaction @id",
                new SqlParameter("id", id)
                );
        }
    }
}