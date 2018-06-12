using HX.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace APITest.BI
{
    public class HXManager
    {
        public static async Task<string> testx(string dd)
        {
            string url = "http://113.98.254.245:8080/B2BClient/http/MerchantRequestProcees";
            
            var res = await HttpHelper.Post(url, dd);
            return res;
        }
    }
}