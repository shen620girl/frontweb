using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HX
{
    class Strxml
    {
        static StringBuilder sb = new StringBuilder();
        public static string GetXML()
        {
            sb.Append(@"<?xml version=""1.0"" encoding=""utf-8""?>");
            sb.Append(@"<BookStore><Book>");
            sb.Append(@"<Name BookName = ""C#""> C#入门</Name>");
            sb.Append(@"<Author Name = ""Martin""> Martin </Author><Date> 2013 - 10 - 11 </Date><Adress> 上海 </Adress>");
            sb.Append(@"<Date> 2013 - 10 - 11 </Date></Book>");
            sb.Append(@"<Book><Name BookName=""WCF"">WCF入门</Name>");
            sb.Append(@"<Adress>北京</Adress><Date>2013-10-11</Date><Author Name=""Mary"">Mary</Author></Book></BookStore>");

            return sb.ToString();
        }
    }

}
