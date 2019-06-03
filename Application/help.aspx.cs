using System;
namespace Application
{
    public partial class help : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // stores the string that determines the image to load
            var imageToLoad = Request.QueryString["help"];
            imgHelp.ImageUrl = $"Resources/Help/{imageToLoad}.png";
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            var returnURL = Request.QueryString["help"];
            Response.Redirect($"{returnURL}.aspx");
        }
    }
}