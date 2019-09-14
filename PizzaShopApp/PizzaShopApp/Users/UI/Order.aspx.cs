using PizzaShopApp.Common.BLL;
using System;
using System.Linq;

namespace PizzaShopApp.Users.UI
{
    public partial class Order : System.Web.UI.Page
    {
        private OrderManager _orderManager = new OrderManager();
        protected void Page_Load(object sender, EventArgs e)
        {

            TakesThePizzaOrder();

        }

        private void TakesThePizzaOrder()
        {

            string productItems = Request.Cookies["Items"].Value;
            string[] productItemsArray = productItems.Split('|');




            string userId = Request.Cookies["UserId"].Value;
            string msg = null;



            if (productItemsArray.Count() < 1)
            {
                msg = "There is No Product Item Selected To Make Order ";
            }
            else
            {
                msg = _orderManager.SaveOrderAndOrderItems(productItemsArray, userId);
            }



            if (msg == "Successfully Order Has Been Given")
            {

                Response.Cookies["Items"].Value = null;
                Response.Cookies["Items"].Expires = DateTime.Now.AddDays(-10);
            }



        }



    }
}