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
    [RoutePrefix("api/TransactionService")]
    public class TransactionServicesController : ApiController
    {
        private ApiDbContext db = new ApiDbContext();

        [Route("GetTransactions")]
        public Task<List<Transaction>> GetTransactions()
        {
            var accountdata = GetTransactions();

            return accountdata;
        }

        [Route("GetTransactions/json")]
        public async Task<IHttpActionResult> GetAccountAsJson()
        {
            var serializerSettings = new JsonSerializerSettings { Formatting = Formatting.Indented };
            var data = await db.GetTransactions();
            return Json(data, serializerSettings);
        }

        [Route("GetTransactionDetails")]
        public Task<List<Transaction>> GetTransactionDetails(int accountId)
        {
            var transactiondata = GetTransactionDetails(accountId);

            return transactiondata;
        }

        [Route("GetTransactionDetails/json")]
        public async Task<IHttpActionResult> GetTransactionDetailsAsJson(int accountId)
        {
            var serializerSettings = new JsonSerializerSettings { Formatting = Formatting.Indented };
            var data = await db.GetAccountDetails(accountId);
            return Json(data, serializerSettings);
        }

    }
}
