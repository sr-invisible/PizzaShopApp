using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace PizzaShopApp.Common.DAL
{
    public class CommonGateway
    {
        protected string connectionString = ConfigurationManager.ConnectionStrings["PizzaShopAppDB"].ConnectionString;

    }
}