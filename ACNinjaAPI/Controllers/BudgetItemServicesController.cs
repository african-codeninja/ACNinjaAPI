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
    [RoutePrefix("api/BudgetItemService")]
    public class BudgetItemServiceController : ApiController
    {
        private ApiDbContext db = new ApiDbContext();

        [Route("GetBudgetItems")]
        public Task<List<BudgetItem>> GetBudgetItems()
        {
            return db.GetBudgetItems();
        }

        [Route("GetBudgetItems/json")]
        public async Task<IHttpActionResult> GetBudgetItemsAsJson()
        {
            var serializerSettings = new JsonSerializerSettings { Formatting = Formatting.Indented };
            var data = await db.GetBudgetItems();
            return Json(data, serializerSettings);
        }

        [Route("GetBudetItemDetails")]
        public Task<List<BudgetItem>> GetBudgetItemDetails(int accountId)
        {
            var itemDetailsData = GetBudgetItemDetails(accountId);

            return itemDetailsData;
        }

        [Route("GetBudetItemDetails/json")]
        public async Task<IHttpActionResult> GetBudgetItemDetailsAsJson(int accountId)
        {
            var serializerSettings = new JsonSerializerSettings { Formatting = Formatting.Indented };
            var data = await db.GetBudgetItemDetails(accountId);
            return Json(data, serializerSettings);
        }

    }
}
