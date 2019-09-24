using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using ACNinjaAPI.Models;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace ACNinjaAPI.Controllers
{
    /// <summary>
    /// Primary API to retrieve Household data
    /// </summary>
    [RoutePrefix("api/Householdservice")]
    public class HouseholdServiceController : ApiController
    {
        private ApiDbContext db = new ApiDbContext();
        /// <summary>
        /// Runs SQL query that returns all houshold data
        /// </summary>
        /// <remarks>
        /// Current version of API retruns all household data held in table
        /// </remarks>
        /// <returns>return db.GetAllHouseholdData();</returns>
        [Route("GetHouseholds")]
        public Task<List<Household>> GetHouseholds()
        {         
            return db.GetAllHouseholdData();
        }

        /// <summary>
        /// Runs SQL query that returns all houshold data in Json Format
        /// </summary>
        /// <remarks>
        /// Current version of API retruns all household data held in table in Json format
        /// </remarks>
        /// <returns>GetAllhouseholdData</returns>
        [Route("GetHouseholds/json")]
        public async Task<IHttpActionResult> GetHouseholdsAsJson()
        {
            var serializerSettings = new JsonSerializerSettings { Formatting = Formatting.Indented };
            var data = await db.GetAllHouseholdData();
            return Json(data, serializerSettings);
        }

    }
}
