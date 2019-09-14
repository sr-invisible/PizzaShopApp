using System;
using PizzaShopApp.Common.BLL;

namespace PizzaShopApp.Admin.UI
{
    public partial class AllProducts : System.Web.UI.Page
    {

        private ProductManager _productManager = new ProductManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadAllProducts();
        }



        private void LoadAllProducts()
        {

            RepeaterProducts.DataSource = _productManager.GetAllProducts();

            RepeaterProducts.DataBind();
        }



        protected void GridViewForShowAllSavedProdiuct_DeleteProduct(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            /*

                        string id = GridViewForShowAllSavedProdiuct.DataKeys[e.RowIndex].Values["ProductId"].ToString();


                        Response.Write(id);


                        Response.Redirect("AllProducts.aspx");
     
            */

        }

        protected void RepeaterProducts_ItemCommand(object source, System.Web.UI.WebControls.RepeaterCommandEventArgs e)
        {

        }






    }
}