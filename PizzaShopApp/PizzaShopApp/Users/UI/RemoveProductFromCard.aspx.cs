using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PizzaShopApp.Common.BLL;

namespace PizzaShopApp.Users.UI
{
    public partial class RemoveProductFromCard : System.Web.UI.Page
    {

        private ProductManager _productManager = new ProductManager();
        protected void Page_Load(object sender, EventArgs e)
        {

            RemoveProduct(Request.QueryString["Id"]);

        }

        private void RemoveProduct(string productIdInString)
        {

            int productId = 0;



            try
            {
                productId = Convert.ToInt32(productIdInString);
            }
            catch (Exception)
            {

                ClientScript.RegisterStartupScript(this.GetType(), "Invalid Product", "<script>Please Enter Valid Product</script>");
            }

            string productItems = Request.Cookies["Items"].Value;
            string[] productItemsArray = productItems.Split('|');
            var productItemDictionary = _productManager.GetProductIdAndQuantity(productItemsArray);
            string result = _productManager.RemoveProductFromCart(productItemDictionary, productId);


            if (Request.Cookies["Items"] != null)
            {
                Response.Cookies["Items"].Value = null;
                Response.Cookies["Items"].Value = result;
                Response.Cookies["Items"].Expires = DateTime.Now.AddDays(1);
            }

            Response.Redirect("CartItems.aspx");

        }
    }
}