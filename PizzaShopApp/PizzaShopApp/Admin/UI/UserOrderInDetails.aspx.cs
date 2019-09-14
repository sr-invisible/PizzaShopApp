using System;
using System.Web.UI.WebControls;
using PizzaShopApp.Common.BLL;

namespace PizzaShopApp.Admin.UI
{
    public partial class UserOrderInDetails : System.Web.UI.Page
    {

       private OrderManager _orderManager=new OrderManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadOrderRecordById(Request.QueryString["Id"]);
            
        }

        private void LoadOrderRecordById(string s)
        {

            GridViewOdersDetailsById.DataSource = _orderManager.GetAllOrderItemInfo(s);
            GridViewOdersDetailsById.DataBind();

        }

        protected void GridViewOdersDetailsById_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


    }
}