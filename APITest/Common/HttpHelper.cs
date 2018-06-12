using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace HX.Common
{
    public class HttpHelper
    {
        public static async Task<string> Post(string url, string content)
        {
            string result = string.Empty;
            try
            {
                HttpClient httpClient = new HttpClient();
                HttpResponseMessage response = await httpClient.PostAsync(url, new StringContent(content));

                Stream myResponseStream =await response.Content.ReadAsStreamAsync();
                StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("gbk"));
                result = myStreamReader.ReadToEnd();
                response.EnsureSuccessStatusCode();
              
            }
            catch (Exception ex)
            {
                
                return ex.ToString();
            }
            return result;
        }
        public static string Post2(string url, string content)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "post";
            request.ContentType = "text/xml;charset=UTF-8";
            string paraUrlCoded = content;
            byte[] payload;
            payload = Encoding.UTF8.GetBytes(paraUrlCoded);
            request.ContentLength = payload.Length;
            Stream writer = request.GetRequestStream();
            writer.Write(payload, 0, payload.Length);
            writer.Close();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("gbk"));
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();

            return retString;
        }
    }
}
