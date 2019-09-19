using ACNinjaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ACNinjaAPI.Controllers
{
    public class HomeController : Controller
    {
        public ApiDbContext db = new ApiDbContext();
        public ActionResult Index()
        {
            var households = db.Households.FirstOrDefault();
            ViewBag.Title = "Home Page";

            return View(households);
        }
    }
}
