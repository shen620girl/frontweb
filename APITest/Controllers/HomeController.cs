using APITest.BI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace APITest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public async Task<string> TestResult()
        {
         var ss=   Request.Params;
          var dd=  Request.Form["ss"];
            string result = "";
            result = await HXManager.testx(dd);
            return result;
        }
    }
}
