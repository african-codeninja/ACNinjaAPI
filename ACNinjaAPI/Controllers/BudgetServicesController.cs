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
    [RoutePrefix("api/BudgetService")]
    public class BudgetServiceController : ApiController
    {
        private ApiDbContext db = new ApiDbContext();

        [Route("GetBudgets")]
        public Task<List<Budget>> GetBudgets()
        {
            return db.GetBudgets();
        }

        [Route("GetBudget/json")]
        public async Task<IHttpActionResult> GetBudgetItemsAsJson()
        {
            var serializerSettings = new JsonSerializerSettings { Formatting = Formatting.Indented };
            var data = await db.GetBudgetItems();
            return Json(data, serializerSettings);
        }

        [Route("GetBudetDetails")]
        public Task<List<Budget>> GetBudgetDetails(int accountId)
        {
            var BudgetDetailsData = GetBudgetDetails(accountId);

            return BudgetDetailsData;
        }

        [Route("GetBudetItemDetails/json")]
        public async Task<IHttpActionResult> GetBudgetDetailsAsJson(int accountId)
        {
            var serializerSettings = new JsonSerializerSettings { Formatting = Formatting.Indented };
            var data = await db.GetBudgetDetails(accountId);
            return Json(data, serializerSettings);
        }

    }
}
