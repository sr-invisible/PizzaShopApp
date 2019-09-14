using PizzaShopApp.Common.BLL;
using System;

namespace PizzaShopApp.Common.UI
{
    public partial class ProductDetailsPage : System.Web.UI.Page
    {

        private ProductManager _productManager = new ProductManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadSelectedProduct(Request.QueryString["Id"]);
            ViewState["ProductID"] = Request.QueryString["Id"];
        }

        private void LoadSelectedProduct(string s)
        {
            int productId = 0;
            try
            {
                productId = Convert.ToInt32(s);
            }
            catch (Exception)
            {

                ClientScript.RegisterStartupScript(this.GetType(), "Wrong Product Key", "Please Provide Valid Product Key");
            }


            GridViewSelectedProduct.DataSource = _productManager.GetProductById(productId);
            GridViewSelectedProduct.DataBind();


        }

        protected void btnAddToCart_Click(object sender, EventArgs e)
        {

            



                if (Request.Cookies["Items"] == null)
                {
                    int selectedQuantity = 0;

                    int.TryParse(txtNumberOfProduct.Text, out selectedQuantity);

                    Response.Cookies["Items"].Value = "|" + Request.QueryString["Id"] + "," + selectedQuantity;
                    Response.Cookies["Items"].Expires = DateTime.Now.AddDays(1);
                }
                else
                {
                    int selectedQuantity = 0;

                    int.TryParse(txtNumberOfProduct.Text, out selectedQuantity);


                    Response.Cookies["Items"].Value = Request.Cookies["Items"].Value + "|" + Request.QueryString["Id"] +
                                                      "," + selectedQuantity;
                    Response.Cookies["Items"].Expires = DateTime.Now.AddDays(1);
                }

                ClientScript.RegisterStartupScript(this.GetType(), "Add To Cart Info",
                    "<script> alert('Product Successfully Added To The Cart')</script>");

                // Response.Write(Request.Cookies["Items"].Value);

            
            


        }

        protected void txtNumberOfProduct_TextChanged(object sender, EventArgs e)
        {

            if (_productManager.CheckProductInStock(txtNumberOfProduct.Text, Request.QueryString["Id"]))
            {

                btnAddToCart.Visible = true;
            }
            else
            {
                btnAddToCart.Visible = false;
            }

        }

        protected void btnProductDetails_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProductList.aspx");
        }

        protected void btnCartDetails_Click(object sender, EventArgs e)
        {
            Response.Redirect("CartItems.aspx");
        }

    }
}