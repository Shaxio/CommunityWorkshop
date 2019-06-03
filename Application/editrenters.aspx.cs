using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Application
{
    public partial class editrenters : System.Web.UI.Page
    {
        Service.Service service = new Service.Service();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    var data = service.getUserByID(Convert.ToInt32(Request.QueryString["id"]));
                    //if data is returned
                    if (data.Length > 0)
                    {
                        lblID.Text = "Editing ID: " + data[0].UserID;
                        txtUserName.Text = data[0].RentersName;
                    }
                }
                catch
                {
                    Response.Redirect($"renters.aspx");
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            service.editRenter(Convert.ToInt32(Request.QueryString["id"]), txtUserName.Text);
            Response.Redirect($"renters.aspx");
        }
    }
}