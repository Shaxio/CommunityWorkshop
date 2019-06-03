using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Application
{
    public partial class editcomment : System.Web.UI.Page
    {
        Service.Service service = new Service.Service();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    var data = service.getCommentByID(Convert.ToInt32(Request.QueryString["id"]));
                    if (data.Length > 0)
                    {
                        lblID.Text = "Editing ID: " + data[0].CommentID;
                        txtToolID.Text = data[0].ToolID.ToString();
                        txtComment.Text = data[0].Comment;
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
            service.editComment(Convert.ToInt32(Request.QueryString["id"]), Convert.ToInt32(txtToolID.Text), txtComment.Text);
            Response.Redirect("tools.aspx");
        }
    }
}