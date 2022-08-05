using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.DirectoryServices;
using System.Diagnostics;



namespace LTTS
{
    public partial class _Default : System.Web.UI.Page
    {
        string initLDAPPath = "dc=uniquecoal,dc=com";
        string initLDAPServer = "192.168.1.10";
        string initShortDomainName = "uniquecoal.com";
        string strErrMsg;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            string DomainAndUsername = "";

            string strCommu;

            bool flgLogin = false;

            strCommu = ("LDAP://"

            + (initLDAPServer + ("/" + initLDAPPath)));

            DomainAndUsername = (initShortDomainName + ("\\" + txtuid.Text));

            DirectoryEntry entry = new DirectoryEntry(strCommu, DomainAndUsername, txtpwd.Text);

            object obj;

            try
            {

                obj = entry.NativeObject;

                DirectorySearcher search = new DirectorySearcher(entry);

                SearchResult result;

                search.Filter = ("(SAMAccountName="

                + (txtuid.Text + ")"));

                search.PropertiesToLoad.Add("cn");

                result = search.FindOne();

                if ((result == null))
                {

                    flgLogin = false;
                    strErrMsg = "Please check user/password";

                }

                else
                {

                    flgLogin = true;

                }

            }

            catch (Exception ex)
            {

                flgLogin = false;

                strErrMsg = "Please check user/password";

            }

            if ((flgLogin == true))
            {
                Session["loginname"] = txtuid.Text;
                //Session["timeout"] = DateTime.Now.AddSeconds(20).ToString();
                string p_id = (sender as Button).CommandArgument;
                Session["p_id"] = p_id;
                Response.Write("<script type='text/javascript'> window.open('dashboard.aspx','_parent'); </script>");

            }

            else
            {
                this.lblmsg.Text = strErrMsg;
            }
        }
    }
}