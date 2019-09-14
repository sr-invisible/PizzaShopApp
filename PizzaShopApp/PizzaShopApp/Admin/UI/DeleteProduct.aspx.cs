using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PizzaShopApp.Common.BLL;

namespace PizzaShopApp.Admin.UI
{
    public partial class DeleteProduct : System.Web.UI.Page
    {

        private ProductManager _productManager = new ProductManager();
        protected void Page_Load(object sender, EventArgs e)
        {

            DeteleProduct();

        }

        private void DeteleProduct()
        {




            string id = Request.QueryString["Id"];

            int j = 0;
            try
            {
                j = Convert.ToInt32(id);
            }
            catch (Exception ee)
            {


            }

            string msg = _productManager.DeleteProduct(j);

            Response.Write(msg);
            Response.Redirect("AllProducts.aspx");
        }
    }
}