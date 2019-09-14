using System;

namespace PizzaShopApp.Common.UI.MasterPage
{
    public partial class Default : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLout_Click(object sender, EventArgs e)
        {


            if (Request.Cookies["UserId"] != null)
            {
                Response.Cookies["UserId"].Value = null;
                Response.Cookies["UserId"].Expires = DateTime.Now.AddMinutes(-30);

            }
            
            Response.Redirect("/Common/UI/LoginPage.aspx");
        }








    }
}