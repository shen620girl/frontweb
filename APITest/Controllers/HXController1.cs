using APITest.BI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace APITest.Controllers
{
    public class HXController: ApiController
    {
      
        [Route("ttttest")]
        [HttpPost]
        public async Task<string> TestResult()
        {
            string result = "";
            string RequestParam = Request.Content.ReadAsStringAsync().Result;
            result = await HXManager.testx("453");
            return result;
        }
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2 hx" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "hx valueva sjh valuescontroller ";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}