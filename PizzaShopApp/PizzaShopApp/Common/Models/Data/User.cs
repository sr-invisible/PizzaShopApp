﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaShopApp.Common.Models.Data
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Address{ get; set; }
        public string Email { get; set; }
    }
}