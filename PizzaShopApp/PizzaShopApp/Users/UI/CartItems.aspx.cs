using PizzaShopApp.Common.BLL;
using System;
using System.Web.UI.WebControls;

namespace PizzaShopApp.Users.UI
{
    public partial class CartItems : System.Web.UI.Page
    {


        private ProductManager _productManager = new ProductManager();
        protected void Page_Load(object sender, EventArgs e)
        {


            /*string arrayProductItems = Request.Cookies["Items"].Value;

            string[] arr = arrayProductItems.Split('|');

            
            IDictionary<int, int> itemsDictionary = new Dictionary<int, int>();
            foreach (var cartProductItem in arr)
            {
                string[] cartProductItemArray = cartProductItem.Split(',');
                if (cartProductItem.Length>1)
                {
                    itemsDictionary.Add(Convert.ToInt32(cartProductItemArray[0]), Convert.ToInt32(cartProductItemArray[1]));
                }

                
            }*/


            //Response.Write(itemsDictionary);



            LoadALLSelectedCartItems();
        }

        private void LoadALLSelectedCartItems()
        {
            string productItems = Request.Cookies["Items"].Value;


            string[] productItemsArray = productItems.Split('|');

            RepeaterForAllSelectedCartProduct.DataSource = _productManager.GetAllSelectedCartProducts(productItemsArray);
            RepeaterForAllSelectedCartProduct.DataBind();


        }


        protected void btnCancelCookie_Click(object sender, EventArgs e)
        {
            //Response.Cookies["Items"].Value = null;
        }

    }
}