using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PizzaShopApp.Common.BLL;
using PizzaShopApp.Common.Models.Data;

namespace PizzaShopApp.Common.UI
{
    public partial class RegistrationPage : System.Web.UI.Page
    {

        private UserManager _userManager = new UserManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMSG.Text = "";
            lblmsgEmail.Text = "";
        }
        private User GetUserData()
        {
            User user = new User();

            user.UserName = txtUserName.Text;
            user.Password = txtPassword.Text;
            user.Address = txtAddress.Text;
            user.Email = txtEmail.Text;
            return user;
        }

        private void ClearUserFields()
        {
            txtUserName.Text = "";
            txtPassword.Text = "";
            txtAddress.Text = "";

        }


        protected void txtEmail_TextChanged(object sender, EventArgs e)
        {
            if (!_userManager.UserUniqueEmailValidation(txtEmail.Text))
            {
                lblmsgEmail.Text = "Email Already Exists";
            }
        }

        protected void RegisterButthon_Click(object sender, EventArgs e)
        {
            
        }

        protected void RegisterButthon_Click1(object sender, EventArgs e)
        {
            User user = GetUserData();

            bool valid = _userManager.ValidateUserData(user);
            bool uniqueEmail = false;

            if (valid)
            {
                uniqueEmail = _userManager.UserUniqueEmailValidation(txtEmail.Text);
            }


            if (!valid)
            {
                lblMSG.Text = "Plesae Provide Name,Password and Address Properly";
            }
            else if (!uniqueEmail)
            {
                lblMSG.Text = "Email Already Exists";
            }

            else if (valid && uniqueEmail)
            {

                lblMSG.Text = _userManager.SaveUser(user);
            }
        }



    }
}