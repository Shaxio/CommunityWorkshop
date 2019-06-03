using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Application
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnHelp_Click(object sender, EventArgs e)
        {
            //a redirect to a help page
            Response.Redirect("help.aspx?help=index");
        }
    }
}