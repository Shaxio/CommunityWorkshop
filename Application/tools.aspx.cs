using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.IO;

namespace Application
{
    public partial class tools : System.Web.UI.Page
    {
        Service.Service Service = new Service.Service();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                //executes a query and returns the data
                var ddlData = Service.getAllBrands();
                //sets the data sources for all feilds on the page
                ddlBrand.DataSource = ddlData;
                ddlBrand.DataTextField = "Brand";
                ddlBrand.DataValueField = "BrandID";
                ddlBrand.DataBind();
                ddlBrands.DataSource = ddlData;
                ddlBrands.DataTextField = "Brand";
                ddlBrands.DataValueField = "BrandID";
                ddlBrands.DataBind();
            }
            var gvData = Service.getAllTools();
            //binds the data gained above into the grid table
            grdToolData.DataSource = gvData;
            grdToolData.DataBind();

            var gvCData = Service.getAllComments();
            //grdCommentData.DataSource = gvCData;
            //grdCommentData.Databind();

        }

        protected void queryAllTools_Click(object sender, EventArgs e)
        {
            var data = Service.getAllTools();
            grdToolData.DataSource = data;
            grdToolData.DataBind();

        }

        protected void queryAllCheckedOut_Click(object sender, EventArgs e)
        {
            var data = Service.getCheckedOut();
            grdToolData.DataSource = data;
            grdToolData.DataBind();
        }

        protected void queryAllActive_Click(object sender, EventArgs e)
        {
            var data = Service.getActive();
            grdToolData.DataSource = data;
            grdToolData.DataBind();
        }

        protected void queryAllInActive_Click(object sender, EventArgs e)
        {
            var data = Service.getInActive();
            grdToolData.DataSource = data;
            grdToolData.DataBind();
        }

        protected void btnActiveByBrand_Click(object sender, EventArgs e)
        {
            var data = Service.getActiveByBrand(Convert.ToInt32(ddlBrand.SelectedValue));
            grdToolData.DataSource = data;
            grdToolData.DataBind();
        }

        protected void btnInactiveByBrand_Click(object sender, EventArgs e)
        {
            var data = Service.getInActiveByBrand(Convert.ToInt32(ddlBrand.SelectedValue));
            grdToolData.DataSource = data;
            grdToolData.DataBind();
        }

        protected void btnAddNewTool_Click(object sender, EventArgs e)
        {
            var success = Service.newTool(Convert.ToInt32(ddlBrand.SelectedValue), txtName.Text, txtDescription.Text, chkActive.Checked);
            var data = Service.getAllTools();
            grdToolData.DataSource = data;
            grdToolData.DataBind();
        }

        protected void btnEditTool_Click(object sender, EventArgs e)
        {

        }

        protected void btnSaveToolReport_Click(object sender, EventArgs e)
        {

        }
    }
}