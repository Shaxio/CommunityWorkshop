using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Drawing;

namespace Application
{
    public partial class rentals : System.Web.UI.Page
    {
        Service.Service service = new Service.Service();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var dataUsers = service.getAllUsers();
                var dataTools = service.getAllTools();
                ddlTool.DataSource = dataTools;
                ddlTools.DataSource = dataTools;
                ddlUser.DataSource = dataUsers;
                ddlUsers.DataSource = dataUsers;
                ddlTool.DataTextField = "ToolName";
                ddlTools.DataTextField = "ToolName";
                ddlUser.DataTextField = "RentersName";
                ddlUsers.DataTextField = "RentersName";
                ddlTools.DataValueField = "ToolID";
                ddlTool.DataValueField = "ToolID";
                ddlUser.DataValueField = "UserID";
                ddlUsers.DataValueField = "UserID";
                ddlTool.DataBind();
                ddlTools.DataBind();
                ddlUser.DataBind();
                ddlUsers.DataBind();

                var data = service.getAllRentals();
                grdRenterData.DataSource = data;
                grdRenterData.DataBind();
            }
        }

        protected void btnLoadRentals_Click(object sender, EventArgs e)
        {
              var data = service.getAllRentals();
           
             grdRenterData.DataSource = data;
             grdRenterData.DataBind();
        }

        protected void btnSearchByToolID_Click(object sender, EventArgs e)
        { 
            var data = service.getRentalByTool(Convert.ToInt32(ddlTool.SelectedValue));
            grdRenterData.DataSource = data;
            grdRenterData.DataBind();
        }

        protected void btnSearchUserName_Click(object sender, EventArgs e)
        {
            var data = service.getRentalByUser(Convert.ToInt32(ddlUser.SelectedValue));
            grdRenterData.DataSource = data;
            grdRenterData.DataBind();
        }

        protected void btnNewRental_Click(object sender, EventArgs e)
        {
            //stores the current daytime on the host machine in a specific format
            string datenow = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            var success = service.newRental(Convert.ToInt32(ddlTools.SelectedValue), Convert.ToInt32(ddlUsers.SelectedValue), datenow);
            var data = service.getAllRentals();
            grdRenterData.DataSource = data;
            grdRenterData.DataBind();
        }

        protected void btnRentalReturn_Click(object sender, EventArgs e)
        {
            try
            {
                string datenow = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                var success = service.returnRental(Convert.ToInt32(txtReturnID.Text), datenow);
                var data = service.getAllRentals();
                grdRenterData.DataSource = data;
                grdRenterData.DataBind();
                lblError.Text = "Date and time autofilled on button press";
                lblError.ForeColor = Color.Black;
            }
            catch
            {
                lblError.Text="Error! Did you enter an ID?";
                lblError.ForeColor = Color.Red;
            }
        }

        protected void btnEditRental_Click(object sender, EventArgs e)
        {
            Response.Redirect($"editrental.aspx?id={txtRentalIDEdit.Text}");
        }

        protected void btnSaveRentalsReport_Click(object sender, EventArgs e)
        {
            string path = MapPath("Report.csv");
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            foreach (GridViewRow row in grdRenterData.Rows)
            {
                int i = 0;
                string data = "";
                try
                {
                    while (row.Cells[i].Text != null)
                    {
                        data = data + "\"" + row.Cells[i].Text + "\"" + ",";
                        i++;
                    }
                }
                catch
                {
                    data = data.Remove(data.Length - 1);
                    using (var tw = new StreamWriter(path, true))
                    {
                        tw.WriteLine(data);
                    }
                }
            }
            Response.ContentType = "Application/csv";
            Response.AppendHeader("content-disposition",
                    "attachment; filename=Report.csv");
            Response.TransmitFile(path);
            Response.End();
        }

        protected void btnHelp_Click(object sender, EventArgs e)
        {
            Response.Redirect("help.aspx?help=rentals");
        }
    }
}