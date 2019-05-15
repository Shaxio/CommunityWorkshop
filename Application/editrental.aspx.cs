using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Application
{
    public partial class editrental : System.Web.UI.Page
    {
        Service.Service service = new Service.Service();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var dataUsers = service.getAllUsers();
                var dataTools = service.getAllTools();
                ddlTools.DataSource = dataTools;
                ddlUser.DataSource = dataUsers;
                ddlTools.DataTextField = "ToolName";
                ddlUser.DataTextField = "RentersName";
                ddlTools.DataValueField = "ToolID";
                ddlUser.DataValueField = "UserID";
                ddlTools.DataBind();
                ddlUser.DataBind();
                var data = service.getRentalByID(Convert.ToInt32(Request.QueryString["id"]));
                if (data.Length > 0)
                {
                    //sets fields on the page to the result of data
                    lblID.Text = "Editing entry: " + data[0].RentalID;
                    ddlTools.SelectedValue = data[0].ToolID.ToString();
                    ddlUser.SelectedValue = data[0].UserID.ToString();
                    txtRented.Text = data[0].RentalDate.ToString("yyyy-MM-dd hh:mm:ss");
                    txtReturned.Text = data[0].RentalReturn.ToString("yyyy-MM-dd hh:mm:ss");
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}