using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace APITest2.Controllers
{
    public class Test2Controller1 : ApiController
    {
        
        [HttpPost]
        public async Task<string> TestResult()
        {
            string result = "456123456";
            string RequestParam = Request.Content.ReadAsStringAsync().Result;
          
            return result;
        }
    }
}