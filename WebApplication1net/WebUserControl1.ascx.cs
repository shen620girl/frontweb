using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1net
{
    public partial class WebUserControl1 : System.Web.UI.UserControl
    {
        public string showstr { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            //this.showstr = "enengeheng";
           // Response.Write(showstr);
        }
    }
}