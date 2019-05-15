using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace Application
{
    public partial class login : System.Web.UI.Page
    {
        Service.Service service = new Service.Service();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnNewStaff_Click(object sender, EventArgs e)
        {
            Response.Redirect("newstaff.aspx");
        }

        protected void inlog_Authenticate(object sender, AuthenticateEventArgs e)
        {
            //compares the password supplied with the password in the database
            e.Authenticated = service.login(inlog.Password, inlog.UserName);
            if (e.Authenticated == true)
            {
                //authenticate user and redirect to index
                FormsAuthentication.RedirectFromLoginPage(inlog.UserName, inlog.RememberMeSet);
                Response.Redirect("index.aspx");
            }
        }
    }
}