using HX.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace HX
{
    class Program
    {
        static void Main(string[] args)
        {

            var obj=  GetResponseStr2();


          //  XmlDocument xmlDoc = new XmlDocument();
          //  var kkk = Strxml.GetXML();
          //  xmlDoc.LoadXml(kkk);
          //  XmlNode oldChild = xmlDoc.SelectSingleNode("BookStore/Book/Name");
          //var s1=  oldChild.InnerText;
          //  //取指定的结点的集合
          //              XmlNodeList nodes = xmlDoc.SelectNodes("BookStore/Book/Name");
          //  foreach (var item in nodes)
          //  {
          //      var dd = ((XmlNode)item).InnerText;
          //      var te4 = dd;
          //  }
            //Console.WriteLine(obj.);
            Console.Read();
        }

        public static object GetResponseStr()
        {

            StringBuilder sbstr = new StringBuilder();
            sbstr.Append(@"<?xml version=""1.0"" encoding=""utf-8""?><Agw>  <Head direction = ""request""> ");
            var entityuser = new
            {
                transCode = "DSEC0001",
                reqSeriaNo = "20002017082900000001",
                tradeTime = "20170829121212",
                platformCode = "2000"
            };
            var dds = entityuser.ToXml();
            var ddsstr = dds.ToString().Replace("</object>", "</Head>");
            ddsstr = ddsstr.Remove(0, 8);
            sbstr.Append(ddsstr);
            var entityuser2 = new
            {
                bindCardNo="沈金华",
                idNo = "510923198806204126",
                idType = "100",
                userName = "沈金华",
                userMobile = "15928868117",
                certimageface = "第三方提现",
                certimageback = "1",
                merId = "1234567890987654321"
            };
            var dds2 = entityuser2.ToXml("Body");
            sbstr.Append(dds2.ToString());
            sbstr.Append("</Agw>");
            string url = "http://113.98.254.245:8080/B2BClient/http/MerchantRequestProcees";
            var test1 = sbstr.ToString();
            var res = HttpHelper.Post2(url, test1);

            var dd = Deserialize(typeof(CPMB2B), res);
            return new object();
        }
        public static async Task<object> GetResponseStr2() {

            StringBuilder sbstr = new StringBuilder();
            sbstr.Append(@"<?xml version=""1.0"" encoding=""utf-8""?><Agw>  <Head direction = ""request""> ");
            var entityuser = new
            {
                transCode = "DSEC0001",
                reqSeriaNo = "20002017082900000001",
                tradeTime = "20170829121212",
                tradeDescription = "第三方提现",
                channel = 20,
                aacaddr = "D506DD06-9E9A-4F82-A07F-4FDB043763E6",
                netaddr = "netaddr",
                platformCode = "2000"
            };
           var dds= entityuser.ToXml();
            var ddsstr= dds.ToString().Replace("</object>", "</Head>");
            ddsstr=ddsstr.Remove(0,8);
            sbstr.Append(ddsstr);
            var entityuser2 = new
            {
                accountNo = "14050000000383331",
                cardNo = "6217921787498123",
                transAmt = "100",
                custName = "牛秀",
                summary = "第三方提现",
                isCheckPwd = "1",
                transPwd = "1234567890987654321"
            };
            var dds2 = entityuser2.ToXml("Body");
            sbstr.Append(dds2.ToString());
            sbstr.Append("</Agw>");

            var temp = new Agw
            {
                Head = new Head
                {
                    Direction = "request",
                    TransCode = "DSEC0001",
                    ReqSeriaNo = "20002017082900000001",
                    TradeTime = "20170829121212",
                    TradeDescription = "第三方提现",
                    Channel = 20,
                    Macaddr = "D506DD06-9E9A-4F82-A07F-4FDB043763E6",
                    Netaddr = "netaddr",
                    PlatformCode = "2000"
                },
                Body = new Body
                {
                    AccountNo = "14050000000383331",
                    CardNo = "6217921787498123",
                    TransAmt = "100",
                    CustName = "牛秀",
                    Summary = "第三方提现",
                    IsCheckPwd = "1",
                    TransPwd = "1234567890987654321"
                }
            };
            var result = Serializer(typeof(Agw), temp);
            string url = "http://113.98.254.245:8080/B2BClient/http/MerchantRequestProcees";
            var test1 = sbstr.ToString();
            var res = await HttpHelper.Post(url, test1);
            //var res2= HttpHelper.Post2(url, result);

            if (result==test1)
            {
                var ss = "sdfsdf";
                var sswe = "ssd34534";
            }
            //var res2 = UTF8ToGbk(res);
        // var dd=   Deserialize(typeof(CPMB2B), res);
            return new object();
        }
       public static string UTF8ToGbk(string str)
        {
            string gb2312info = string.Empty;

            Encoding utf8 = Encoding.UTF8;
            Encoding gb2312 = Encoding.GetEncoding("gbk");

            byte[] buffer = utf8.GetBytes(str);
            byte[] asciiBytes = Encoding.Convert(utf8, gb2312, buffer);
            char[] asciiChars = new char[gb2312.GetCharCount(asciiBytes, 0, asciiBytes.Length)];
            gb2312.GetChars(asciiBytes, 0, asciiBytes.Length, asciiChars, 0);
            gb2312info = new string(asciiChars);
            return gb2312info;

        }
      static  string UTF8ToGb2312(string str)
        {
            string gb2312info = string.Empty;

            Encoding utf8 = Encoding.UTF8;
            Encoding gb2312 = Encoding.GetEncoding("gbk");

            byte[] unicodeBytes = utf8.GetBytes(str);

            byte[] asciiBytes = Encoding.Convert(utf8, gb2312, unicodeBytes);



            char[] asciiChars = new char[gb2312.GetCharCount(asciiBytes, 0, asciiBytes.Length)];
            gb2312.GetChars(asciiBytes, 0, asciiBytes.Length, asciiChars, 0);
            gb2312info = new string(asciiChars);
            return gb2312info;

        }
        public static string Serializer(Type type, object obj)
        {
            MemoryStream Stream = new MemoryStream();
            //添加utf-8编码
            StreamWriter textWriter = new StreamWriter(Stream, Encoding.GetEncoding("utf-8"));
            XmlSerializer xml = new XmlSerializer(type);
            //去掉要结点的 xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" 属性
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces(new XmlQualifiedName[]
            {
                new XmlQualifiedName(string.Empty, string.Empty)
            });
            //序列化对象  
            //xml.Serialize(Stream, obj);
            xml.Serialize(textWriter, obj, namespaces);
            Stream.Position = 0;
            StreamReader sr = new StreamReader(Stream);
            string str = sr.ReadToEnd();

            sr.Dispose();
            Stream.Dispose();

            return str;
        }
        ///<summary>  
        ///反序列化  
        ///</summary>  
        ///<param name="type">类型</param>  
        ///<param name="xml">XML字符串</param>  
        ///<returns></returns>  
        public static object Deserialize(Type type, string xml)
        {
            //xml=Encoding.
            try
            {
                StringReader sr = new StringReader(xml);
                XmlSerializer xmldes = new XmlSerializer(type);
                object xx = xmldes.Deserialize(sr);
                string wer = "sdfsdf";
                sr.Dispose();
                return xx;
            }
            catch (Exception ex)
            {

                string dds = ex.ToString();
                return new object();
            }
           
            
        }
        ///<summary>  
        ///反序列化  
        ///</summary>  
        ///<param name="type"></param>  
        ///<param name="xml"></param>  
        ///<returns></returns>  
        public static object Deserialize(Type type, Stream stream)
        {
            XmlSerializer xmldes = new XmlSerializer(type);
            return xmldes.Deserialize(stream);
        }
    }
    //[XmlRoot("Agw")]
    public class Agw
    {
        [XmlElement("Head")]
        public Head Head { get; set; }
        [XmlElement("Body")]
        public Body Body { get; set; }
    }

    public class Head
    {
        [XmlAttribute("direction")]
        public string Direction { get; set; }
        [XmlElement("transCode")]
        public string TransCode { get; set; }
        [XmlElement("reqSeriaNo")]
        public string ReqSeriaNo { get; set; }
        [XmlElement("tradeTime")]
        public string TradeTime { get; set; }
        [XmlElement("tradeDescription")]
        public string TradeDescription { get; set; }
        [XmlElement("channel")]
        public int Channel { get; set; }
        [XmlElement("macaddr")]
        public string Macaddr { get; set; }
        [XmlElement("netaddr")]
        public string Netaddr { get; set; }
        [XmlElement("platformCode")]
        public string PlatformCode { get; set; }
    }
    public class Body
    {
        [XmlElement("accountNo")]
        public string AccountNo { get; set; }
        [XmlElement("cardNo")]
        public string CardNo { get; set; }
        [XmlElement("transAmt")]
        public string TransAmt { get; set; }
        [XmlElement("custName")]
        public string CustName { get; set; }
        [XmlElement("summary")]
        public string Summary { get; set; }
        [XmlElement("isCheckPwd")]
        public string IsCheckPwd { get; set; }
        [XmlElement("transPwd")]
        public string TransPwd { get; set; }
    }
    public class ResultObject
    {
        public string SignFlag { get; set; }
        public string Message { get; set; }
        public string TransCode { get; set; }
    }
    [XmlRoot("CPMB2B")]
    public class CPMB2B
    {
        [XmlElement("MessageData")]
        public MessageData messageData { get; set; }
    }
    public class MessageData
    {
        
            [XmlElement("Base")]
        public Base zuiba{get;set;}
        [XmlElement("ResHeader")]
        public ResHeader resHeader { get; set; }
        

    }
    public class Base
    {
        [XmlElement("Version")]
        public string version { get; set; }
        [XmlElement("SignFlag")]
        public string signFlag { get; set; }
        [XmlElement("SeverModel")]
        public string severModel { get; set; }
    }
    public class ResHeader
    {
        [XmlElement("TransCodeId")]
        public string transCodeId { get; set; }
        [XmlElement("TransCode")]
        public string transCode { get; set; }
        [XmlElement("Status")]
        public Status2 status { get; set; }
        [XmlElement("DataBody")]
        public DataBody dataBody { get; set; }

    }
    public class Status2
    {
        [XmlElement("Code")]
        public string version { get; set; }
        [XmlElement("Message")]
        public string SignFlag { get; set; }
        [XmlElement("Status")]
        public string SeverModel { get; set; }
    }
    public class DataBody
    {
        [XmlElement("Code2")]
        public string code2 { get; set; }
    }

}
