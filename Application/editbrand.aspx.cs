using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Application
{
    public partial class editbrand : System.Web.UI.Page
    {
        Service.Service service = new Service.Service();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var data = service.getBrandByID(Convert.ToInt32(Request.QueryString["id"]));
                //if data is returned
                if (data.Length > 0)
                {
                    lblID.Text = "Editing ID: " + data[0].BrandID;
                    txtBrandName.Text = data[0].Brand;
                }
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            service.editBrand(Convert.ToInt32(Request.QueryString["id"]), txtBrandName.Text);
            Response.Redirect("brands.aspx");
        }
    }
}