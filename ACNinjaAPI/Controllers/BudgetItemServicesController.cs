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
    /// Budget item service API
    /// </summary>
    [RoutePrefix("api/BudgetItemService")]
    public class BudgetItemServiceController : ApiController
    {
        private ApiDbContext db = new ApiDbContext();

        /// <summary>
        /// Runs the Sql query that returns all budget items
        /// </summary>
        /// <remarks>
        /// Current version of this API Returns all Budget Items found in Budget items Table
        /// </remarks>
        /// <returns>GetAllbudgetitems</returns>
        [Route("GetAllBudgetItems")]
        public Task<List<BudgetItem>> GeAlltBudgetItems()
        {
            return db.GetBudgetItems();
        }

        /// <summary>
        /// Runs the Sql Query that returns All Budget Items and represents them as a Json call
        /// </summary>
        /// <remarks>
        /// Current version of this API Returns all Budget Items found in Budget items Table as a Json  output
        /// </remarks>
        /// <returns>GetAllBUdgetItemsasJson</returns>
        [Route("GetAllBudgetItems/json")]
        public async Task<IHttpActionResult> GetAllBudgetItemsAsJson()
        {
            var serializerSettings = new JsonSerializerSettings { Formatting = Formatting.Indented };
            var data = await db.GetBudgetItems();
            return Json(data, serializerSettings);
        }

        /// <summary>
        /// Runs Sql query that returns a budget item based off a particular Id
        /// </summary>
        /// <remarks>
        /// Current version of this API Returns a Budget Item associated wiith a particular id
        /// </remarks>
        /// <param name="budgetItemId"></param>
        /// <returns></returns>
        [Route("GetBudetItemDetails")]
        public Task<BudgetItem> GetBudgetItemDetails(int budgetItemId)
        {
            var itemDetailsData = db.GetBudgetItemDetails(budgetItemId);

            return itemDetailsData;
        }

        /// <summary>
        /// Sql query that returns a budget item based off a particular Id in Json format
        /// </summary>
        /// <remarks>
        /// Current version of this API Returns a Budget Item associated wiith a particular id in Jason format
        /// </remarks>
        /// <param name="budgetItemId"></param>
        /// <returns></returns>
        [Route("GetBudetItemDetails/json")]
        public async Task<IHttpActionResult> GetBudgetItemDetailsAsJson(int budgetItemId)
        {
            var serializerSettings = new JsonSerializerSettings { Formatting = Formatting.Indented };
            var data = await db.GetBudgetItemDetails(budgetItemId);
            return Json(data, serializerSettings);
        }

    }
}
