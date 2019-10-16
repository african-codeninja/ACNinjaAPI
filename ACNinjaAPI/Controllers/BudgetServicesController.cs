using ACNinjaAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace ACNinjaAPI.Controllers
{
    /// <summary>
    /// Primary API to Retrieve data from the Buget table
    /// </summary>
    [RoutePrefix("api/BudgetService")]
    public class BudgetServiceController : ApiController
    {
        private ApiDbContext db = new ApiDbContext();
        /// <summary>
        /// Run sql query that retrives data for all data in the budgets table
        /// </summary>
        /// <remarks>
        /// Current version of API return all budgets from the budgets table
        /// </remarks>
        /// <returns></returns>
        [Route("GetBudgets")]
        public Task<List<Budget>> GetBudgets()
        {
            return db.GetBudgets();
        }

        /// <summary>
        /// Run sql query that retrives data for all data in the budgets table in Json format
        /// </summary>
        /// <remarks>
        /// Current version of API return all budgets from the budgets table in Json format
        /// </remarks>
        /// <returns></returns>
        [ResponseType(typeof(Budget))]
        [Route("GetBudget/json")]
        public async Task<IHttpActionResult> GetBudgetItemsAsJson()
        {
            var serializerSettings = new JsonSerializerSettings { Formatting = Formatting.Indented };
            var data = await db.GetBudgetItems();
            return Json(data, serializerSettings);
        }

        /// <summary>
        /// Run sql query that retrives data showing a specific record attached to particular Id 
        /// </summary>
        /// <remarks>
        /// Current version of API return a budget record when a particular budget Id is supplied
        /// </remarks>
        /// <param name="budgetId"></param>
        /// <returns>return BudgetDetailsData;</returns>
        [Route("GetBudetDetails")]
        public Task<Budget> GetBudgetDetails(int budgetId)
        {
            var BudgetDetailsData = db.GetBudgetDetails(budgetId);

            return BudgetDetailsData;
        }

        /// <summary>
        /// Run sql query that retrives data showing a specific record attached to particular Id
        /// </summary>
        /// <remarks>
        /// Current version of API return a budget record when a particular budget Id is supplied in Json format
        /// </remarks>
        /// <param name="budgetId"></param>
        /// <returns>return Json(data, serializerSettings);</returns>
        [ResponseType(typeof(Budget))]
        [Route("GetBudetItemDetails/json")]
        public async Task<IHttpActionResult> GetBudgetDetailsAsJson(int budgetId)
        {
            var serializerSettings = new JsonSerializerSettings { Formatting = Formatting.Indented };
            var data = await db.GetBudgetDetails(budgetId);
            return Json(data, serializerSettings);
        }

    }
}
