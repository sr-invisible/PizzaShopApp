using PizzaShopApp.Common.BLL;
using System;

namespace PizzaShopApp.Admin.UI
{
    public partial class ShowAllOrders : System.Web.UI.Page
    {

        private OrderManager _orderManager = new OrderManager();
        protected void Page_Load(object sender, EventArgs e)
        {

            LoadAllOrderRecords();
        }

        private void LoadAllOrderRecords()
        {
            RepeaterOrderRecourds.DataSource = _orderManager.GetAllOrderRecords();
            RepeaterOrderRecourds.DataBind();
        }
    }
}