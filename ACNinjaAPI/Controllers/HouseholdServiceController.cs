using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using ACNinjaAPI.Models;
using Newtonsoft.Json;

namespace ACNinjaAPI.Controllers
{
    [RoutePrefix("api/Householdservice")]
    public class HouseholdServiceController : ApiController
    {
        private ApiDbContext db = new ApiDbContext();

        [Route("GetHousehold")]
        public async Task<List<Household>> GetHouseholds()
        {
            return await db.GetAllHouseholdData();
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
