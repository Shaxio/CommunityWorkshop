using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
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
            grdCommentData.DataSource = gvCData;
            grdCommentData.DataBind();

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
            var data = Service.getActiveByBrand(Convert.ToInt32(ddlBrands.SelectedValue));
            grdToolData.DataSource = data;
            grdToolData.DataBind();
        }

        protected void btnInactiveByBrand_Click(object sender, EventArgs e)
        {
            var data = Service.getInActiveByBrand(Convert.ToInt32(ddlBrands.SelectedValue));
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
            Response.Redirect($"edittool.aspx?id={txtToolIDEdit.Text}");
        }

        protected void btnSaveToolReport_Click(object sender, EventArgs e)
        {
            //register the path of the server side csv
            string path = MapPath("Report.csv");
            //If the file already exists yeet it
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            foreach (GridViewRow row in grdToolData.Rows)
            {
                int i = 0;
                string data = "";
                try
                {
                    //loops each cell that is not null
                    while (row.Cells[i].Text != null)
                    {
                        //sets the data from the cells into the string data seperated by ,
                        data = data + "\"" + row.Cells[i].Text + "\"" + ",";
                        i++;
                    }
                }
                //if there is no data in the cell
                catch
                {
                    //removes the last comma from the data string
                    data = data.Remove(data.Length - 1);
                    //writes the data to the csv
                    using (var write = new StreamWriter(path, true))
                    {
                        write.WriteLine(data);
                    }
                }
            }
            //sends the file to the client
            Response.ContentType = "Application/csv";
            Response.AppendHeader("content-disposition", "attachment; filename=Report.csv");
            Response.TransmitFile(path);
            Response.End();
        }

        protected void btnAllComments_Click(object sender, EventArgs e)
        {
            var data = Service.getAllComments();
            grdCommentData.DataSource = data;
            grdCommentData.DataBind();
        }

        protected void btnCommentByTool_Click(object sender, EventArgs e)
        {
            var data = Service.getCommentsByTool(Convert.ToInt32(txtSearchToolID.Text));
            grdCommentData.DataSource = data;
            grdCommentData.DataBind();
        }

        protected void btnAddComment_Click(object sender, EventArgs e)
        {
            var success = Service.newComment(Convert.ToInt32(txtToolID.Text), txtComment.Text);
            var data = Service.getAllComments();
            grdCommentData.DataSource = data;
            grdCommentData.DataBind();
        }

        protected void btnEditComment_Click(object sender, EventArgs e)
        {
            Response.Redirect($"editcomment.aspx?id={txtCommentIDEdit.Text}");

        }

        protected void btnSaveCommentReport_Click(object sender, EventArgs e)
        {
            string path = MapPath("Report.csv");
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            foreach (GridViewRow row in grdCommentData.Rows)
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
                    using (var write = new StreamWriter(path, true))
                    {
                        write.WriteLine(data);
                    }
                }
            }
            Response.ContentType = "Application/csv";
            Response.AppendHeader("content-disposition", "attachment; filename=Report.csv");
            Response.TransmitFile(path);
            Response.End();
        }

        protected void btnHelp_Click(object sender, EventArgs e)
        {
            Response.Redirect("help.aspx?help=tools");
        }
    }
}