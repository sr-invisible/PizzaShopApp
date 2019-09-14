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
    public partial class ProductList : System.Web.UI.Page
    {
        private ProductManager _productManager = new ProductManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadAllProducts();
        }

        private void LoadAllProducts()
        {

            RepeaterForAllProducts.DataSource = _productManager.GetAllProducts();

            RepeaterForAllProducts.DataBind();

        }


        protected void RepeaterForAllProducts_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }

        protected void txtSearchByProductName_TextChanged(object sender, EventArgs e)
        {

            var productName = txtSearchByProductName.Text;

            if (productName!=null)
            {

              RepeaterForAllProducts.DataSource = _productManager.GetProductsByName(productName);

              RepeaterForAllProducts.DataBind();
            }
            

        }
    }
}