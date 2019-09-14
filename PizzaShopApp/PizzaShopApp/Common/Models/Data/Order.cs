using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaShopApp.Common.Models.Data
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime DateTime { get; set; }

        public double TotalOrderPrice{ get; set; }

    }
}