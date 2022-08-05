using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SF_Monitor
{
    public partial class deplay2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                //Timer1.Enabled = true;
                //Label8.Text = DateTime.Now.ToLongDateString();
            }

            Label8.Text =System.DateTime.Now.ToLongDateString()+ " "+ System.DateTime.Now.ToString("hh:mm:ss");
        }


    }
}