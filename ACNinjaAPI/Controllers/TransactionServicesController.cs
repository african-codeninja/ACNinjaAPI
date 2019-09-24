using ACNinjaAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ACNinjaAPI.Controllers
{
    /// <summary>
    /// API built to Run queries on transactions
    /// </summary>
    [RoutePrefix("api/TransactionService")]
    public class TransactionServicesController : ApiController
    {
        private ApiDbContext db = new ApiDbContext();
        /// <summary>
        /// Runs query that returns all data in the transactions table
        /// </summary>
        /// <remarks>
        /// Current version of API returns all transactions as recoreded on the transactions table
        /// </remarks>
        /// <returns></returns>
        [Route("GetTransactions")]
        public Task<List<Transaction>> GetTransactions()
        {
            var accountdata = db.GetTransactions();

            return accountdata;
        }


        /// <summary>
        /// Runs query that returns all data in the transactions table
        /// </summary>
        /// <remarks>
        /// Current version of API returns all transactions as recoreded on the transactions table in Json format
        /// </remarks>
        /// <returns></returns>
        [Route("GetTransactions/json")]
        public async Task<IHttpActionResult> GetAccountAsJson()
        {
            var serializerSettings = new JsonSerializerSettings { Formatting = Formatting.Indented };
            var data = await db.GetTransactions();
            return Json(data, serializerSettings);
        }

        /// <summary>
        /// Runs query that returns a specific transaction based off a partcular Id
        /// </summary>
        /// <remarks>
        /// Current version of API returns a specifictransaction based off a given transaction Id
        /// </remarks>
        /// <param name="transactionId"></param>
        /// <returns></returns>
        [Route("GetTransactionDetails")]
        public Task<Transaction> GetTransactionDetails(int transactionId)
        {
            var transactiondata = db.GetTransactionDetails(transactionId);

            return transactiondata;
        }

        /// <summary>
        /// Runs query that returns a specific transaction based off a partcular Id in Jason format
        /// </summary>
        /// <remarks>
        /// Current version of API returns a specifictransaction based off a given transaction Id in Json format
        /// </remarks>
        /// <param name="transactionId"></param>
        /// <returns></returns>
        [Route("GetTransactionDetails/json")]
        public async Task<IHttpActionResult> GetTransactionDetailsAsJson(int transactionId)
        {
            var serializerSettings = new JsonSerializerSettings { Formatting = Formatting.Indented };
            var data = await db.GetAccountDetails(transactionId);
            return Json(data, serializerSettings);
        }

    }
}
