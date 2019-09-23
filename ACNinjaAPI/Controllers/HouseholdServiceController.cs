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
    /// Another comments
    /// </summary>
    [RoutePrefix("api/Householdservice")]
    public class HouseholdServiceController : ApiController
    {
        /// <summary>
        /// This method generates all Households table data
        /// </summary>
        private ApiDbContext db = new ApiDbContext();

        [Route("GetHouseholds")]
        public Task<List<Household>> GetHouseholds()
        {         
            return db.GetAllHouseholdData();
        }

        [Route("GetHouseholds/json")]
        public async Task<IHttpActionResult> GetHouseholdsAsJson()
        {
            var serializerSettings = new JsonSerializerSettings { Formatting = Formatting.Indented };
            var data = await db.GetAllHouseholdData();
            return Json(data, serializerSettings);
        }

    }
}
