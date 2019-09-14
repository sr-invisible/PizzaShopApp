using System.Web.UI.WebControls;
using PizzaShopApp.Common.BLL;
using System;

namespace PizzaShopApp.Common.UI
{
    public partial class LoginPage : System.Web.UI.Page
    {

        private UserManager _userManager = new UserManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["emial"] != null)
            {
                Response.Redirect("../../Admin/UI/");
            }
            Master.FindControl("btnLout").Visible = false;
            Master.FindControl("lbtnHome").Visible = false;
            Master.FindControl("lbtnCheckout").Visible = false;
        }

        protected void loginButton_Click1(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string pass = txtPassword.Text.Trim();

            int roll = _userManager.GetUserRollByEmail(email, pass);


            //ClearALLUserCookies();

            if (roll == 1)
            {
                Session["email"] = email;
                if (Request.Cookies["admin"] == null)
                {
                    Response.Cookies["admin"].Value = _userManager.GetUserIdByEmail(email);
                    Response.Cookies["admin"].Expires = DateTime.Now.AddMinutes(30);



                    //Master.FindControl("Login-tag").Visible = false;///it should not work
                    Master.FindControl("btnLout").Visible = true;



                }

                Response.Redirect("~/Admin/UI/AllProducts.aspx");

            }
            else if (roll == 2)
            {

                if (Request.Cookies["UserId"] == null)
                {
                    Response.Cookies["UserId"].Value = _userManager.GetUserIdByEmail(email);
                    Response.Cookies["UserId"].Expires = DateTime.Now.AddMinutes(30);


                    Master.FindControl("btnLout").Visible = true; //ai kahne to true kor si
                    Master.FindControl("lbtnHome").Visible = true;
                    Master.FindControl("lbtnCheckout").Visible = true;
                }

                Response.Redirect("~/Users/UI/ProductList.aspx");

            }
            else
            {
                lblerrorMessage.Text = "Please Register To Login";
            }
        }

        private void ClearALLUserCookies()
        {
            Response.Cookies["UserId"].Value = null;
            Response.Cookies["UserId"].Expires = DateTime.Now.AddMinutes(-30);

            Response.Cookies["admin"].Value = null;
            Response.Cookies["admin"].Expires = DateTime.Now.AddMinutes(-30);

        }
    }
}