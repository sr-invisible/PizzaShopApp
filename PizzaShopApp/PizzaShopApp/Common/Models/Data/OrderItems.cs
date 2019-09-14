using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaShopApp.Common.Models.Data
{
    public class OrderItems
    {

        public int Id { get; set; }
        public int OrderId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public double TotalPrice { set; get; }
      



    }
}