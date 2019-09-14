using System;

namespace PizzaShopApp.Common.UI.MasterPage
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] == null)
            {
                Response.Redirect("~/Common/UI/LoginPage.aspx");
            }

        }


        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session["email"] = null;
            Response.Cookies["admin"].Value = null;
            Response.Cookies["admin"].Expires = DateTime.Now.AddMinutes(-30);

            Response.Redirect("/Common/UI/LoginPage.aspx");
        }
    }
}