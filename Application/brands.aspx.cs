using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace Application
{
    public partial class brands : System.Web.UI.Page
    {
        Service.Service service = new Service.Service();
        protected void Page_Load(object sender, EventArgs e)
        {
            var data = service.getAllBrands();
            grdBrandData.DataSource = data;
            grdBrandData.DataBind();
        }

        protected void btnLoadBrands_Click(object sender, EventArgs e)
        {
            var data = service.getAllBrands();
            grdBrandData.DataSource = data;
            grdBrandData.DataBind();
        }

        protected void btnAddBrand_Click(object sender, EventArgs e)
        {
            //executes the query using the variable data
            service.newBrand(txtBrandName.Text);
            //refreshes the datatable
            var data = service.getAllBrands();
            grdBrandData.DataSource = data;
            grdBrandData.DataBind();
        }

        protected void btnEditBrand_Click(object sender, EventArgs e)
        {
            Response.Redirect($"editbrand.aspx?id={txtBrandIDEdit.Text}");
        }

        protected void btnSaveBrandReport_Click(object sender, EventArgs e)
        {
            //save related comments located at tools
            string path = MapPath("Report.csv");
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            foreach (GridViewRow row in grdBrandData.Rows)
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
            Response.Redirect("help.aspx?help=brands");
        }
    }
}