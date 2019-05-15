using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Application
{
    public partial class newstaff : System.Web.UI.Page
    {
        Service.Service service = new Service.Service();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnNewStaff_Click(object sender, EventArgs e)
        {
            //create a variable initially with a method that will return true or false
            var newstaff = service.createStaffMember(txtUsername.Text, txtPassword.Text);
            if (newstaff == true)
            {
                Response.Redirect("index.aspx");
            }
            else
            {
                txtError.Text = "Error creating new user, username already taken";
                txtError.ForeColor = Color.Red;
            }
        }
    }
}