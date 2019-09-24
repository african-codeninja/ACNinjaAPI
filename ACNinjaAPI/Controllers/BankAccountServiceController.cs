using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ACNinjaAPI.Models;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace ACNinjaAPI.Controllers
{
    /// <summary>
    /// Bank Account service API
    /// </summary>
    [RoutePrefix("api/BankAccountService")]
    public class BankAccountServiceController : ApiController
    {
        private ApiDbContext db = new ApiDbContext();

        /// <summary>
        /// Runs the query to gather bank account data
        /// </summary>
        /// <remarks>
        /// The Current Version of this API returns all of the available Household records 
        /// </remarks>
        /// <returns>GetAllAccountsData</returns>
        [Route("GetBankAccounts")]
        public Task<List<BankAccount>> GetBankAccounts()
        {          
            return db.GetAllAccountData();
        }

        /// <summary>
        /// Runs the query to gather bank account data in a Json sequence
        /// </summary>
        /// <remarks>
        /// The Current Version of this API returns a subset of all available Bank account data mapped to a specific ID
        /// </remarks>
        /// <param name="accountId"></param>
        /// <returns>GetAllAccountsData</returns>
        [Route("GetBankAccounts/json")]
        public async Task<IHttpActionResult> GetAccountAsJson(int accountId)
        {
            var serializerSettings = new JsonSerializerSettings { Formatting = Formatting.Indented };
            var data = await db.GetAllAccountData();
            return Json(data, serializerSettings);
        }

        /// <summary>
        /// Runs the query to gather bank account details data
        /// </summary>
        /// <remarks>
        /// The Current Version of this API returns a subset of all available Bank account data mapped to a specific ID
        /// </remarks>
        /// <param name="accountId"></param>
        /// <returns>GetAccountDetails</returns>
        [Route("GetBankAccountDetails")]
        public Task<BankAccount> GetAccountDetails(int accountId)
        {
            var bankaccountdata = db.GetAccountDetails(accountId);

            return bankaccountdata;
        }

        /// <summary>
        /// Runs the query to gather bank account details data in json format
        /// </summary>
        /// <remarks>
        /// The Current Version of this API returns a subset of all available Bank account data mapped to a specific ID
        /// </remarks>
        /// <param name="accountId"></param>
        /// <returns>GetAccountDetails</returns>
        [Route("GetBankAccountDetails/json")]
        public async Task<IHttpActionResult> GetAccountDetailsAsJson(int accountId)
        {
            var serializerSettings = new JsonSerializerSettings { Formatting = Formatting.Indented };
            var data = await db.GetAccountDetails(accountId);
            return Json(data, serializerSettings);
        }

    }
}
