﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Application
{
    public partial class edittool : System.Web.UI.Page
    {
        Service.Service service = new Service.Service();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    var ddlData = service.getAllBrands();
                    ddlBrands.DataSource = ddlData;
                    ddlBrands.DataTextField = "Brand";
                    ddlBrands.DataValueField = "BrandID";
                    ddlBrands.DataBind();

                    var data = service.getToolByID(Convert.ToInt32(Request.QueryString["id"]));
                    //if data is returned
                    if (data.Length > 0)
                    {
                        lblID.Text = "Editing ID: " + data[0].ToolID;
                        ddlBrands.SelectedValue = data[0].BrandID.ToString();
                        txtName.Text = data[0].ToolName;
                        txtDescription.Text = data[0].ToolDescription;
                        chkActive.Checked = data[0].Active;
                    }
                }
                catch
                {
                    Response.Redirect("tools.aspx");
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            service.editTool(Convert.ToInt32(Request.QueryString["id"]), Convert.ToInt32(ddlBrands.SelectedValue), txtName.Text, txtDescription.Text, chkActive.Checked);
            Response.Redirect("tools.aspx");
        }
    }
}