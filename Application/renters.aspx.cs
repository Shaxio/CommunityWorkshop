using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace Application
{
    public partial class renters : System.Web.UI.Page
    {
        Service.Service service = new Service.Service();

        protected void Page_Load(object sender, EventArgs e)
        {
            var data = service.getAllUsers();
            grdUserData.DataSource = data;
            grdUserData.DataBind();
        }

        protected void btnLoadUsers_Click(object sender, EventArgs e)
        {
            var data = service.getAllUsers();
            grdUserData.DataSource = data;
            grdUserData.DataBind();
        }

        protected void btnAddUser_Click(object sender, EventArgs e)
        {
            var success = service.newRenter(txtUsersName.Text);
            var data = service.getAllUsers();
            grdUserData.DataSource = data;
            grdUserData.DataBind();
        }

        protected void btnEditUser_Click(object sender, EventArgs e)
        {
            Response.Redirect($"editrenters.aspx?id={txtUserIDEdit.Text}");
        }

        protected void btnSaveRenteeReport_Click(object sender, EventArgs e)
        {
            string path = MapPath("Report.csv");
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            foreach (GridViewRow row in grdUserData.Rows)
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
            Response.Redirect("help.aspx?help=renters");
        }
    }
}