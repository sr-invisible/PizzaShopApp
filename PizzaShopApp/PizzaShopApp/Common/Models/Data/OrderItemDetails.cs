using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaShopApp.Common.Models.Data
{
    public class OrderItemDetails
    {

        public string ProductName { get; set; }

        public int ProductQuantity { get; set; }

        public double ProductTotapPrice { get; set; }
    }
}