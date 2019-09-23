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
    /// <remarks>
    ///// The current version of this API returns the subset of available Househols feilds mapped to an awaiting Household
    /// </remarks>
    /// </summary>
    [RoutePrefix("api/BankAccountService")]
    public class BankAccountServiceController : ApiController
    {
        private ApiDbContext db = new ApiDbContext();

        /// <summary>
        /// Runs the query to gather bank account data
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        [Route("GetBankAccounts")]
        public Task<List<BankAccount>> GetAccount(int accountId)
        {
            var accountdata = GetAccount(accountId);

            return accountdata;
        }

        /// <summary>
        /// Runs the query to gather bank account data in a Json sequence
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        [Route("GetBankAccounts/json")]
        public async Task<IHttpActionResult> GetAccountAsJson(int accountId)
        {
            var serializerSettings = new JsonSerializerSettings { Formatting = Formatting.Indented };
            var data = await db.GetAccount(accountId);
            return Json(data, serializerSettings);
        }

        /// <summary>
        /// Runs the query to gather bank account details data
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns>Bank Account data</returns>
        [Route("GetBankAccountDetails")]
        public Task<List<BankAccount>> GetAccountDetails(int accountId)
        {
            var bankaccountdata = GetAccountDetails(accountId);

            return bankaccountdata;
        }

        /// <summary>
        /// Runs the query to gather bank account details data in json format
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        [Route("GetBankAccountDetails/json")]
        public async Task<IHttpActionResult> GetAccountDetailsAsJson(int accountId)
        {
            var serializerSettings = new JsonSerializerSettings { Formatting = Formatting.Indented };
            var data = await db.GetAccountDetails(accountId);
            return Json(data, serializerSettings);
        }

    }
}
